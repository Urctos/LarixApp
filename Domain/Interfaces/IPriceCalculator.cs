using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPriceCalculator
    {
        Task<decimal> CalculatePriceAsync(Door door);
    }
}
