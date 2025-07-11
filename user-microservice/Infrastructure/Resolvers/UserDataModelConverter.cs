using AutoMapper;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class UserDataModelConverter : ITypeConverter<UserDataModel, User>
{
    private readonly IUserFactory _UserFactory;

    public UserDataModelConverter(IUserFactory UserFactory)
    {
        _UserFactory = UserFactory;
    }

    public User Convert(UserDataModel source, User destination, ResolutionContext context)
    {
        return _UserFactory.Create(source);
    }

    public bool UpdateDataModel(UserDataModel userDataModel, User userDomain)

    {
        userDataModel.Id = userDomain.Id;

        // pode ser necessário mais atualizações, e com isso o retorno não ser sempre true
        // contudo, porque userDataModel está a ser gerido pelo DbContext, para atualizarmos a DB, é este que tem de ser alterado, e não criar um novo
        return true;
    }
}