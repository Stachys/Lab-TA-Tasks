Feature: AliExpress
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@aliexpress
Scenario Outline: Search for laptops with set minimum price and verify results
	Given I am on the main page
	When I sign in
	And I search for laptops
	And set minimum price to <price>
	Then the results prices should be greater than or equal to <price>

	Examples: 
	| price |
	| 65000 |
