using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IActionResult Index()
        {
            var values = productManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(p);

            if(results.IsValid)
            {
                productManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeleteProduct(int id)
        {
            var value = productManager.TGetById(id);
            productManager.TDelete(value);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = productManager.TGetById(id);
            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            productManager.TUpdate(p);
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var product = productManager.TGetById(id);

        //    var studentModel = new StudentModel
        //    {
        //        Students = student

        //    };
        //    return View(studentModel);

        //}
        //[HttpPost]
        //public IActionResult Update(StudentModel studentModel)
        //{
        //    var student = new Student
        //    {
        //        Id = studentModel.Students.Id,
        //        FirstName = studentModel.Students.FirstName,
        //        LastName = studentModel.Students.LastName,
        //        Gender = studentModel.Students.Gender,
        //        BirhDate = studentModel.Students.BirhDate,
        //        Email = studentModel.Students.Email,
        //        IsActive = true,

        //    };
        //    _studentService.Update(student);
        //    return RedirectToAction("Index");
        //}

    }
}
