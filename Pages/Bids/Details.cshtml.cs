using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Bids
{
    //Gets the Details of the Bid 
    public class DetailsModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public DetailsModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Holds the Bid model.
        public Bid Bid { get; set; }

        //Gets the details of bit using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bid = _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller).FirstOrDefault(m => m.Id == id);

            if (Bid == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
