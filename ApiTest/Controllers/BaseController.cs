using Domain.ApiResults;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ApiTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork) : base()
        {
            _unitOfWork=unitOfWork;
        }
        public BaseController()
        {

        }
        /// <summary>
        /// Retrun json success result
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        protected APIResult SuccessResponse(string message = null)
        {
            return new APIResult()
            {
                Succeed = true,
                Message = message ?? "TaskCompletedSuccfessfully"
            };
        }


        /// <summary>
        /// Returns a success result with data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        protected APIResult<T> SuccessResponse<T>(T data, string message = null)
        {
            return new APIResult<T>()
            {
                Succeed = true,
                Message = message ?? "TaskCompletedSuccfessfully",
                Data = data
            };
        }

        /// <summary>
        /// Return a json error result
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        [NonAction]
        protected APIResult ErrorResponse(string message = null)
        {
            return new APIResult()
            {
                Succeed = false,
                Message = message ?? "UnexpectedError"
            };
        }

        /// <summary>
        /// Return a json error result with data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        protected APIResult ErrorResponse<T>(T data, string message = null)
        {
            return new APIResult<T>()
            {
                Succeed = false,
                Message = message ?? "UnexpectedError",
                Data = data
            };
        }


    }
}
