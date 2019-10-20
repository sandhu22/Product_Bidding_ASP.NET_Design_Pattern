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
    //Deletes a  seller.
    public class DeleteModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public DeleteModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Binds the seller model.
        [BindProperty]
        public Seller Seller { get; set; }

        //Gets the  seller for deletion  using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller = _context.Seller.FirstOrDefault(m => m.Id == id);

            if (Seller == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes a seller. Uses a linq query to get the seller from database.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller = (from seller in _context.Seller

                      where seller.Id == id
                      select seller).FirstOrDefault();

            if (Seller != null)
            {
                _context.Seller.Remove(Seller);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
