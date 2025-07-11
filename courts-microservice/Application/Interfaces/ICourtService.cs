using Application;
using Application.DTO;
using Domain.Interfaces;

public interface ICourtService
{
    Task<Result<CourtDTO>> Create(CreateCourtDTO courtDTO);
    Task<ICourt> AddConsumedCourtAsync(Guid id, string name, decimal basePricePerHour, Guid clubId);

}