using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Bidding.BusinessLayer
{
    //Buyer information
    public class Buyer
    {
        //Primary key
        public int Id { get; set; }

        //Name of the buyer 
        [Required]
        public string BuyerName { get; set; }

        //Buyer external registration identifier.
        public string BuyerRegistrationId { get {

                return "BUYER-" + Id + "-" + BuyerName;
            } }

        [Required]
        //Buyers account number.
        public string BuyerAccountNumber { get; set; }

    }
}
