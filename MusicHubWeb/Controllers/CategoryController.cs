using Microsoft.AspNetCore.Mvc;
using MusicHub.DataAccess.Data;
using MusicHub.DataAccess.Repository;
using MusicHub.DataAccess.Repository.IRepository;
using MusicHub.Models;


namespace MusicHubWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _context;

        public CategoryController(ICategoryRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _context.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(obj);
                _context.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction(nameof(Index), "Category");
            }
            return View(obj);
           
        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _context.Get(u=>u.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _context.Update(obj);
                _context.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction(nameof(Index), "Category");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _context.Get(u=>u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _context.Get(u=>u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            
            _context.Remove(obj);
            _context.Save();
            TempData["success"] = "Category deleted successfully";

            return RedirectToAction(nameof(Index), "Category");


        }


    }
}
