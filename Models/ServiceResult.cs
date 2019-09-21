using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public static ServiceResult Error(ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            modelState.Values.ToList().ForEach(c =>
            {
                c.Errors.ToList().ForEach(ci =>
                {
                    errors.Add(ci.ErrorMessage);
                });
            });

            return new ServiceResult() { IsSuccess = false, Errors = errors };
        }

        public static ServiceResult Error(string errorMessage)
        {
            return new ServiceResult() { IsSuccess = false, Errors = new List<string> { errorMessage } };
        }

        public static ServiceResult Error()
        {
            return new ServiceResult() { IsSuccess = false, Errors = new List<string> { "در انجام عملیات خطایی رخ داد مجددا تلاش نمایید" } };
        }

        public static ServiceResult Error(List<string> errorMessages)
        {
            return new ServiceResult() { IsSuccess = false, Errors = errorMessages };
        }

        public static ServiceResult Okay(string message)
        {
            return new ServiceResult() { IsSuccess = true, Message = message };
        }

        public static ServiceResult Okay()
        {
            return new ServiceResult() { IsSuccess = true, Message = "عملیات با موفقیت صورت گرفت" };
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public static ServiceResult Okay(T data)
        {
            return new ServiceResult<T>() { IsSuccess = true, Message = "عملیات با موفقیت انجام شد", Data = data };
        }
    }

}
