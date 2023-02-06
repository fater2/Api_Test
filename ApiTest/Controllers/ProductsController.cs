using Castle.Core.Internal;
using Domain.ApiResults;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        //private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        [HttpGet]
        public virtual APIResult get()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            List<ProductVw> models=new List<ProductVw>();
            foreach (Product product in products)
            {
                
                models.Add(new()
                {
                    id= product.Id,
                    EnName=product.Name,
                    ArName=product.Name,
                    StartDate=product.StartDate,
                    EndDate=(product.StartDate.AddMinutes((double)product.Duration)),
                    RegisterDate=product.CreationDate,
                    Price=product.Price,
                    CategoryCode=product.Category.Code,
                    CategoryName=product.Category.Name
                });
            }
            return SuccessResponse(data: models, message: "Success");
        }
        [HttpGet("{id:int}")]
        public virtual APIResult get(int id)
        {
            Product product = _unitOfWork.Product.GetById(id);
            if (product == null)
                return ErrorResponse("Model Not Found");
            ProductVw model = new()
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

            };
            return SuccessResponse(data: model, message: "Getted Successfully");
        }

        [HttpPost]
        public virtual APIResult Post([FromBody] ProductCreateVw model)
        {
            if (!ModelState.IsValid || model.EnName + model.ArName == "" || model.Price < 0)
            {
                return ErrorResponse(message: "Model is not valid");
            }
            var category = _unitOfWork.Category.Find(m => m.Code == model.CategoryCode).ToList();
            if (category.IsNullOrEmpty())
                return ErrorResponse(message: "Category Code is Not Valid");
            if (model.EndDate < model.StartDate)
                return ErrorResponse(message: "EndDate and StartDate is Not Valid");
            try
            {
                if (model.EnName.IsNullOrEmpty())
                    model.EnName = model.ArName;
                else if (model.ArName.IsNullOrEmpty())
                    model.ArName = model.EnName;


                int categoryId = category.First().Id;
                // add product 
                Product product = new()
                {
                    Name = model.EnName ?? model.ArName,
                    NameAr = model.ArName ?? model.EnName,
                    CategoryId = categoryId,
                    Code = Guid.NewGuid().ToString(),
                    Price = model.Price,
                    Duration = (model.EndDate - model.StartDate).TotalMinutes,
                    CreationDate = DateTime.Now,
                    StartDate=model.StartDate,


                };
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                int productId = product.Id;
                // add customfields
                //List<CustomField> customFields = new();
                foreach (var a in model.CustomFieldList)
                {
                    var cf = _unitOfWork.CustomField.Find(m => m.Name == a.CustomFieldName).FirstOrDefault();
                    if (cf == null)
                    {
                        //add cf

                        CustomField customField = new CustomField();
                        customField.Name = a.CustomFieldName;
                        _unitOfWork.CustomField.Add(customField);
                        _unitOfWork.Save();
                        int customFieldId = customField.Id;

                        //add pcf
                        ProductCustomField pcd = new ProductCustomField()
                        {
                            ProductId = productId,
                            CustomFieldId = customFieldId,
                        };
                        _unitOfWork.ProductCustomField.Add(pcd);
                        _unitOfWork.Save();
                        int productCustomFieldId = pcd.Id;

                        //add cfv
                        CustomFieldValue cfv = new()
                        {
                            ProductCustomFieldId = productCustomFieldId,
                            Key = a.Key,
                            Value = a.Value
                        };
                        _unitOfWork.CustomFieldValue.Add(cfv);
                        _unitOfWork.Save();

                        //customField.CustomFieldValues.Add(cfv);
                        //pcd.CustomField = customField;
                        //product.ProductCustomFields.Add(pcd);

                    }
                    else
                    {
                        //check pcf if exist for product<->cf
                        ProductCustomField pcf;
                        var pcfs = _unitOfWork.ProductCustomField.Find(m => (m.ProductId == productId && m.CustomFieldId == cf.Id)).ToList();
                        if (pcfs.IsNullOrEmpty())
                        {
                            pcf = new()
                            {
                                ProductId = productId,
                                CustomFieldId = cf.Id,
                            };
                            _unitOfWork.ProductCustomField.Add(pcf);
                            _unitOfWork.Save();
                        }
                        else
                        {
                            pcf = pcfs.First();
                        }


                        int pcfId = pcf.Id;


                        CustomFieldValue cfv = new()
                        {
                            ProductCustomFieldId = pcfId,
                            Key = a.Key,
                            Value = a.Value
                        };
                        _unitOfWork.CustomFieldValue.Add(cfv);
                        _unitOfWork.Save();

                    }

                }

                return SuccessResponse(message: "ProductId: " + productId + ", " + "productCode: " + product.Code );

            }
            catch (Exception ex)
            {
                return ErrorResponse(message: ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public virtual APIResult Put([FromBody] ProductEditVw model,int id )
        {
            if (!ModelState.IsValid || (model.EnName + model.ArName).IsNullOrEmpty() || model.Price < 0)
                ErrorResponse("BadRequest: Not a valid model");
            var p = _unitOfWork.Product.GetById(id);
            if (p == null)
                return ErrorResponse(message: "Model Not Found");
            var category = _unitOfWork.Category.Find(m => m.Code == model.CategoryCode).ToList();
            if (category.IsNullOrEmpty())
                return ErrorResponse(message: "Category Code is Not Valid");
            if (model.EndDate < model.StartDate)
                return ErrorResponse(message: "EndDate and StartDate is Not Valid");

            if (model.EnName.IsNullOrEmpty())
                model.EnName = model.ArName;
            else if (model.ArName.IsNullOrEmpty())
                model.ArName = model.EnName;
           
            try
            {
                p.Name = model.EnName;
                p.NameAr = model.ArName;
                p.StartDate=model.StartDate;
                p.Duration=(model.EndDate-model.StartDate).TotalMinutes;
                p.Price= model.Price;
                p.CategoryId=category.First().Id;
                _unitOfWork.Product.Edit(p);
                _unitOfWork.Save();
                return SuccessResponse("Model Edited successfully");
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public virtual APIResult Delete(int id)
        {
            var p = _unitOfWork.Product.GetById(id);
            if (p == null)
                return ErrorResponse(message: "Model Not Found");
            _unitOfWork.Product.Remove(p);
            return SuccessResponse("deleted successfully");
        }

    }
}
