using System;
using System.Linq;
using ToDoApi.src.BusinessRules.Requests;
using ToDoApi.src.BusinessRules.Response;
using ToDoApi.src.Database.Repositories;

namespace ToDoApi.src.BusinessRules.Handlers
{
    public class GetByIdTaskHandler : IGetByIdTaskHandler
    {
        private readonly ITaskRepository _repository;

        public GetByIdTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public TaskResponse Execute(GetByIdTaskRequest request)
        {
            var task = _repository.GetById(request.Id);
            if (task == null)
                throw new Exception("Tarefa não encontrada");

            return new TaskResponse
            {
                Payload = new TaskResponseItem
                {
                    Id = task.Id.Value,
                    Title = task.Title,
                    Description = task.Description,
                    Done = task.Done,
                    DtDone = task.DtDone
                }
            };
        }
    }
}