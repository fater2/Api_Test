using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiResults
{
    public interface IAPIResult
    {
        public bool Succeed { get; set; }

        public string Message { get; set; }
    }

    public interface IAPIResult<T> : IAPIResult
    {
        public T Data { get; set; }
    }

    public class APIResult : IAPIResult
    {
        public bool Succeed { get; set; }

        public string Message { get; set; }
    }
    public class APIResult<T> : APIResult, IAPIResult<T>
    {
        public T Data { get; set; }
    }







}
