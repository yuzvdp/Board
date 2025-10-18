using Board.Contracts.Adverts;
using FluentValidation;

namespace Board.AppServices.Validators
{
    public class CreateAdvertValidator : AbstractValidator<CreateAdvertDto>
    {
        public CreateAdvertValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Не указан заголовок.")
            .Length(3, 50)
            .WithMessage("Заголовок должен иметь длину от 3 до 50.");

            //RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Не указано имя пользователя.");
            //RuleFor(x => x.Username).Length(3, 20).WithMessage("Имя пользователя должно иметь длину от 3 до 20.");
            //RuleFor(x => x.Username).Matches("^[^!@#]*$").WithMessage("Имя пользователя не должно содержать символы !@#.");

            //RuleFor(x => x.CategoryTitle).NotNull().NotEmpty().WithMessage("Не указана категория.");
            //RuleFor(x => x.CategoryTitle).Length(3, 20).WithMessage("Категория должно иметь длину от 3 до 20.");
            //RuleFor(x => x.CategoryTitle).Matches("^[^!@#]*$").WithMessage("Категория не должна содержать символы !@#.");
            // надо ли проверять стринги?)))
            // как то надо бы проверять ID вложенных сущностей, существуют ли такие в БД
        }

    }
}
