using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Buyers
{
    //Gets all the buyers.
    public class IndexModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public IndexModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Holds all the buyers.
        public IList<Buyer> Buyer { get;set; }

        //Gets all the buyers using a linq query.
        public void OnGet()
        {
            Buyer = (from buyer in _context.Buyer select buyer).ToList();
        }
    }
}
