using System;
using System.Linq;
using ToDoApi.src.Database.Domain;

namespace ToDoApi.src.Database.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoContext _db;

        public TaskRepository(TodoContext db) => _db = db;
        
        public IQueryable<Todo> GetAll()
        {
            return _db.Tasks.AsQueryable();
        }

        public Todo GetById(Guid Id)
        {
            return _db.Tasks.SingleOrDefault(q => q.Id == Id);
        }

        public Todo Save(Todo entity)
        {
            if (!entity.Id.HasValue)
            {
                entity.Id = Guid.NewGuid();
                _db.Tasks.Add(entity);
            }

            _db.SaveChanges();

            return entity;
        }
    }
}