Feature: Yahoo
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@search
Scenario Outline: Verify that key word found on the first page
	Given I am on the main yahoo page
	When I search for '<search>'
	Then '<find>' should be found on the first page

	Examples: 
	| search                         | find                         |
	| Ooga anisotropic polycarbonate | Taking control of anisotropy |

@search
Scenario Outline: Verify that key word found not on the first page
	Given I am on the main yahoo page
	When I search for '<search>'
	Then '<find>' should be found not on the first page

	Examples: 
	| search                         | find                      |
	| Ooga anisotropic polycarbonate | Shin-Etsu Polymer America |

@search
Scenario Outline: Verify that key word wasn't found
	Given I am on the main yahoo page
	When I search for '<search>'
	Then '<find>' should not be found

	Examples: 
	| search                         | find                   |
	| Ooga anisotropic polycarbonate | JHFkjhdskjhfkjjgsajgfg |

