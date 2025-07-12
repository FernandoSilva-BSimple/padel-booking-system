using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface ICourtRepository : IGenericRepositoryEF<ICourt, Court, ICourtVisitor>
{

}