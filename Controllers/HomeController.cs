using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            // Dish dish = dbContext.Dishes.FirstOrDefault(Dishid => Dishid.DishId == 1);

            List<Dish> AllDishes = dbContext.Dishes.ToList();
            // AllDishes.Reverse();

            return View("Index", AllDishes);
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            return View();
        }
  
        [HttpGet("Add")]
        public IActionResult Add(Dish newDish)
        {
            dbContext.Dishes.Add(newDish);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("Home/ViewDish/{dishId}")]
        
        public IActionResult ViewDish(int dishId)
        {
            Dish Editing = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            // List<Dish> AllDishes = dbContext.Dishes.ToList();

            return View(Editing);
        }

        [HttpGet("Home/Edit/{dishId}")]
        public IActionResult Edit(int dishId)
        {
            Dish EditDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            
            return View(EditDish);
        }

        [HttpPost("Home/Update/{dishId}")]
        public IActionResult Update(Dish d, int dishId)
        {
            Dish UpdateDish =
            dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            UpdateDish.Name = d.Name;
            UpdateDish.DishId = d.DishId;
            UpdateDish.Calories = d.Calories;
            UpdateDish.Tastiness = d.Tastiness;
            UpdateDish.Description = d.Description;

            dbContext.SaveChanges();

            return RedirectToAction("ViewDish", new {dishId = dishId});
        }

        [HttpGet("Home/delete/{dishId}")]
        public IActionResult Delete(int dishId)
        {
            Dish DeleteDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);

            dbContext.Dishes.Remove(DeleteDish);
            dbContext.SaveChanges();

            return RedirectToAction("index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
