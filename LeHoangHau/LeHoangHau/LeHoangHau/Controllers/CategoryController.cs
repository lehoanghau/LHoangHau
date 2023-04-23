using LeHoangHau.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHoangHau.Controllers
{
    public class CategoryController : Controller
    {
        hau_aspEntities1 hau_aspEntities1 = new hau_aspEntities1();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = hau_aspEntities1.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var lstProduct = hau_aspEntities1.Products.Where(n => n.CategoryId == Id).ToList();
            return View(lstProduct);
        }
    }
}