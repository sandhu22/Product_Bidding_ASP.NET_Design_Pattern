using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Bidding.BusinessLayer
{
    //Holds Bid details.
    public class Bid
    {

        //Primary Key
        public int Id { get; set; }

        //Product Id foriegn key
        public int ProductId { get; set; }
        
        //Buyer Id foriegn key
        public int BuyerId { get; set; }

        //Seller Id foriegn key
        public int SellerId { get; set; }

        //Buyer relationship link
        public Buyer Buyer { get; set; }

        //Seller relationship link
        public Seller Seller { get; set; }

        //Product relationship link
        public Product Product { get; set; }

        //Bidder declared offer price.
        public  decimal BidPrice { get; set;  }

    }
}
