using Domain.Interfaces;

namespace Application.Interfaces;

public interface IClubService
{
    Task<IClub?> AddClubReferenceAsync(Guid ClubId);

}