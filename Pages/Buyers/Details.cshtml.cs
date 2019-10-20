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
    //Gets the Buyer details.
    public class DetailsModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public DetailsModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Holds the buyer model.
        public Buyer Buyer { get; set; }

        //Gets the buyer model using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buyer =  _context.Buyer.FirstOrDefault(m => m.Id == id);

            if (Buyer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
