using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace OnionArcApp.Application.Wrappers
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }
        public List<CustomValidationError> Errors { get; set; }
        public class CustomValidationError
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public CustomValidationError(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }
        public ServiceResponse(T value)
        {
            Value = value;
        }
        public ServiceResponse()
        {
            
        }
        public static ServiceResponse<T> SuccessResponse(T value)
        {
            return new ServiceResponse<T>(value)
            {
                Id = Guid.NewGuid(),
                Success = true,
                Message = "Success"

            };
        }

        public static ServiceResponse<T> FailureResponse(string message=null)
        {
            return new ServiceResponse<T>()
            {
                Id = Guid.NewGuid(),
                Message =message ?? "Failure",
                Success = false
            };
        }

        public static ServiceResponse<T> ValidationFailedResponse(List<ValidationFailure> validationFailures)
        {
            return new ServiceResponse<T>()
            {
                Id = Guid.NewGuid(),
                Success=false,
                Message = "Validation Failed!",
                Errors=validationFailures.Select(x => new CustomValidationError(x.PropertyName, x.ErrorMessage)).ToList(),
            };
        }
    }
}
