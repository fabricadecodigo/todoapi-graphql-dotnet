using FluentValidation;
using ToDoApi.src.BusinessRules.Requests;

namespace ToDoApi.src.BusinessRules.Validators
{
    public interface ITaskValidator : IValidator<UpsertTaskRequest>
    {
         
    }
}