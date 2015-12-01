Feature: TwoPairCalculator
	In order to calculate Yahtzee scores of double pairs
	As a player
	I want to be told the score of a roll

Scenario Outline: Calculate rolls
	Given I have the roll '<roll>'
	And I use the calculator for '<type>'
	When I calculate the score
	Then the result should be <score>
	Examples:
	| roll      | type      | score |
	| 1,2,3,4,5 | TwoPairs  | 0     |
	| 1,1,2,3,4 | TwoPairs  | 0     |
	| 1,1,2,2,3 | TwoPairs  | 6     |
	| 1,1,1,1,2 | TwoPairs  | 4     |
	| 1,1,1,1,1 | TwoPairs  | 4     |
	| 1,1,1,2,2 | TwoPairs  | 6     |
	| 1,2,3,4,5 | FullHouse | 0     |
	| 1,1,1,2,3 | FullHouse | 0     |
	| 1,1,1,2,2 | FullHouse | 7     |
