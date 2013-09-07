# Code testing

I used Visual Studio 2012 and C# to implement following questions. For unit tests I used [nUnit](http://www.nunit.org/) framework (to launch nUnit tests in Visual Studio you need to have [nUnit test adapter](http://nunit.org/index.php?p=vsTestAdapter&r=2.6.2) or you can use [ReSharper](http://www.jetbrains.com/resharper/) to launch them).

## Problem #1

Given a vector of integers, find the longest consecutive sub-sequence of increasing numbers. If two sub-sequences have the same length, use the one that occurs first. An increasing sub-sequence must have a length of 2 or greater to qualify.

Example input:
	
	[1 0 1 2 3 0 4 5]

Result:

	[0 1 2 3]
    
### Answer

Function `FindSubsequence` is implemented in file [Problem1.cs](sources/HTest/Problem1.cs). Unit tests are implemented in [Problem1Suites.cs](sources/HTest.Suites/Problem1Suites.cs). 


## Problem #2

A tic-tac-toe board is represented by a two dimensional vector. X is represented by `x`, O is represented by `o`, and empty is represented by `e`. A player wins by placing three Xs or three Os in a horizontal, vertical, or diagonal row. Write a function which analyzes a tic-tac-toe board and returns `x` if X has won, `o` if O has won, and `nil` if neither player has won.

Example input:

	[[x e o]
	[x e e]
	[x e o]]

Result:

	x