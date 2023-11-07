using FluentValidation;
using ReceivablesManagement.Business.DTOs;

namespace ReceivablesManagement.Business.Validation
{
    public class ReceivableDTOValidator: AbstractValidator<ReceivableDTO>
	{
		public ReceivableDTOValidator()
		{
			RuleFor(model => model.Reference)
				.NotEmpty().WithMessage("Reference is empty")
				.MaximumLength(30).WithMessage("Reference is longer than 30 characters");

			RuleFor(model => model.CurrencyCode)
				.NotEmpty().WithMessage("Currency code is empty");

			RuleFor(model => model.IssueDate)
				.Must(IsValidDate)
				.WithMessage("Invalid date format");

		}

        private bool IsValidDate(string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime result))
            {
                return true;
            }

            return false;
        }
    }
}

