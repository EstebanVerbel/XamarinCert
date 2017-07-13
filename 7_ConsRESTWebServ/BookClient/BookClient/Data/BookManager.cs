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

        public Task<IEnumerable<Book>> GetAll()
        {
            // TODO: use GET to retrieve books
            throw new NotImplementedException();
        }

        public Task<Book> Add(string title, string author, string genre)
        {
            // TODO: use POST to add a book
            throw new NotImplementedException();
        }

        public Task Update(Book book)
        {
            // TODO: use PUT to update a book
            throw new NotImplementedException();
        }

        public Task Delete(string isbn)
        {
            // TODO: use DELETE to delete a book
            throw new NotImplementedException();
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

