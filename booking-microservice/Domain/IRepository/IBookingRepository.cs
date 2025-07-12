using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface IBookingRepository : IGenericRepositoryEF<IBooking, Booking, IBookingVisitor>
{
    Task<bool> HasAnActiveBooking(Guid courtId, DateTime initDate, DateTime finalDate);
}