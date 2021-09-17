using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreFront.Data.EF;

namespace StoreFront1.Models
{
    public class CartItemViewModel
    {
    
        public HeadPhoneStore HeadPhones { get; set; }

        public int Qty { get; set; }

        public CartItemViewModel(int qty, HeadPhoneStore headPhones)
        {
            Qty = qty;
            HeadPhones = headPhones;
        }

    }




    
}