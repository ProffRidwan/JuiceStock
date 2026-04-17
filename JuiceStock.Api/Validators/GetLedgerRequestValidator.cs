
using FluentValidation;
using JuiceStock.Api.Contracts.Ledger;
using JuiceStock.Domain.Enums;
namespace JuiceStock.Api.Validators
{
    public class GetLedgerRequestValidator : AbstractValidator<GetLedgerRequest>
    {
        public GetLedgerRequestValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100);

            RuleFor(x => x)
                .Must(x => !x.StartDate.HasValue || !x.EndDate.HasValue || x.StartDate <= x.EndDate)
                .WithMessage("StartDate must be less than or equal to EndDate");
        }
    }
}
