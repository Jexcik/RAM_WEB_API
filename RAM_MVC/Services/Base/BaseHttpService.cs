using RAM_MVC.Contracts;
using RAM_MVC.Services.Exceptions;
using System.Net.Http.Headers;

namespace RAM_MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService _storageService;

        protected IClient _client;
        public BaseHttpService(ILocalStorageService storageService, IClient client)
        {
            _storageService = storageService;
            _client = client;
        }
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid> { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, please try again.", Success = false };
            }
        }
        protected void AddBearerToken()
        {
            if (_storageService.Exists("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization 
                    = new AuthenticationHeaderValue("Bearer", _storageService.GetStorageValue<string>("token"));
            }
        }
    }
}
