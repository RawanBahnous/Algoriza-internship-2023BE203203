using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Application.Services
{
    public class DiscountService : IDiscountService
    {

        private readonly IDiscountRepository _repository;

        public DiscountService(IDiscountRepository repository)
        {
            _repository = repository;
        }

        public void AddDiscount(AddDiscountDto addDiscount)
        {
            _repository.AddDiscount(addDiscount);
        }

        public void DeactivateDiscount(int Id)
        {
            _repository.DeactivateDiscount(Id);
        }

        public void DeleteDiscount(int Id)
        {
            _repository.DeleteDiscount(Id);
        }

        public void UpdateDiscount(int Id, AddDiscountDto addDiscount)
        {
            _repository.UpdateDiscount(Id, addDiscount);

        }

        public void UpdateDiscount(int Id, DiscountType discounttype, int BookingsCount, string discoundCode, int value)
        {
            throw new NotImplementedException();
        }
    }
}
