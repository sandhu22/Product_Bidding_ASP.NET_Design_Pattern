using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Sellers
{
    //Displays all the sellers
    public class IndexModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public IndexModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //All available aellers .
        public IList<Seller> Seller { get;set; }

        //Gets all sellers using a linq  query.
        public  void OnGet()
        {
            Seller = (from seller in _context.Seller select seller).ToList();
        }
    }
}
