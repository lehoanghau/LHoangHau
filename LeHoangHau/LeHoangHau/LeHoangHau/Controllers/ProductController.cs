using LeHoangHau.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHoangHau.Controllers
{
    public class ProductController : Controller
    {
        hau_aspEntities1 hau_aspEntities1 = new hau_aspEntities1();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = hau_aspEntities1.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}