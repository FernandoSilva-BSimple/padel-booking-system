using AutoMapper;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class ClubDataModelConverter : ITypeConverter<ClubDataModel, Club>
{
    private readonly IClubFactory _ClubFactory;

    public ClubDataModelConverter(IClubFactory ClubFactory)
    {
        _ClubFactory = ClubFactory;
    }

    public Club Convert(ClubDataModel source, Club destination, ResolutionContext context)
    {
        return _ClubFactory.Create(source);
    }

    public bool UpdateDataModel(ClubDataModel ClubDataModel, Club ClubDomain)

    {
        ClubDataModel.Id = ClubDomain.Id;

        // pode ser necessário mais atualizações, e com isso o retorno não ser sempre true
        // contudo, porque ClubDataModel está a ser gerido pelo DbContext, para atualizarmos a DB, é este que tem de ser alterado, e não criar um novo
        return true;
    }
}