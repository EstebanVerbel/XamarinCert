using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookClient.Data
{
    public class BookManager
    {
        #region -- Members --

        private const string Url = "http://xam150.azurewebsites.net/api/books/";
        private string _authorizationKey;

        #endregion

        #region -- Public Methods --

        public async Task<IEnumerable<Book>> GetAll()
        {
            // TODO: use GET to retrieve books
            HttpClient client = await GetClient();

            // get books from web service
            string allBooks = await client.GetStringAsync(Url);
            // deserialize string into list of books
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(allBooks);

            return books;
        }

        public async Task<Book> Add(string title, string author, string genre)
        {
            // TODO: use POST to add a book
            Book newBook = new Book()
            {
                ISBN = "",
                Title = title,
                Authors = new List<string> { author },
                Genre = genre,
                PublishDate = DateTime.Now
            };

            HttpClient client = await GetClient();
            
            // serialize book object
            string jsonBook = JsonConvert.SerializeObject(newBook);
            // create content of post request
            HttpContent content = new StringContent(jsonBook, Encoding.UTF8, "application/json");

            // send post to web service
            HttpResponseMessage response = await client.PostAsync(Url, content);
            string responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Book>(responseString);
        }

        public async Task Update(Book book)
        {
            // TODO: use PUT to update a book
            HttpClient client = await GetClient();

            string jsonBook = JsonConvert.SerializeObject(book);
            HttpContent content = new StringContent(jsonBook, Encoding.UTF8, "application/json");

            await client.PostAsync($"{Url}{book.ISBN}", content);
        }

        public async Task Delete(string isbn)
        {
            // TODO: use DELETE to delete a book
            HttpClient client = await GetClient();

            await client.DeleteAsync($"{Url}{isbn}");
        }

        #endregion

        #region -- Private Methods --

        private async Task<HttpClient> GetClient()
        {
            HttpClient httpClient = new HttpClient();

            // get authorization key only if it is the first time we're making a call to the web service
            if (string.IsNullOrEmpty(_authorizationKey))
            {
                _authorizationKey = await httpClient.GetStringAsync($"{Url}login");
                _authorizationKey = JsonConvert.DeserializeObject<string>(_authorizationKey);
            }

            // adds authorization key (token) to httpclient 
            httpClient.DefaultRequestHeaders.Add("Authorization", _authorizationKey);
            // this header is added so that all of the responses are returned as json
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            return httpClient;
        }

        #endregion

    }
}

