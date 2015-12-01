Feature: SingleNumberCalculator
	In order to calculate Yahtzee scores
	As a player
	I want to be told the score of a roll

Scenario Outline: Calculate rolls
	Given I have the roll '<roll>'
	And I use the calculator for '<type>'
	When I calculate the score
	Then the result should be <score>
	Examples:
	| roll      | type   | score |
	| 2,3,4,5,6 | Ones   | 0     |
	| 1,1,3,4,5 | Ones   | 2     |
	| 1,3,4,5,6 | Twos   | 0     |
	| 2,2,3,4,5 | Twos   | 4     |
	| 1,2,4,5,6 | Threes | 0     |
	| 3,3,5,6,6 | Threes | 6     |
	| 1,2,3,5,6 | Fours  | 0     |
	| 4,4,1,2,3 | Fours  | 8     |
	| 1,2,3,4,6 | Fives  | 0     |
	| 5,5,1,2,3 | Fives  | 10    |
	| 1,2,3,4,5 | Sixes  | 0     |
	| 6,6,1,2,3 | Sixes  | 12    |

