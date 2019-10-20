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

    //Removes a product record from the database.
    public class DeleteModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public DeleteModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Binds the product .
        [BindProperty]
        public Product Product { get; set; }

        //Gets the product for deletion using the lamda query.
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


        //Removes the product from the databse. Uses a linq query to get the product.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = (from product in _context.Product
                       where product.Id == id
                       select product).FirstOrDefault();

            if (Product != null)
            {
                _context.Product.Remove(Product);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
