using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;

namespace Application.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _ClubRepository;
        private readonly IClubFactory _ClubFactory;

        public ClubService(IClubRepository ClubRepository, IClubFactory ClubFactory)
        {
            _ClubRepository = ClubRepository;
            _ClubFactory = ClubFactory;
        }

        public async Task<IClub?> AddClubReferenceAsync(Guid ClubId)
        {
            var newClub = await _ClubFactory.Create(ClubId);

            if (newClub == null) return null;

            return await _ClubRepository.AddAsync(newClub);
        }
    }
}