using Domain.Interfaces;
using Domain.Models;

namespace Application.Interfaces;

public interface IClubService
{
    Task<IClub?> AddClubReferenceAsync(Guid clubId, TimePeriod timePeriod);

}