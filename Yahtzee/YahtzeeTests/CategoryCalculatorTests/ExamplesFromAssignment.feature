Feature: AssignmentExamples
	In order to verify the assignment is done
	As a programmer
	I want to be sure all the examples work

Scenario Outline: Calculate rolls
	Given I have the roll '<roll>'
	And I use the calculator for '<type>'
	When I calculate the score
	Then the result should be <score>
	Examples:
	| roll      | type          | score |
	| 1,2,3,2,5 | Twos          | 4     |
	| 5,1,3,6,5 | Twos          | 0     |
	| 1,1,3,3,6 | Chance        | 14    |
	| 4,5,5,6,1 | Chance        | 21    |
	| 1,1,1,1,1 | Yahtzee       | 50    |
	| 1,1,1,2,1 | Yahtzee       | 0     |
	| 3,3,3,4,4 | Pair          | 8     |
	| 1,1,6,2,6 | Pair          | 12    |
	| 1,1,2,3,3 | TwoPairs      | 8     |
	| 3,3,3,4,5 | ThreeOfAKind  | 9     |
	| 2,2,2,2,5 | FourOfAKind   | 8     |
	| 1,2,3,4,5 | SmallStraight | 15    |
	| 2,3,4,5,6 | LargeStraight | 20    |
	| 1,1,2,2,2 | FullHouse     | 8     |
	| 2,2,3,3,4 | FullHouse     | 0     |