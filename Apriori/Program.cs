using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apriori
{
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
