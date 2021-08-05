using System.Linq;
using ToDoApi.src.BusinessRules.Response;
using ToDoApi.src.Database.Repositories;

namespace ToDoApi.src.BusinessRules.Handlers
{
    public class GetAllTasksHandler : IGetAllTasksHandler
    {
        private readonly ITaskRepository _repository;

        public GetAllTasksHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public TasksResponse Execute()
        {
            var tasks = _repository.GetAll()
                .Select(q => new TaskResponseItem
                {
                    Id = q.Id.Value,
                    Title = q.Title,
                    Description = q.Description,
                    Done = q.Done,
                    DtDone = q.DtDone
                })
                .ToList();

            return new TasksResponse
            {
                Payload = tasks
            };
        }
    }
}