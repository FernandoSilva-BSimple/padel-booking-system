using Domain.Interfaces;
using Domain.Models;

namespace Application.Interfaces;

public interface ICourtService
{
    Task<ICourt?> AddCourtReferenceAsync(Guid courtId, Guid clubId, decimal basePricePerHour);

}