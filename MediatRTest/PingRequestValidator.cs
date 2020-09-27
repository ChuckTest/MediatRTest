using FluentValidation;

namespace MediatRTest
{
    /// <summary>
    /// https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.API/Application/Validations/CreateOrderCommandValidator.cs
    /// </summary>
    public class PingRequestValidator : AbstractValidator<PingRequest>, IValidator<PingRequest>
    {
        public PingRequestValidator()
        {
            RuleFor(command => command.Name).NotNull().NotEmpty();
        }
    }
}
