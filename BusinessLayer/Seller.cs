using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Bidding.BusinessLayer
{

    //Seller information
    public class Seller
    {
        //Seller primary key
        public int Id { get; set; }

        //Seller name
        [Required]
        public string SellerName { get; set; }

        //Seller external registration number.
        public string SellerRegistrationNumber { 
                get
            {

                return "SELLER-" + Id + "-" + SellerName;
            }
        }

        //Seller contact information
        public string ContactNumber { get; set; }



    }
}
