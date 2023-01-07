using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketService _basketService;

        public CheckOutModel(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [BindProperty]
        public BasketCheckoutModel Order { get; set; }

        public BasketModel Cart { get; set; } = default;

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _basketService.GetBasket("duccl");
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            if (Cart == default)
            {
                Cart = await _basketService.GetBasket("duccl");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = "duccl";
            Order.TotalPrice = Cart.TotalPrice;

            await _basketService.CheckoutBasket(Order);
            
            return RedirectToPage("Confirmation", "OrderSubmitted");
        }       
    }
}