using People.Models;
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
        private static PersonRepository instance;
        public static PersonRepository Instance
        {
            get
            {
                if (instance == null)
                    throw new Exception("You must call Initialize before retrieving the singleton for the PersonRepository.");

                return instance;
            }
        }

        public static void Initialize(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));

            // TODO: dispose any existing connection

            instance = new PersonRepository(filename);
        }

        public string StatusMessage { get; set; }

        private PersonRepository(string dbPath)
        {
            // TODO: Initialize a new SQLiteConnection

            // TODO: Create the Person table

        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: insert a new person into the Person table

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public IEnumerable<Person> GetAllPeople()
        {
            try
            {
                // TODO: return the Person table in the database

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return Enumerable.Empty<Person>();
        }
    }
}
