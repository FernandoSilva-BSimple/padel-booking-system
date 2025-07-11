using AutoMapper;
using Domain.Factory;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class CourtTempDataModelConverter : ITypeConverter<CourtTempDataModel, CourtTemp>
{
    private readonly ICourtTempFactory _factory;

    public CourtTempDataModelConverter(ICourtTempFactory factory)
    {
        _factory = factory;
    }

    public CourtTemp Convert(CourtTempDataModel source, CourtTemp destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}