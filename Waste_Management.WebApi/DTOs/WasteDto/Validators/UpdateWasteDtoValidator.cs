using FluentValidation;

namespace Waste_Management.WebApi.DTOs.WasteDto.Validators
{
    public class UpdateWasteDtoValidator : AbstractValidator<WasteLIstDto>
    {
        public UpdateWasteDtoValidator()
        {
            RuleFor(w => w.Type).NotEmpty().WithMessage("نوع پسماند اجباری است").NotNull().WithMessage("نوع پسماند اجباری است").MinimumLength(1).WithMessage("نوع پسماند باید بیشتر از 1 نویسه داشته باشد").MaximumLength(20).WithMessage("نوع پسماد باید کمتر از 20 نویسه باشد");
            RuleFor(w => w.Value).NotEmpty().WithMessage("مقدار پسماند نباید خالی باشد").NotNull().WithMessage("مقدار پسماند نباید خالی باشد").LessThan(100000).WithMessage("مقدار پسماند باید کمتر از 100 هزار گرم باشد").GreaterThan(100).WithMessage("مقدار پسماند باید بیشتر از 100 گرم باشد");
            RuleFor(w => w.Id).NotEmpty().WithMessage("شناسه نباید خالی باشد").NotNull().WithMessage("شناسه نباید خالی باشد");
        }
    }
}
