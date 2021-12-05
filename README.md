# FindElementsForSum
 TaskForJob
Task Description : 


Given List <uint> list and some ulong sum. The expected number of items in list is several million.
You need to write a FindElementsForSum method that can find the smallest start and end indices such that the sum of the list items starting from the start index inclusive and up to the end index inclusive will be exactly equal to sum. If no such start and end can be found, then set start and end to 0. Provide the solution as a method. The signal and the name of the method cannot be changed, only the body.

public void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
{
          // your code here
}

Examples:
FindElementsForSumTest (new List <uint> {0, 1, 2, 3, 4, 5, 6, 7}, 11, out start, out end); // start will be 5 and end 7;
FindElementsForSumTest (new List <uint> {4, 5, 6, 7}, 18, out start, out end); // start will be 1 and end 4;
FindElementsForSumTest (new List <uint> {0, 1, 2, 3, 4, 5, 6, 7}, 88, out start, out end); // start will be 0 and end 0;