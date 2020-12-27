using System;
using System.Collections.Generic;
using RecipesSystem.Client.Client;
using RecipesSystem.Client.Model;
using RestSharp;

namespace RecipesSystem.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRecipesApi
    {
        /// <summary>
        /// Get All recepies 
        /// </summary>
        /// <returns>List&lt;RecipeDto&gt;</returns>
        List<RecipeDto> RecipesGet ();
        /// <summary>
        /// Get recepie by id 
        /// </summary>
        /// <param name="recepieId">Unique Id of Recepie</param>
        /// <returns>RecipeDto</returns>
        RecipeDto RecipesRecepieIdGet (int? recepieId);
        /// <summary>
        /// Updates or Creates recipe 
        /// </summary>
        /// <param name="recepieId"></param>
        /// <param name="body">Recipe to update</param>
        /// <returns></returns>
        void RecipesRecepieIdPost (string recepieId, RecipeDto body);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class RecipesApi : IRecipesApi
    {
        private string _token;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public RecipesApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RecipesApi(String basePath, string token)
        {
            this.ApiClient = new ApiClient(basePath);
            _token = token;
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// Get All recepies 
        /// </summary>
        /// <returns>List&lt;RecipeDto&gt;</returns>
        public List<RecipeDto> RecipesGet ()
        {
    
            var path = "/Recipes";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>{ { "Authorization", "Bearer " + _token } };
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer " };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RecipesGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RecipesGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<RecipeDto>) ApiClient.Deserialize(response.Content, typeof(List<RecipeDto>), response.Headers);
        }
    
        /// <summary>
        /// Get recepie by id 
        /// </summary>
        /// <param name="recepieId">Unique Id of Recepie</param>
        /// <returns>RecipeDto</returns>
        public RecipeDto RecipesRecepieIdGet (int? recepieId)
        {
            // verify the required parameter 'recepieId' is set
            if (recepieId == null) throw new ApiException(400, "Missing required parameter 'recepieId' when calling RecipesRecepieIdGet");
    
            var path = "/Recipes/{recepieId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "recepieId" + "}", ApiClient.ParameterToString(recepieId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String> { { "Authorization", "Bearer " + _token } };
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RecipesRecepieIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RecipesRecepieIdGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RecipeDto) ApiClient.Deserialize(response.Content, typeof(RecipeDto), response.Headers);
        }
    
        /// <summary>
        /// Updates or Creates recipe 
        /// </summary>
        /// <param name="recepieId"></param>
        /// <param name="body">Recipe to update</param>
        /// <returns></returns>
        public void RecipesRecepieIdPost (string recepieId, RecipeDto body)
        {
            // verify the required parameter 'recepieId' is set
            if (recepieId == null) throw new ApiException(400, "Missing required parameter 'recepieId' when calling RecipesRecepieIdPost");
    
            var path = "/Recipes/{recepieId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "recepieId" + "}", ApiClient.ParameterToString(recepieId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(body); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RecipesRecepieIdPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RecipesRecepieIdPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
