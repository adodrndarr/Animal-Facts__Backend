using AnimalFacts.Domain.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;


namespace AnimalFacts.DataAccess.Repositories.Implementations
{
    public class CatDapperRepository : IRepository<Cat>
    {
        private readonly string _connection;
        public CatDapperRepository(string dbConnection)
        {
            this._connection = dbConnection;
        }


        public IEnumerable<Cat> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var cats = connection.Query<Cat>("select * from dbo.Cats");

                return cats;
            }
        }

        public Cat GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var cat = connection.QueryFirstOrDefault<Cat>(@"select * from dbo.Cats
                                                                where Id = @id", new { id });

                return cat;
            }
        }

        public void Insert(Cat entity)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                connection.Insert(entity);
            }
        }

        public void Update(Cat entity)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                connection.Update(entity);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var cat = GetById(id);

                connection.Delete(cat);
            }
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}