using LeHoangHau.Context;
using LeHoangHau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHoangHau.Controllers
{
    public class PaymentController : Controller
    {
        hau_aspEntities1 hau_aspEntities1 = new hau_aspEntities1();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["Cart"];
                Order objOrder = new Order();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["IdUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                hau_aspEntities1.Orders.Add(objOrder);
                hau_aspEntities1.SaveChanges();


                int intOrderId = objOrder.Id;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                hau_aspEntities1.OrderDetails.AddRange(lstOrderDetail);
                hau_aspEntities1.SaveChanges();
            }

            return View();
        }
    }
}