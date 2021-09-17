using StoreFront.Data.EF;
using StoreFront1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreFront1.Controllers
{
    public class ShoppingCartController : Controller
    {
        //Access to DB
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            if (shoppingCart == null)
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }

            return View(shoppingCart);
        }

        //store our info in session
        public ActionResult AddToCart(int qty, int headphoneId)
        {
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            //Check if session-cart exists
            if (Session["cart"] != null)
            {
                shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
            }
            else
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }

            //Find ID that was passed to this action
            HeadPhoneStore headPhone = db.HeadPhoneStores.Find(headphoneId);

            //Create the cart item, assign the headphone and qty property
            CartItemViewModel item = new CartItemViewModel(qty, headPhone);

            //Add items to cart and update qty if same item is already in cart
            if (shoppingCart.ContainsKey(headPhone.HeadPhoneID))
            {
                shoppingCart[headPhone.HeadPhoneID].Qty += qty;
            }
            else
            {
                shoppingCart.Add(headPhone.HeadPhoneID, item);
            }

            //Updates session variable
            Session["cart"] = shoppingCart;

            return RedirectToAction("Index");                     
        }

        public ActionResult RemoveFromCart(int id)
        {
            //Retrieve our session variable and store locally
            Dictionary<int, CartItemViewModel> shoppinCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            //remove the cart item
            shoppinCart.Remove(id);

            //Update session
            Session["cart"] = shoppinCart;
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCart(int headphoneId, int qty)
        {
            //retireve the session and store it locally
            Dictionary<int, CartItemViewModel> shoppinCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            //update the quantity tied to the bookId that was passed to this action
            shoppinCart[headphoneId].Qty = qty;

            //if cart item quantity is 0, remove that item from the cart
            if (shoppinCart[headphoneId].Qty == 0)
            {
                shoppinCart.Remove(headphoneId);
            }

            //Update session
            Session["cart"] = shoppinCart;

            return RedirectToAction("Index");

        }



    }
}