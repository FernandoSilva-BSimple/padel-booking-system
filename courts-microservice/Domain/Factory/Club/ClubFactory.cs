using Domain.IRepository;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class ClubFactory : IClubFactory
{
    private readonly IClubRepository _clubRepository;

    public ClubFactory(IClubRepository clubRepository, ICourtRepository courtRepository)
    {
        _clubRepository = clubRepository;
    }

    public async Task<Club> Create(Guid id)
    {
        var alreadyExists = await _clubRepository.Exists(id);
        if (alreadyExists) throw new Exception("Club already exists");

        return new Club(id);
    }

    public Club Create(IClubVisitor clubVisitor)
    {
        return new Club(clubVisitor.Id);
    }
}