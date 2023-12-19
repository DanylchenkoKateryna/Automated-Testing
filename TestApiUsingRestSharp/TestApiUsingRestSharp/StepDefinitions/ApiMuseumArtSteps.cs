using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace TestApiUsingRestSharp.StepDefinitions
{

    [Binding]
    public class ApiMuseumArtSteps
    {
        private RestClient client;
        private RestRequest request;
        private IRestResponse response;
        private const string baseUrl = "https://collectionapi.metmuseum.org/";
        public ApiMuseumArtSteps()
        {
            client = new RestClient(baseUrl);
        }

        [Given(@"create Get Art Collection request ""(.*)""")]
        public void CreateGetAllRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.GET);
        }

        [When(@"Send a GET Art Collection request")]
        public void WhenSendAGetAllRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"the GET Art Collection response status code should be (.*)")]
        public void ThenTheGETALlResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            int actualStatusCode = (int)response.StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
        }

        [Then(@"the response should contain the Art Collection details")]
        public void ThenTheResponseShouldContainTheArtCollectionsDetails()
        {
            JObject museumDetails = JObject.Parse(response.Content);
            Assert.IsNotNull(museumDetails, "Art IDs not found in the response");
        }
        //----------------------------------------------------------------------------

        [Given(@"create Get Art request ""(.*)""")]
        public void CreateGetArtRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.GET);
        }

        [When(@"Send a GET Art request")]
        public void WhenSendAGetArtRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"the GET Art response status code should be (.*)")]
        public void ThenTheGETArtResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            int actualStatusCode = (int)response.StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
        }

        [Then(@"the response should contain the Art details")]
        public void ThenTheResponseShouldContainTheArtDetails()
        {
            JObject museumDetails = JObject.Parse(response.Content);
            Assert.IsNotNull(museumDetails, "Art ID not found in the response");
        }
        //-------------------------------------------------------------
        [Given(@"create Get Departments request ""(.*)""")]
        public void CreateGetDepartmentsRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.GET);
        }

        [When(@"Send a GET Departments request")]
        public void WhenSendAGetDepartmentsRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"the GET Departments response status code should be (.*)")]
        public void ThenTheGETDepartmentsResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            int actualStatusCode = (int)response.StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
        }

        [Then(@"the response should contain the Departments details")]
        public void ThenTheResponseShouldContainTheDepartmentsDetails()
        {
            JObject museumDetails = JObject.Parse(response.Content);
            Assert.IsNotNull(museumDetails, "Departments IDs not found in the response");
        }
        //---------------------------------------------------------------------------
        [Given(@"create Get Search request ""(.*)""")]
        public void CreateGetSearchRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.GET);
        }

        [When(@"Send a GET Search request")]
        public void WhenSendAGetSearchRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"the GET Search response status code should be (.*)")]
        public void ThenTheGETSearchResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            int actualStatusCode = (int)response.StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
        }

        [Then(@"the response should contain the Search details")]
        public void ThenTheResponseShouldContainTheSearchDetails()
        {
            JObject museumDetails = JObject.Parse(response.Content);
            Assert.IsNotNull(museumDetails, "Search IDs not found in the response");
        }
    }
}
