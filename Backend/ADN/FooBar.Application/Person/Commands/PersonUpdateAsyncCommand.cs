using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FooBar.Application.Person.Commands
{
    public record PersonUpdateAsyncCommand(
        [Required] Guid Id,
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string Email,
        [Required] DateTime? DateOfBirth 
    ) : IRequest;

}
