using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Models
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }

}
