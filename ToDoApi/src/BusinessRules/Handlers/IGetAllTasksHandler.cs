using ToDoApi.src.BusinessRules.Response;

namespace ToDoApi.src.BusinessRules.Handlers
{
    public interface IGetAllTasksHandler
    {
         TasksResponse Execute();
    }
}