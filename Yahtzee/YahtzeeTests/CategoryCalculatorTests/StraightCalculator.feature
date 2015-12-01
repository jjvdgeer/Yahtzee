Feature: StraightCalculator
	In order to calculate Yahtzee scores of straights
	As a player
	I want to be told the score of a roll

Scenario Outline: Calculate rolls
	Given I have the roll '<roll>'
	And I use the calculator for '<type>'
	When I calculate the score
	Then the result should be <score>
	Examples:
	| roll      | type          | score |
	| 1,2,3,4,6 | SmallStraight | 0     |
	| 1,2,3,4,5 | SmallStraight | 15    |
	| 1,2,3,4,6 | LargeStraight | 0     |
	| 2,3,4,5,6 | LargeStraight | 20    |