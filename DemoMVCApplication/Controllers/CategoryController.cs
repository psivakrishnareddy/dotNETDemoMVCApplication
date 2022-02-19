using DemoMVCApplication.Data;
using DemoMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVCApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        { IEnumerable<Category> catList = _db.Categories;
            return View(catList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Edit(int? id)
        {   if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            var cat = _db.Categories.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            if(cat == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
