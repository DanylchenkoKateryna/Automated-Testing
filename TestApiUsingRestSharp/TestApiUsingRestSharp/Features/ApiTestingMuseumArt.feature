Feature: Testing Web API The Metropolitan Museum of Art Collection

  Scenario: Get Art Collection
    Given create Get Art Collection request "/public/collection/v1/objects?departmentIds=1"
    When Send a GET Art Collection request
    Then the GET Art Collection response status code should be 200
    And the response should contain the Art Collection details

  Scenario: Get Art 
    Given create Get Art request "/public/collection/v1/objects/1"
    When Send a GET Art request
    Then the GET Art response status code should be 200
    And the response should contain the Art details

  Scenario: Get Departments 
    Given create Get Departments request "/public/collection/v1/departments"
    When Send a GET Departments request
    Then the GET Departments response status code should be 200
    And the response should contain the Departments details

  Scenario: Get Search query within the object’s data 
    Given create Get Search request "/public/collection/v1/search?dateBegin=1700&dateEnd=1800&q=African"
    When Send a GET Search request
    Then the GET Search response status code should be 200
    And the response should contain the Search details