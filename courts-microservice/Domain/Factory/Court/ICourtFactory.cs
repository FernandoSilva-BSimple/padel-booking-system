using Domain.Models;
using Domain.Visitor;

public interface ICourtFactory
{
    Task<Court> Create(string name, decimal basePricePerHour, Guid clubId);
    Court Create(ICourtVisitor visitor);
    Task<Court> Create(Guid id, string name, decimal basePricePerHour, Guid clubId);
    Court ConvertFromTemp(ICourtTemp courtTemp, Guid clubId);

}