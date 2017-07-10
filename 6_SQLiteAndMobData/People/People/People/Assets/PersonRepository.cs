using People.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Assets
{
    public sealed class PersonRepository
    {
        // Singleton of the database repository object.
        private static PersonRepository _instance;
        // database connection
        private SQLiteAsyncConnection _connection;
        
        public static PersonRepository Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("You must call Initialize before retrieving the singleton for the PersonRepository.");

                return _instance;
            }
        }

        public static void Initialize(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));

            // TODO: dispose any existing connection
            if (_instance != null)
                _instance._connection.GetConnection().Dispose();

            _instance = new PersonRepository(filename);
        }

        public string StatusMessage { get; set; }

        private PersonRepository(string dbPath)
        {
            // TODO: Initialize a new SQLiteConnection
            _connection = new SQLiteAsyncConnection(dbPath);

            // TODO: Create the Person table
            _connection.CreateTableAsync<Person>().Wait();
        }

        public async Task AddNewPersonAsync(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: insert a new person into the Person table
                result = await _connection.InsertAsync(new Person { Name = name });
                
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            try
            {
                // TODO: return the Person table in the database
                return await _connection.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Failed to retrieve data. {ex.Message}");
            }

            return Enumerable.Empty<Person>();
        }
    }
}
