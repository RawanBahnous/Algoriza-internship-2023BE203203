using System;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Infrastructure.Data;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly VezeetaDbContext _context;

        public DiscountRepository(VezeetaDbContext context)
        {
            _context = context;
        }

        public void AddDiscount(AddDiscountDto addDiscount)
        {
            var discountToAdd = new Discount
            {
                Id = addDiscount.Id,
                DiscountType = addDiscount.DiscountType,
                BookingCount = addDiscount.BookingCount,
                DiscountCode = addDiscount.DiscountCode,
                Value = addDiscount.Value,
                IsActive= addDiscount.IsActive
            };

            _context.Discounts.Add(discountToAdd);
            _context.SaveChanges();

        }

        public void DeactivateDiscount(int Id)
        {
            var discount = _context.Discounts.FirstOrDefault(d=>d.Id == Id);

            if (discount != null)
            {
                discount.IsActive = false;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Discount not found");
            }
               

        }

        public void DeleteDiscount(int Id)
        {
            var discount = _context.Discounts.FirstOrDefault(d => d.Id == Id);

            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Discount not found");
            }

        }

        public void UpdateDiscount(int Id, AddDiscountDto addDiscount)
        {
            var discount = _context.Discounts.FirstOrDefault(d => d.Id == Id);

            if (discount != null )
            {
                discount.DiscountCode = addDiscount.DiscountCode;
                discount.DiscountType = addDiscount.DiscountType;
                discount.Value = addDiscount.Value;

                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Discount not found");
            }

        }
    }
}
