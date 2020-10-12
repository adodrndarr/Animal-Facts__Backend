using AnimalFacts.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace AnimalFacts.DataAccess.Repositories.Implementations
{
    public class DogADORepository : IRepository<Dog>
    {
        private readonly string _connection;
        public DogADORepository(string dbConnection)
        {
            this._connection = dbConnection;
        }


        public IEnumerable<Dog> GetAll()
        {
            var dogs = new List<Dog>();

            SqlConnection connection = new SqlConnection(_connection);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"select * from dbo.Dogs;";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dogs.Add(
                    new Dog
                    {
                         AddedOn = (DateTime)reader["AddedOn"],
                         Fact = (string)reader["Fact"],
                         Source = (string)reader["Source"]
                    });
            }

            connection.Close();
            return dogs;
        }

        public Dog GetById(int id)
        {
            var dog = new Dog();

            SqlConnection connection = new SqlConnection(_connection);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"select * from dbo.Dogs
                                where Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dog = new Dog
                {
                    AddedOn = (DateTime)reader["AddedOn"],
                    Fact = (string)reader["Fact"],
                    Source = (string)reader["Source"]
                };
            }

            connection.Close();
            return dog;
        }

        public void Insert(Dog entity)
        {
            SqlConnection connection = new SqlConnection(_connection);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"insert into dbo.Dogs(AddedOn, Fact, Source)
                                values(@addedOn, @fact, @source)";

            cmd.Parameters.AddWithValue("@addedOn", entity.AddedOn);
            cmd.Parameters.AddWithValue("@fact", entity.Fact);
            cmd.Parameters.AddWithValue("@source", entity.Source);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Dog entity)
        {
            SqlConnection connection = new SqlConnection(_connection);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"update dbo.Dogs 
                                    set AddedOn = @addedOn,
                                        Fact = @fact, 
                                        Source = @source
                                where Id = @id";

            cmd.Parameters.AddWithValue("@addedOn", entity.AddedOn);
            cmd.Parameters.AddWithValue("@fact", entity.Fact);
            cmd.Parameters.AddWithValue("@source", entity.Source);
            cmd.Parameters.AddWithValue("@id", entity.Id);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connection);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"delete from dbo.Dogs 
                                where Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
