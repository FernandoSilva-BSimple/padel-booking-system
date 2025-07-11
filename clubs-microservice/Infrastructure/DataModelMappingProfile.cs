using AutoMapper;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Resolvers;

namespace Infrastructure;

public class DataModelMappingProfile : Profile
{
    public DataModelMappingProfile()
    {
        CreateMap<Club, ClubDataModel>();
        CreateMap<ClubDataModel, Club>()
            .ConvertUsing<ClubDataModelConverter>();
    }

}