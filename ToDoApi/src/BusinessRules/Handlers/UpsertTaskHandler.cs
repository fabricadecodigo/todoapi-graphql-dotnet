using System;
using ToDoApi.src.BusinessRules.Requests;
using ToDoApi.src.BusinessRules.Response;
using ToDoApi.src.BusinessRules.Validators;
using ToDoApi.src.Database.Domain;
using ToDoApi.src.Database.Repositories;

namespace ToDoApi.src.BusinessRules.Handlers
{
    public class UpsertTaskHandler : IUpsertTaskHandler
    {
        private readonly ITaskRepository _repository;
        private readonly ITaskValidator _validator;

        public UpsertTaskHandler(ITaskRepository repository, ITaskValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public UpsertTaskResponse Execute(UpsertTaskRequest request)
        {
            var validatorResult = _validator.Validate(request);
            if (!validatorResult.IsValid)
            {
                return new UpsertTaskResponse
                {
                    Errors = validatorResult.Errors
                };
            }

            Todo entity;

            if (request.Id.HasValue)
            {
                entity = _repository.GetById(request.Id.Value);
                if (entity == null)
                    throw new Exception("Tarefa não encontrada");
            }
            else
            {
                entity = new Todo();
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Done = request.Done;
            if (request.Done)
                entity.DtDone = DateTime.Now;
            else
                entity.DtDone = null;

            _repository.Save(entity);

            return new UpsertTaskResponse
            {
                Payload = new UpsertTaskResponsePayload
                {
                    Id = entity.Id.Value,
                    Title = entity.Title,
                    Description = entity.Description,
                    Done = entity.Done,
                    DtDone = entity.DtDone,
                }
            };
        }
    }
}