/*
    Discuss the benefit/importance of this trick/shortcut:
    
    The trick/shortcut discussed in this chapter is by making sure the 
    itemsets are sorted in lexical order, or essentially alphabetical order.
    Since we know that an itemset will only be interesting if it is composed
    of other interesting components, we can remove much of the guess work
    to make sure our candiates are possibly interesting. The lexical order
    allows us to know that we've already examined all the possibilities up
    until n-1 itemsets and simply append the new item on to the lists
    without repeating any items on accident, ect.

 */
namespace Apriori
{
    using System;
    class Program
    {
        static int[][] data = new int[][]
            {//            a, b, c, d, e, f, g, h, i
               new int[] { 1, 1, 0, 1, 0, 0, 1, 1, 0 },//1
               new int[] { 0, 0, 1, 1, 1, 0, 0, 0, 0 },//2
               new int[] { 0, 1, 1, 0, 0, 1, 0, 0, 0 },//3
               new int[] { 0, 1, 0, 0, 0, 1, 0, 0, 1 },//4
               new int[] { 0, 0, 0, 0, 1, 0, 1, 0, 0 },//5
               new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 1 },//6
               new int[] { 1, 0, 0, 1, 0, 0, 0, 1, 0 },//7
               new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 1 },//8
               new int[] { 0, 0, 1, 0, 1, 0, 0, 0, 0 },//9
               new int[] { 0, 1, 0, 0, 0, 0, 1, 0, 0 },//10
               new int[] { 0, 0, 0, 0, 1, 0, 1, 0, 0 },//11
               new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 },//12
               new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 0 },//13
               new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 0 },//14
               new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1 },//15
               new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 },//16
               new int[] { 1, 0, 0, 0, 0, 1, 0, 0, 0 },//17
               new int[] { 1, 1, 1, 1, 0, 0, 0, 1, 0 },//18
               new int[] { 1, 1, 0, 1, 0, 0, 1, 1, 0 },//19
               new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 } //20

            };
        static string[] items = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
        static void Main(string[] args)
        {
            AprioriAlgorithm ag = new AprioriAlgorithm(data,items, .15f);
            ag.Train();
            Console.WriteLine(ag.ToString());
            Console.ReadKey();
            
        }
    }
}
