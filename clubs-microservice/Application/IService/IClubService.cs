using Application.DTO;
using Domain.Models;
public interface IClubService
{
    Task<CreateClubDTO> Add(CreateClubDTO clubDTO);
    Task AddConsumed(Guid id, string name, TimeOnly startTime, TimeOnly endTime);
    Task<bool> Exists(Guid Id);
    Task<IEnumerable<IClub>> GetAll();
    Task<IClub?> GetById(Guid Id);
    Task<ClubDTO> AddClubFromSagaAsync(CreateClubDTO clubDTO, Guid collabTempId);

}
