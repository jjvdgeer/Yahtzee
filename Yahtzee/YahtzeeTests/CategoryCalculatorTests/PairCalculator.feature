Feature: PairCalculator
	In order to calculate Yahtzee scores of pairs
	As a player
	I want to be told the score of a roll

Scenario Outline: Calculate rolls
	Given I have the roll '<roll>'
	And I use the calculator for '<type>'
	When I calculate the score
	Then the result should be <score>
	Examples:
	| roll      | type | score |
	| 1,1,2,3,4 | Pair | 2     |
	| 1,2,3,4,5 | Pair | 0     |
	| 1,1,1,2,3 | Pair | 2     |
