using FluentValidation;
using MvcUI.Models;

namespace MvcUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator : AbstractValidator<RegisterDto>
    {
        public ShippingDetailValidator()
        {
            RuleFor(expression: s => s.FirstName).NotEmpty();
            RuleFor(expression: s => s.FirstName).MinimumLength(2);
            RuleFor(expression: s => s.LastName).NotEmpty();
            RuleFor(expression: s => s.Password).NotEmpty();
            RuleFor(expression: s => s.City).NotEmpty();
            RuleFor(expression: s => s.Email).NotEmpty();


            //RuleFor(expression: s => s.City).NotEmpty().When(predicate:s => s.Age < 18);
            // RuleFor(expression: s => s.Address).Must(StartsWithA);
        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
