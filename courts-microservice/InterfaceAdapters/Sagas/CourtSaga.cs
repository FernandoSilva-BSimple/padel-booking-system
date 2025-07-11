using Contracts.Clubs;
using Contracts.Courts;
using MassTransit;

namespace InterfaceAdapters.Sagas;

public class CourtSaga : MassTransitStateMachine<CourtSagaState>
{
    public State WaitingForClubCreation { get; private set; }
    public State Completed { get; private set; }

    public Event<CreateRequestedCourtCommand> CreateCourtRequested { get; private set; } = default!;
    public Event<ClubCreatedMessage> ClubCreated { get; private set; } = default!;

    public CourtSaga()
    {
        InstanceState(x => x.CurrentState);

        Event(() => CreateCourtRequested, x => x.CorrelateById(context => context.Message.CollabTempId));
        Event(() => ClubCreated, x => x.CorrelateById(context => context.Message.CorrelationId!.Value));

        Initially(
            When(CreateCourtRequested)
                .ThenAsync(async ctx =>
                {
                    Console.WriteLine("CreateCourtRequested was CALLED!");

                    var provider = ctx.GetPayload<IServiceProvider>();
                    using var scope = provider.CreateScope();

                    var courtTempService = scope.ServiceProvider.GetRequiredService<ICourtTempService>();

                    await courtTempService.CreateCourtTempAsync(ctx.Message);
                })
                .Send(new Uri("queue:clubs-cmd-saga"), ctx => new CreateClubFromCourtCommand(
                    ctx.Message.CollabTempId,
                    ctx.Message.ClubName,
                    ctx.Message.StartTime,
                    ctx.Message.EndTime
                ))
                .TransitionTo(WaitingForClubCreation)
        );

        During(WaitingForClubCreation,
            When(ClubCreated)
                .ThenAsync(async ctx =>
                {
                    Console.WriteLine("ClubCreated was CALLED!");

                    var provider = ctx.GetPayload<IServiceProvider>();
                    using var scope = provider.CreateScope();

                    var courtTempService = scope.ServiceProvider.GetRequiredService<ICourtTempService>();
                    var courtFactory = scope.ServiceProvider.GetRequiredService<ICourtFactory>();
                    var courtService = scope.ServiceProvider.GetRequiredService<ICourtService>();

                    var temp = await courtTempService.GetByIdAsync(ctx.Message.CorrelationId!.Value);
                    if (temp is null) throw new InvalidOperationException("CourtTemp not found.");

                    var court = courtFactory.ConvertFromTemp(temp, ctx.Message.Id);

                    await courtService.AddCourtAsync(court);
                    await courtTempService.DeleteCourtTempAsync(temp.Id);

                    await ctx.Publish(new CourtCreatedMessage(
                        court.Id, court.Name, court.BasePricePerHour, court.ClubId
                    ));
                })
                .TransitionTo(Completed)
                .Finalize()
        );

        SetCompletedWhenFinalized();
    }
}
