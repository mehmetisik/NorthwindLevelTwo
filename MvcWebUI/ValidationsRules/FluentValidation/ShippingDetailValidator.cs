using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValidationsRules.FluentValidation
{
    public class ShippingDetailValidator : AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(expression: s => s.FirstName).NotEmpty().WithMessage("Alan Gereklidir.");
            RuleFor(expression: s => s.FirstName).MinimumLength(2);
            RuleFor(expression: s=> s.LastName).NotEmpty();
            RuleFor(expression: S => S.Adress).NotEmpty();

            RuleFor(expression: S => S.City).NotEmpty().When(predicate: S=> S.Age < 18);

            RuleFor(expression: S => S.FirstName).Must(StartWithA);

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
