using HotChocolate;
using ToDoApi.src.BusinessRules.Handlers;
using ToDoApi.src.BusinessRules.Requests;
using ToDoApi.src.BusinessRules.Response;

namespace ToDoApi.src.Api
{
    public class Query
    {
        public TasksResponse GetTasks([Service] IGetAllTasksHandler handler)
        {
            return handler.Execute();
        }

        public TaskResponse GetTask([Service] IGetByIdTaskHandler handler, GetByIdTaskRequest request)
        {
            return handler.Execute(request);
        }
    }
}