using Application.Interfaces;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly IClubFactory _clubFactory;

        public ClubService(IClubRepository ClubRepository, IClubFactory ClubFactory)
        {
            _clubRepository = ClubRepository;
            _clubFactory = ClubFactory;
        }

        public async Task<IClub?> AddClubReferenceAsync(Guid clubId, TimePeriod timePeriod)
        {
            var newClub = _clubFactory.Create(clubId, timePeriod);

            if (newClub == null) return null;

            return await _clubRepository.AddAsync(newClub);
        }
    }
}