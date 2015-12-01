# Yahtzee

Implementation
Solve the assignment using C# and return the source code to us.
The implementation must contain a UI of any kind and enough tests to show that code works.
You can use either Visual Studio, MonoDevelop or Xamarin Studio to solve this assignment.
Estimated time to solve the assignment is a couple of hours.
Assignment
The game of yahtzee is a simple dice game. Each player rolls five six-sided dice. They can re-roll some
or all of the dice up to three times (including the original roll).
The player then places the result of the final roll in a category, such as ones, a pair, three of kind etc.
(see below). If the roll is compatible with the category, the player gets a score for the roll according
to the rules. If the roll is not compatible with the category, the player scores zero for the roll.
Your task is to implement a program to score a yahtzee-roll given a category.
Requirements
1. Create a class, YahtzeeScorer, with a method int Score(string roll, Category category) which can
score the category Ones. Given the roll “1,2,3,4,5” and the category ones, the method should
return 1.
2. In the following, always extend YahtzeeScorer. See scoring examples below. Start with Twos
3. Then Threes
4. Fours
5. Fives
6. Sixes
7. Continue with Pairs
8. Two-pairs
9. Three of a kind
10. Four of kind
11. Change things up a bit a support Small straight
12. Large straight
13. Full house
14. Chance
15. And lastly Yahtzee
16. Now, given a roll, create a method Score Max(string roll) which find the category and score
where the roll will yield the most points
Example Input
Ones, Twos, Threes, Fours, Fives, Sixes:
“1,2,3,2,5” placed on “twos” scores 4 (2+2)
Given “5,1,3,6,5” placed on “twos” scores 0
Chance:
The player scores the sum of all dice, no matter what they read.
1,1,3,3,6 placed on "chance" scores 14 (1+1+3+3+6)
4,5,5,6,1 placed on "chance" scores 21 (4+5+5+6+1)
Yahtzee:
If all dice have the same number, the player scores 50 points.
1,1,1,1,1 placed on "yahtzee" scores 50
1,1,1,2,1 placed on "yahtzee" scores 0
Pair:
The player scores the sum of the two highest matching dice.
3,3,3,4,4 scores 8 (4+4)
1,1,6,2,6 scores 12 (6+6)
Two pairs:
If there are two pairs of dice with the same number, the player scores the sum of these dice.
1,1,2,3,3 scores 8 (1+1+3+3)
Three of a kind:
If there are three dice with the same number, the player scores the sum of these dice.
3,3,3,4,5 scores 9 (3+3+3)
Four of a kind:
If there are four dice with the same number, the player scores the sum of these dice.
2,2,2,2,5 scores 8 (2+2+2+2)
Small straight:
When placed on "small straight", if the dice read 1,2,3,4,5, the player scores 15 (the sum of all the
dice.
Large straight:
When placed on "large straight", if the dice read 2,3,4,5,6, the player scores 20 (the sum of all the
dice).
Full house:
If the dice are two of a kind and three of a kind, the player scores the sum of all the dice.
1,1,2,2,2 scores 8 (1+1+2+2+2)
2,2,3,3,4 scores 0