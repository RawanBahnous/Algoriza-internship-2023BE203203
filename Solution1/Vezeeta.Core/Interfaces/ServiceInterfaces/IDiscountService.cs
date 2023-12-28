using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Core.Interfaces.ServiceInterfaces
{
    public interface IDiscountService
    {
        void AddDiscount(AddDiscountDto addDiscount);
        void UpdateDiscount(int Id, AddDiscountDto addDiscount);
        void DeleteDiscount(int Id);
        void DeactivateDiscount(int Id);
    }
}
