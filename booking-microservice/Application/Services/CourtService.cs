using Application.Interfaces;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services
{
    public class CourtService : ICourtService
    {
        private readonly ICourtRepository _courtRepository;
        private readonly ICourtFactory _courtFactory;

        public CourtService(ICourtRepository courtRepository, ICourtFactory courtFactory)
        {
            _courtRepository = courtRepository;
            _courtFactory = courtFactory;
        }

        public async Task<ICourt?> AddCourtReferenceAsync(Guid courtId, Guid clubId, decimal basePricePerHour)
        {
            var newCourt = _courtFactory.Create(courtId, clubId, basePricePerHour);

            if (newCourt == null) return null;

            return await _courtRepository.AddAsync(newCourt);
        }
    }
}