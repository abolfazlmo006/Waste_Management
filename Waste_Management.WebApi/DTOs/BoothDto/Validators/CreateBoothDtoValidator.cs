using FluentValidation;

namespace Waste_Management.WebApi.DTOs.BoothDto.Validators
{
    public class CreateBoothDtoValidator : AbstractValidator<CreateBoothDto>
    {
        public CreateBoothDtoValidator()
        {
            RuleFor(b=> b.Name).NotEmpty().WithMessage("نام غرفه نباید خالی باشد").NotNull().WithMessage("نام غرفه نباید خالی باشد").MaximumLength(30).WithMessage("نام غرفه باید کمتر از 30 نویسه باشد").MinimumLength(4).WithMessage("نام غرفه باید بیشتر از 4 نویسه باشد");
            RuleFor(b => b.Address).NotEmpty().WithMessage("آدرس غرفه نباید خالی باشد").NotNull().WithMessage("آدرس غرفه نباید خالی باشد").MinimumLength(6).WithMessage("آدرس غرفه باید بیشتر از 6 نویسه باشد").MaximumLength(50).WithMessage("آدرس غرفه باید کمتر از 50 نویسه باشد");
        }
    }
}
