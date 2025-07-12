using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface IClubRepository : IGenericRepositoryEF<IClub, Club, IClubVisitor>
{
    Task<bool> Exists(Guid Id);
    Task<TimePeriod?> GetTimePeriodAsync(Guid id);

}