using Domain.Models;
using Domain.Visitor;

public interface ICourtFactory
{
    Court Create(Guid id, Guid clubId, decimal basePricePerHour);
    Court Create(ICourtVisitor visitor);

}