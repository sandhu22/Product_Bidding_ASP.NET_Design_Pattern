using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Bids
{
    //Updates the Bid.
    public class EditModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public EditModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Binds the bid model
        [BindProperty]
        public Bid Bid { get; set; }


        //Gets the bid record for updating using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bid =  _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller).FirstOrDefault(m => m.Id == id);

            if (Bid == null)
            {
                return NotFound();
            }
           ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerRegistrationId", Bid.Buyer.Id);
           ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductRegistrationId", Bid.Product.Id);
           ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerRegistrationNumber", Bid.Seller.Id);
            return Page();
        }

        //Updates the Bid
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bid).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(Bid.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks the record exits using a lamda query.
        private bool BidExists(int id)
        {
            return _context.Bid.Any(e => e.Id == id);
        }
    }
}
