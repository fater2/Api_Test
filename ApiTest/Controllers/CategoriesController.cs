using Domain.ApiResults;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        [HttpGet]
        public virtual APIResult get()
        {
            var cats = _unitOfWork.Category.GetAll().ToList();
            List<CategoryVw> models = new ();
            foreach (Category a in cats)
            {

                models.Add(new()
                {
                    Id = a.Id,
                    Name = a.Name,
                   Code = a.Code,
                });
            }
            return SuccessResponse(data: models, message: "Success");
        }
        [HttpGet("{categoryId:int}/products")]
        public virtual APIResult get(int categoryId)
        {
            var category = _unitOfWork.Category.GetById(categoryId);
            if (category == null)
                return ErrorResponse("Model Not Found");
            var products = _unitOfWork.Product.GetByCategoryId(categoryId).ToList();
            List<ProductVw> models = new List<ProductVw>();
            foreach (Product product in products)
            {

                models.Add(new()
                {
                    id = product.Id,
                    EnName = product.Name,
                    ArName = product.Name,
                    StartDate = product.StartDate,
                    EndDate = (product.StartDate.AddMinutes((double)product.Duration)),
                    RegisterDate = product.CreationDate,
                    Price = product.Price,
                    CategoryCode = product.Category.Code,
                    CategoryName = product.Category.Name
                });
            }

            return SuccessResponse(data: models, message: "Getted Successfully");
        }

        [HttpDelete("{id:int}")]
        public virtual APIResult Delete(int id)
        {
            Category c = _unitOfWork.Category.GetById(id);
            if (c == null)
                return ErrorResponse(message: "Model Not Found");
            _unitOfWork.Category.Remove(c);
            return SuccessResponse("deleted successfully");
        }
    }
}
