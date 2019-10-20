using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;
using Product_Bidding.Models;

namespace Product_Bidding.Pages.Sellers
{
    //Updates the seller 
    public class EditModel : PageModel
    {
        //Holds Database context 
        private readonly Product_Bidding.Models.Product_BiddingDatabaseContext _context;

        public EditModel(Product_Bidding.Models.Product_BiddingDatabaseContext context)
        {
            _context = context;
        }

        //Binds the seller model.
        [BindProperty]
        public Seller Seller { get; set; }

        //Gets the seller for update using  a lamda query.
        public  IActionResult OnGet(int? id)
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

        //Updates the seller 
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Seller).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(Seller.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks the seller record existance using a lamda query.
        private bool SellerExists(int id)
        {
            return _context.Seller.Any(e => e.Id == id);
        }
    }
}
