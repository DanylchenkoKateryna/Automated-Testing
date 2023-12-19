using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

[Binding]
public class ApiBookingSteps
{
    private RestClient client;
    private RestRequest request;
    private IRestResponse response;
    private const string baseUrl = "http://restful-booker.herokuapp.com/";
    public ApiBookingSteps()
    {
        client = new RestClient(baseUrl);
    }

    [Given(@"create Get All request ""(.*)""")]
    public void CreateGetAllRequest(string endpoint)
    {
        request = new RestRequest(endpoint, Method.GET);
    }

    [When(@"Send a GET ALl request")]
    public void WhenSendAGetAllRequest()
    {
        response = client.Execute(request);
    }

    [Then(@"the GET ALl response status code should be (.*)")]
    public void ThenTheGETALlResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        int actualStatusCode = (int)response.StatusCode;
        Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
    }

    [Then(@"the response should contain the booking details")]
    public void ThenTheResponseShouldContainTheBookingDetails()
    {
        JArray bookingDetails = JArray.Parse(response.Content);
        Assert.IsNotNull(bookingDetails, "Booking IDs not found in the response");
    }

    //-------------------------------------------------------------------------------

    [Given(@"create Get by Id request ""(.*)""")]
    public void CreateGetByIdRequest(string endpoint)
    {
        request = new RestRequest(endpoint, Method.GET);
        request.AddHeader("Accept", "application/json");
        request.RequestFormat = DataFormat.Json;
    }

    [When(@"Send a GET by Id request")]
    public void WhenSendAGetRequestTo()
    {
        response = client.Execute(request);
    }

    [Then(@"the Get by Id response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe200(int expectedStatusCode)
    {
        int actualStatusCode = (int)response.StatusCode;
        Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
    }

    [Then(@"the response should contain the specific booking details")]
    public void ThenTheResponseShouldContainTheSpecificBookingDetails()
    {
        JObject bookingDetails = JObject.Parse(response.Content);
        Assert.IsNotNull(bookingDetails, "Booking ID not found in the response");
    }

    //------------------------------------------------------------------
    [Given(@"the request body is a valid booking JSON")]
    public void GivenTheRequestBodyIsAValidBookingJSON()
    {
        var bookingJson = new
        {
            firstname = "John",
            lastname = "Doe",
            totalprice = 150,
            depositpaid = true,
            bookingdates = new
            {
                checkin = "2023-01-01",
                checkout = "2023-01-10"
            },
            additionalneeds = "Breakfast"
        };

        request = new RestRequest("/booking", Method.POST);
        request.AddHeader("Accept", "application/json");
        request.RequestFormat=DataFormat.Json;
        request.AddJsonBody(bookingJson);
    }

    [When(@"I send a POST request")]
    public void WhenISendAPOSTRequestTo()
    {
        response = client.Execute(request);
    }

    [Then(@"the Create response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        int actualStatusCode = (int)response.StatusCode;
        Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
    }

    [Then(@"the response should contain the booking ID")]
    public void ThenTheResponseShouldContainTheBookingID()
    {
     
        JObject bookingResponse = JObject.Parse(response.Content);
        Assert.IsNotNull(bookingResponse["bookingid"], "Booking ID not found in the response");
    }

    //--------------------------------------------------------------------------------------------------
    

    [Given(@"create put request ""(.*)""")]
    public void GivenCreatePutRequest(string endpoint)
    {
        var updatedBooking = new
        {
            firstname = "UpdatedFirstName",
            lastname = "UpdatedLastName",
            totalprice = 200,
            depositpaid = false,
            bookingdates = new
            {
                checkin = "2023-02-01",
                checkout = "2023-02-10"
            },
            additionalneeds = "No breakfast"
        };

        request = new RestRequest(endpoint, Method.PUT);
        request.AddHeader("Accept", "application/json");
        request.RequestFormat = DataFormat.Json;
        request.AddParameter("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=",ParameterType.HttpHeader);
        request.AddJsonBody(updatedBooking);
    }

    [When(@"send a PUT request")]
    public void WhenSendAPUTRequest()
    {
        response = client.Execute(request);
    }

    [Then(@"the Put response status code should be (.*)")]
    public void ThenThePutResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        int actualStatusCode = (int)response.StatusCode;
        Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
    }

    [Then(@"the response should contain the updated booking details")]
    public void ThenTheResponseShouldContainTheUpdatedBookingDetails()
    {
        JObject updatedBookingDetails = JObject.Parse(response.Content);
        Assert.AreEqual("UpdatedFirstName", updatedBookingDetails["firstname"].ToString());
        Assert.AreEqual("UpdatedLastName", updatedBookingDetails["lastname"].ToString());
        Assert.AreEqual(200, int.Parse(updatedBookingDetails["totalprice"].ToString()));
        Assert.AreEqual(false, bool.Parse(updatedBookingDetails["depositpaid"].ToString()));
        Assert.AreEqual("2023-02-01", updatedBookingDetails["bookingdates"]["checkin"].ToString());
        Assert.AreEqual("2023-02-10", updatedBookingDetails["bookingdates"]["checkout"].ToString());
        Assert.AreEqual("No breakfast", updatedBookingDetails["additionalneeds"].ToString());
    }
    //------------------------------------------------------------------------------------------
    [Given(@"create delete request ""(.*)""")]
    public void GivenCreateDeleteRequest(string endpoint)
    {
        request = new RestRequest(endpoint, Method.DELETE);
        request.AddParameter("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=", ParameterType.HttpHeader);
    }

    [When(@"send a DELETE request")]
    public void WhenSendADELETERequest()
    {
        response = client.Execute(request);
    }

    [Then(@"the delete response status code should be (.*)")]
    public void ThenTheDeleteResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        int actualStatusCode = (int)response.StatusCode;
        Assert.AreEqual(expectedStatusCode, actualStatusCode, $"Expected status code {expectedStatusCode}, but got {actualStatusCode}");
    }
}