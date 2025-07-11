using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface ICourtTempRepository : IGenericRepositoryEF<ICourtTemp, CourtTemp, ICourtTempVisitor>
{

}