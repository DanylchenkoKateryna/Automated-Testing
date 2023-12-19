Feature: Testing Web API Booking

  Scenario: Retrieve All Booking Details
    Given create Get All request "/booking"
    When Send a GET ALl request
    Then the GET ALl response status code should be 200
    And the response should contain the booking details

  Scenario: Retrieve Specific Booking Details
    Given create Get by Id request "/booking/1115"
    When Send a GET by Id request
    Then the Get by Id response status code should be 200
    And the response should contain the specific booking details

  Scenario: Create a New Booking
    Given the request body is a valid booking JSON
    When I send a POST request
    Then the Create response status code should be 200
    And the response should contain the booking ID

  Scenario: Update Booking Details
    Given create put request "/booking/388"
    When send a PUT request
    Then the Put response status code should be 200
    And the response should contain the updated booking details

  Scenario: Delete Booking Details
    Given create delete request "/booking/1645"
    When send a DELETE request
    Then the delete response status code should be 201