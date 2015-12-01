Feature: PairCalculator
	In order to calculate Yahtzee scores of yahtzee
	As a player
	I want to be told the score of a roll

Scenario Outline: Calculate rolls
	Given I have the roll '<roll>'
	And I use the calculator for '<type>'
	When I calculate the score
	Then the result should be <score>
	Examples:
	| roll      | type    | score |
	| 1,2,3,4,5 | Yahtzee | 0     |
	| 1,1,1,1,1 | Yahtzee | 50    |