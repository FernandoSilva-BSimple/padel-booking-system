using AutoMapper;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Resolvers;

namespace Infrastructure;

public class DataModelMappingProfile : Profile
{
    public DataModelMappingProfile()
    {
        CreateMap<Court, CourtDataModel>();
        CreateMap<CourtDataModel, Court>()
            .ConvertUsing<CourtDataModelConverter>();
        CreateMap<Booking, BookingDataModel>();
        CreateMap<BookingDataModel, Booking>()
            .ConvertUsing<BookingDataModelConverter>();
        CreateMap<Club, ClubDataModel>();
        CreateMap<ClubDataModel, Club>()
            .ConvertUsing<ClubDataModelConverter>();
    }
}