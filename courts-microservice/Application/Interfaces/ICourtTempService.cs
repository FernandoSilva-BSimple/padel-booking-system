using Application;
using Application.DTO;
using Contracts.Courts;
using Domain.Interfaces;

public interface ICourtTempService
{
    Task CreateCourtTempAsync(CreateRequestedCourtCommand command);
    Task StartSagaAsync(CreateCourtAndClubDTO dto);
    Task DeleteCourtTempAsync(Guid id);

}