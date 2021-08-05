using ToDoApi.src.BusinessRules.Requests;
using ToDoApi.src.BusinessRules.Response;

namespace ToDoApi.src.BusinessRules.Handlers
{
    public interface IGetByIdTaskHandler
    {
       TaskResponse Execute(GetByIdTaskRequest request);  
    }
}