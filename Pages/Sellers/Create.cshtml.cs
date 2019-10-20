using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Sellers
{

    //Creats  a Seller 
    public class CreateModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public CreateModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Gets the  create seller form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the Seller model.
        [BindProperty]
        public Seller Seller { get; set; }

        //Adds  a seller to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seller.Add(Seller);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}