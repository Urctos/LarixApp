using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Helpers
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IRepository<GlassType> _glassTypeRepository;
        private readonly IRepository<Wood> _woodRepository;
        private readonly IRepository<ImpregnationType> _impregnationTypeRepository;
        private readonly IRepository<Hinges> _hingesRepository;

        public PriceCalculator(IRepository<GlassType> glassTypeRepository,
                               IRepository<Wood> woodRepository,
                               IRepository<ImpregnationType> impregnationTypeRepository,
                               IRepository<Hinges> hingesRepository)
        {
            _glassTypeRepository = glassTypeRepository;
            _woodRepository = woodRepository;
            _impregnationTypeRepository = impregnationTypeRepository;
            _hingesRepository = hingesRepository;
        }

        public async Task<decimal> CalculatePriceAsync(Door door)
        {
            if (door == null)
            {
                throw new ArgumentNullException(nameof(door));
            }

            GlassType glassType = null;
            Wood wood = null;
            ImpregnationType impregnationType = null;
            Hinges hinges = null;

            if (door.GlassTypeId != 0)
            {
                glassType = await _glassTypeRepository.GetByIdAsync(door.GlassTypeId);
            }

            if (door.WoodId != 0)
            {
                wood = await _woodRepository.GetByIdAsync(door.WoodId);
            }

            if (door.ImpregnationTypeId != 0)
            {
                impregnationType = await _impregnationTypeRepository.GetByIdAsync(door.ImpregnationTypeId);
            }

            if (door.HingesId != 0)
            {
                hinges = await _hingesRepository.GetByIdAsync(door.HingesId);
            }

            door.GlassType = glassType;
            door.Wood = wood;
            door.ImpregnationType = impregnationType;
            door.Hinges = hinges;

            decimal woodPrice = wood != null ? wood.Price : 0;
            decimal glassPrice = glassType != null ? glassType.Price : 0;
            decimal hingesPrice = hinges != null ? hinges.Price : 0;
            decimal impregnationPrice = impregnationType != null ? impregnationType.Price : 0;

            decimal newPrice = (glassPrice + woodPrice + impregnationPrice + hingesPrice);
            decimal finalPrice = newPrice* 1.20m;

            return finalPrice;
        }
    }
}
