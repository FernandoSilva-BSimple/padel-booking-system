using AutoMapper;
using Domain.Factory;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class CourtDataModelConverter : ITypeConverter<CourtDataModel, Court>
{
    private readonly ICourtFactory _factory;

    public CourtDataModelConverter(ICourtFactory factory)
    {
        _factory = factory;
    }

    public Court Convert(CourtDataModel source, Court destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}