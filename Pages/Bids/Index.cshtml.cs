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
    //Returns all bids 
    public class IndexModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public IndexModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Holds all the bids .
        public IList<Bid> Bid { get;set; }

        //Returns all the bids including relationships using a lamda query.
        public void OnGet()
        {
            Bid =  _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller).ToList();
        }
    }
}
