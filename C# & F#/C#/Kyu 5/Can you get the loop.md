# Can you get the loop ?

https://www.codewars.com/kata/52a89c2ea8ddc5547a000863/csharp

## Description:  
You are given a node that is the beginning of a linked list.  
This list contains a dangling piece and a loop. Your objective is to determine the length of the loop.  
  
For example in the following picture the size of the dangling piece is 3 and the loop size is 12:  
![../images/Can_you_get_the_loop_1]

  
Use the _next_ method to get the following node.  
``node.next``  

## Notes:

- do NOT mutate the nodes!
- in some cases there can be just a loop, with no dangling piece.