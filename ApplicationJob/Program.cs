

int start, end;
 void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
{
    //Assuming that list is sorted 
    //If list is not sorted we create sorted copy and work with it
    //list2 = list -> list2.Sort() and work with list2
    start = 0; //Assuming the sum doesn't exist
    end = 0;
    if (sum < list[0]) return; // Exception case 
    ulong _CurrentSum = 0; // Variable to compare with sum

    /* for (int i = 0; i < list.Count; i++)  //Get Index of the value that is right big after sum
     //Bad method with big lists (more precise than binary but longer time)
     {
         if (list[i] > sum) { _IndexBigThanSum = i; break; }
         else if (list[i] == sum) { start = i; end = i; break; }
     }*/

    end = list.Count - 1; //Preparing for binary search of sum
    uint mid = list[(start+end)/2]; // Mid value of binary search
    //while (val!=sum) // Binary search except we break if we found less value than sum
    if (list[end] > sum) //If sum less than highest value in list we minimize the range start-end (optimality)
    {
        while (start != end) // Binary search to minimize range start-end 
        { 
            mid = list[(start + end) / 2];
            if (mid < sum) //
            {
                start = ((start + end) / 2);
                // break;
            }
            if (mid > sum)
            {
                end = ((start + end) / 2) - 1;
            }
            if (mid == sum) return; //Best case
        }
    }
    //Finding start and end
    do //while the result != sum we keep calculating backwards and advancing end to the left
    {
        _CurrentSum = 0;
        for (start = end; start >= 0; start--) // start from the end (optimal end) till the beginning
        {
            _CurrentSum += list[start]; 
            if (_CurrentSum >= sum) break; // if already passed sum, we go for next end
        }
        if (_CurrentSum!=sum) end--; // go to next end
        if (end == 0) break; //no sum found
    }while(_CurrentSum!=sum);
    if ((end != 0) && (end<list.Count)) ++end; //Because we output the end excluded from our sum range so we add 1. As long as its not our of range
}

// Declaration and main function [I used VS 2022 that's why
List<uint> myList = new List<uint> ();
uint reader;
int k = 0;

//TESTING
//Reading input values to test
do
{
    Console.Write("Enter number [" + k.ToString() + "] : ");
    k++;
    reader = uint.Parse(Console.ReadLine());
    if (reader != 99 ) myList.Add(reader);
} while (reader != 99);
Console.Write("Enter sum : ");
uint summ = uint.Parse(Console.ReadLine());
FindElementsForSum(myList,summ,out start,out end);
Console.WriteLine("Start = " + start + "\nEnd = " + end);

// Output result and demonstration
string equation = "";
summ = 0;
for (int i = start; i < end; i++)
{
    equation += myList[i].ToString();
    summ += myList[i];
    Console.WriteLine("List[" + i + "] = " + myList[i]);
    if (i != end-1) equation += " + ";
}
Console.WriteLine(equation + " = " + summ);
// End of output