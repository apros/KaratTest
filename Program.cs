using System;
using System.Collections.Generic;
using System.Linq;

namespace KaratTest
{
    class Program
    {

        /*
        Suppose we have some input data describing a graph of relationships between parents and children over multiple generations. The data is formatted as a list of (parent, child) pairs, where each individual is assigned a unique integer identifier.

        For example, in this diagram, 3 is a child of 1 and 2, and 5 is a child of 4:

        1   2    4
         \ /   / | \
          3   5  8  9
           \ / \     \
            6   7    11


        Sample input/output (pseudodata):

        parentChildPairs = [
            (1, 3), (2, 3), (3, 6), (5, 6),
            (5, 7), (4, 5), (4, 8), (4, 9), (9, 11)
        ]


        Write a function that takes this data as input and returns two collections: one containing all individuals with zero known parents, and one containing all individuals with exactly one known parent.


        Output may be in any order:

        findNodesWithZeroAndOneParents(parentChildPairs) => [
          [1, 2, 4],       // Individuals with zero parents
          [5, 7, 8, 9, 11] // Individuals with exactly one parent
        ]
        */
        class Solution
        {
            static void Main(String[] args)
            {
                var parentChildPairs = new List<int[]>() {
            new int[]{1, 3},
            new int[]{2, 3},
            new int[]{3, 6},
            new int[]{5, 6},
            new int[]{5, 7},
            new int[]{4, 5},
            new int[]{4, 8},
            new int[]{4, 9},
            new int[]{9, 11}
        };

                var outList = findParents(parentChildPairs);

                Console.WriteLine("List with Zero parents:");
                foreach (var index in outList[0])
                {
                    Console.WriteLine(index);
                }

                Console.WriteLine("List with One parents:");
                foreach (var index in outList[1])
                {
                    Console.WriteLine(index);
                }


            }

            static List<List<int>> findParents(List<int[]> parentChilds)
            {
                var result = new List<List<int>>();
                result.Add(new List<int>());
                result.Add(new List<int>());

                var tempCounterList = new Dictionary<int, int>();

                foreach (var arr in parentChilds)
                {
                    if (tempCounterList.Count == 0)
                    {
                        tempCounterList.Add(arr[1], 1);
                        continue;
                    }


                    if (!tempCounterList.Keys.Contains(arr[1]))
                    {
                        tempCounterList.Add(arr[1], 1);
                    }
                    else
                    {
                        tempCounterList[arr[1]] = tempCounterList[arr[1]] + 1;
                    }
                    //var parentIndexes = tempCounterList.Keys;
                    //foreach (var idx in parentIndexes.ToList())
                    //{
                    //    if ((int)idx == arr[1])
                    //    {
                    //        if (tempCounterList.Keys.Contains(arr[1]))
                    //        {
                    //            tempCounterList[arr[1]] = tempCounterList[arr[1]] + 1;
                    //        }
                    //        else
                    //        {
                    //            tempCounterList.Add(arr[1], 1);
                    //        }

                    //    }
                    //}
                }

                var zeroParents = new List<int>();

                foreach (var allParents in parentChilds)
                {
                    var ifExists = false;
                    foreach (var tempParents in tempCounterList.Keys)
                    {
                        if (allParents[0] == (int)tempParents)
                        {
                            ifExists = true;
                        }
                    }

                    if (!ifExists)
                    {
                        if (zeroParents.Contains(allParents[0]) ) continue;
                        zeroParents.Add(allParents[0]);
                    }
                }

                result[0] = zeroParents;


                var oneParents = new List<int>();
                foreach (var tempCounter in tempCounterList)
                {
                    if (tempCounter.Value == 1)
                    {
                        oneParents.Add(tempCounter.Key);
                    }
                }

                result[1] = oneParents;

                return result;
            }
        }

    }
}
