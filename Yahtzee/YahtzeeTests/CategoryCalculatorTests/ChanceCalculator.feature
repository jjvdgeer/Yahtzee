Feature: ChanceCalculator
	In order to calculate Yahtzee scores of chance
	As a player
	I want to be told the score of a roll

Scenario Outline: Calculate rolls
	Given I have the roll '<roll>'
	And I use the calculator for '<type>'
	When I calculate the score
	Then the result should be <score>
	Examples:
	| roll      | type   | score |
	| 1,1,1,1,1 | Chance | 5     |
	| 1,2,3,4,5 | Chance | 15    |