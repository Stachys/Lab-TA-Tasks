﻿Feature: Olx
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@olx
Scenario Outline: Search for laptops with set minimum price and verify results
	Given I am on the main page
	When I search for laptops
	And set minimum price to <price>
	Then the results prices should be greater than or equal to <price>

	Examples: 
	| price |
	| 65000 |
