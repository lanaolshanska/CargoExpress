using Delivery.BL.Contracts;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Validators
{
    public class BaseValidator<TModel, T> : AbstractValidator<TModel> where TModel : class 
                                                                      where T : class
    {
        protected const int CustomMaxLength = 50;
        protected const int MaxLength = 255;
        protected const int MinYearRange = 1900;
        protected const int MaxYearRange = 2019;
        protected const int Zero = 0;

        protected const string RegExpForDigits = "^[0-9]+$";
        protected const string RegExpForChars = @"^([a-zA-Z]+\s)*[a-zA-Z]+$";
        protected const string RegExpForPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,}$";

        private readonly IBaseService<T> _service;

        public BaseValidator(IBaseService<T> service)
        {
            _service = service;
        }

        protected async Task<bool> IsExistAsync(int id, CancellationToken token)
        {
            return await _service.GetByIdAsync(id) != null;
        }

        protected bool IsValidDate(string value)
        {
            DateTime date;      
            return DateTime.TryParse(value, out date);
        }
    }
}