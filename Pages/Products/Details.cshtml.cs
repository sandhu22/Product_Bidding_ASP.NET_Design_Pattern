using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Products
{
    //Gets the product details .
    public class DetailsModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public DetailsModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Holds the product model.
        public Product Product { get; set; }

        //Gets the product using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product =  _context.Product.FirstOrDefault(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
