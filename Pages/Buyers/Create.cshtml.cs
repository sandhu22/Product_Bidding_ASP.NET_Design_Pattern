using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Buyers
{
    //Adds a  new buyer.
    public class CreateModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public CreateModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Gets the all new buyer form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the Buyer model
        [BindProperty]
        public Buyer Buyer { get; set; }

        //Adds a buyer record to the databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Buyer.Add(Buyer);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}