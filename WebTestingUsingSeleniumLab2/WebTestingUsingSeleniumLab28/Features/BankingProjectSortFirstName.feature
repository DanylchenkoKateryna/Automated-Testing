@setup_feature
Feature: Sort First Name

Scenario: Simple sorting first name
	When click on the First Name title
	Then the users should be sorted alphabetically by first name
	
