using Vezeeta.Core.Models;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Core.Interfaces.RepositoriesInterfaces
{
    public interface IDiscountRepository
    {
        void AddDiscount(AddDiscountDto addDiscount);
        void UpdateDiscount(int Id, AddDiscountDto addDiscount);
        void DeleteDiscount(int Id);
        void DeactivateDiscount(int Id);

    }
}
