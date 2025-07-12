using AutoMapper;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class BookingDataModelConverter : ITypeConverter<BookingDataModel, Booking>
{
    private readonly IBookingFactory _factory;

    public BookingDataModelConverter(IBookingFactory factory)
    {
        _factory = factory;
    }

    public Booking Convert(BookingDataModel source, Booking destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}