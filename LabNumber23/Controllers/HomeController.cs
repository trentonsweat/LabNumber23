using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabNumber23.Models;

namespace LabNumber23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            GrandCircusDBEntities CoffeeDB = new GrandCircusDBEntities();
            List<Item> AllItems = CoffeeDB.Items.ToList();
            ViewBag.CoffeeList = AllItems;
            ViewBag.Message = "Add or delete coffee";
            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DeleteCoffee(string name)
        {
            GrandCircusDBEntities CoffeeDB = new GrandCircusDBEntities();
            Item i = CoffeeDB.Items.Find(name);
            CoffeeDB.Items.Remove(i); // removes employee from the list
            CoffeeDB.SaveChanges(); // reflects the changes we did on list we have to the db
            return RedirectToAction("About"); // go and execute action once you are done
        }

        public ActionResult NewItemPage()
        {
            return View();
        }
        public ActionResult AddNewCoffee(Item NewItem)
        {
            GrandCircusDBEntities CoffeeDB = new GrandCircusDBEntities(); //orm
            CoffeeDB.Items.Add(NewItem); // saves the new employee to the list
            CoffeeDB.SaveChanges(); // saves the new employee to the database
            return RedirectToAction("About");
        }



    }
}