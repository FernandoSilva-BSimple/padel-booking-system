using AutoMapper;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class ClubDataModelConverter : ITypeConverter<ClubDataModel, Club>
{
    private readonly IClubFactory _factory;

    public ClubDataModelConverter(IClubFactory factory)
    {
        _factory = factory;
    }

    public Club Convert(ClubDataModel source, Club destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}