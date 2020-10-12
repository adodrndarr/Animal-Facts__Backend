using AnimalFacts.DataAccess.Database;
using AnimalFacts.Domain.Entities;
using System.Collections.Generic;
using System.Linq;


namespace AnimalFacts.DataAccess.Repositories.Implementations
{
    public class RabbitEFRepository : IRepository<Rabbit>
    {
        private readonly AnimalsContext _db;
        public RabbitEFRepository(AnimalsContext context)
        {
            this._db = context;
        }
        
        
        public IEnumerable<Rabbit> GetAll()
        {
            var rabbits = _db.Rabbits;

            return rabbits;
        }

        public Rabbit GetById(int id)
        {
            var rabbit = _db.Rabbits.SingleOrDefault(r => r.Id == id);

            return rabbit;
        }

        public void Insert(Rabbit entity)
        {
            _db.Add(entity);
        }

        public void Update(Rabbit entity)
        {
            var rabbit = _db.Rabbits.SingleOrDefault(r => r.Id == entity.Id);
            rabbit.AddedOn = entity.AddedOn;
            rabbit.Fact = entity.Fact;
            rabbit.Source = entity.Source;
        }

        public void Delete(int id)
        {
            var rabbitToRemove = GetById(id);
            _db.Remove(rabbitToRemove);
        }

        public void SaveChanges() => _db.SaveChanges();
        
    }
}