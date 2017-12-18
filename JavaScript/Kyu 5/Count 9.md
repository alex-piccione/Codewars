# count '9's from 1 to n

https://www.codewars.com/kata/count-9-s-from-1-to-n

## Description

It's 9 time!

I want to count from 1 to n. How many times will I use a '9'?

9, 19, 91.. will contribute one '9' each, 99, 199, 919.. wil contribute two '9's each...etc

Note: n will always be a postive integer.

```
number9(8) //should return 0
number9(9) //should return 1
number9(10) //should return 1
number9(98) //should return 18
number9(100) //should return 20
```


## Solution explained

trying to reduce the problem to small parts I consider that for every number composed by N digits
at least all the possibilities for a number with less one number of digits should be counted  
Here it is, for NNN for sure we have to pass through all the number from 0 to NN  
If XNN is composed by zeros apart from the first digit
we can say that for XNN we have for sure pass X times through NN  
For 400 we passed 4 times through the numbers between 0 and 99, only the first digit changed but the occurrences of "9" was the same
for every repetition (from 00 to 99, then from 100 to 199 and so on)  
  
for number composed only by zeros  
about 10, 100, 1000 and their multiplies like 200, 400, 5000  
there is a simple rules that we can call "zeros formula"  
multiply the power of 10 elevated for the number of digits before the first one diminuited by one for the number of digits before the first one.  
  
multiply the result for the number represented by the fisrt digit and add one in case it is 9
Examples:  
100 will be 1 * 2 * 10^1  
300 will be 3 * 2 * 10^1  
900 will be 9 * 2 * 10^1 + 1

using this basic rule we can calculate the total occurrences for numbers that are not composed only by zeros
just sum the single parts
for example 10450 contains the occurrenced in 10000 plus the occurrences of 400 and then of 50
123 contains the occurrences of 100 plus 20 plus 3   

the explanation is that we have explored all the combination of a bigger part and then we have extranumbers to explore
In case of 123 we have explored all the possibilities untile the 100, then we have to consider the remaining numbers from 101 to 123
that means that we can use 20 with the formula that just consider the zeros
so we have the occurrences for 20 (from 101 to 120) and then remain the 3  
  
There is an exception when the number contain one or more 9 in the greater parts of the one we are considering
for example in 923 after the sum of occurrences for 900, when we calculate the occurrences for the 20 we have to consider 
that for every number we have an extra 9 (actually it is for nember from 901 to 920)  
so we have to add also an extra counter for the 23 occurrences after the 900 where a "9" should be counted
add the number that we have using only the right part of the full number after the digit we are considering
adding an extra one permits to remove the "+1" rule from the generic "zeros formula" in case of first digit like "9"  
  
923 is 9 * 2 * 10^1 for the "900" part + 1 plus 2 * 2 * (10^1 + 1) for "20" part and 3 * 0 * 1 for the "3" part
the "20" part changed from the basic 2 * 2 * 10^1 because we have to consider the "9" from 900 that is present on every iteration






