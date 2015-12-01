Feature: GetMaxScore
	In order to calculate Yahtzee scores
	As a player
	I want to be told the highest score I can get from a roll

Scenario Outline: Calculate max score
	Given I have the roll '<roll>'
	When I calculate the maximum score
	Then the result should be <score>
	And the category should be one of <types>
	Examples:
	| roll      | score | types   |
	| 1,2,3,5,6 | 17    | Chance  |
	| 1,1,1,1,1 | 50    | Yahtzee |

Scenario Outline: Calculate max score without chance
	Given I have the roll '<roll>'
	When I calculate the maximum score without chance
	Then the result should be <score>
	And the category should be one of <types>
	Examples:
	| roll      | score | types                     |
	| 1,2,3,5,6 | 6     | Sixes                     |
	| 1,1,1,1,1 | 50    | Yahtzee                   |
	| 1,2,3,4,5 | 15    | SmallStraight             |
	| 2,3,4,5,6 | 20    | LargeStraight             |
	| 6,6,2,3,4 | 12    | Sixes,Pair                |
	| 6,6,6,2,3 | 18    | Sixes,ThreeOfAKind        |
	| 6,6,6,6,1 | 24    | Sixes,FourOfAKind,TwoPair |
	| 2,2,2,3,3 | 12    | FullHouse                 |
