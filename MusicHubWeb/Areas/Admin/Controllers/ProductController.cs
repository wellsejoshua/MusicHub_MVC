﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicHub.DataAccess.Data;
using MusicHub.DataAccess.Repository;
using MusicHub.DataAccess.Repository.IRepository;
using MusicHub.Models;
using MusicHub.Models.ViewModels;
using MusicHub.Utility;


namespace MusicHubWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.ProductRepository.GetAll(includeProperties:"Category").ToList();
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.CategoryRepository.GetAll().ToList()
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ProductVM productVM = new()
            {
                CategoryList = CategoryList,
                Product = new Product()
            };

            if(id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //Update
                productVM.Product = _unitOfWork.ProductRepository.Get(u => u.Id == id);
                return View(productVM);
            }


        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"img\product");

                    //check if imageUrl is empty and if not replace the file
                    if(!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        //delete old image
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"img\product\" + fileName;
                }

                if(productVM.Product.Id == 0)
                {
                    _unitOfWork.ProductRepository.Add(productVM.Product);

                }
                else
                {
                    _unitOfWork.ProductRepository.Update(productVM.Product);

                }
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction(nameof(Index), "Product");
            }
            else
            {
                IEnumerable<SelectListItem> CategoryList = _unitOfWork.CategoryRepository.GetAll().ToList()
                    .Select(u => new SelectListItem
                     {
                        Text = u.Name,
                        Value = u.Id.ToString()
                     });
                productVM.CategoryList = CategoryList;
            }
            return View(productVM);

        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductList = _unitOfWork.ProductRepository.GetAll(includeProperties:"Category").ToList();
            return Json(new {data = objProductList});
        }
        //Delete Image and product
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Product productToDelete = _unitOfWork.ProductRepository.Get(u=>u.Id == id);
            if(productToDelete == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var oldImagePath = Path.Combine(wwwRootPath, productToDelete.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.ProductRepository.Remove(productToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
