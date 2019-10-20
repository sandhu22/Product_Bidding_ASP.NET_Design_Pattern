using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Bids
{
    //Creates a Bid
    public class CreateModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public CreateModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }


        //Prepares the create bid form
        public IActionResult OnGet()
        {
        ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerRegistrationId");
        ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductRegistrationId");
        ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerRegistrationNumber");
            return Page();
        }


        //Binds the bid information model.
        [BindProperty]
        public Bid Bid { get; set; }

        //Adds  a bid record to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bid.Add(Bid);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}