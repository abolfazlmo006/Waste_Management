using FluentValidation;

namespace Waste_Management.WebApi.DTOs.ExhibitorDto.Validators
{
    public class CreateRequestExhibitorDtoValidator : AbstractValidator<CreateRequestExhibitorDto>
    {
        public CreateRequestExhibitorDtoValidator()
        {
            RuleFor(e => e.Address).NotEmpty().WithMessage("آدرس محل زندگی نباید خالی باشد").NotNull().WithMessage("آدرس محل زندگی نباید خالی باشد").MinimumLength(6).WithMessage("آدرس محل زندگی باید بیشتر از 6 نویسه باشد").MaximumLength(50).WithMessage("آدرس محل زندگی باید کمتر از 50 نویسه باشد");
        }
        
    }
}
