using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public interface IClubFactory
{
    Task<Club> Create(Guid id);
    Club Create(IClubVisitor clubVisitor);

}