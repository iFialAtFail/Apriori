using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apriori
{
    public class AprioriAlgorithm
    {
        List<ItemSet[]> LargeItemset = new List<ItemSet[]>();// each entry in the list is a large itemset.
        private int[][] data;
        private float minSupport;
        private string[] items;

        public AprioriAlgorithm(int[][] data, string[] items, float minSupportPct)
        {
            this.data = data;
            minSupport = minSupportPct;
            this.items = items;
        }

        /// <summary>
        /// Generates the LargeItemSets
        /// </summary>
        public void Train()
        {
            GetFrequentItemsForL1(); //populates L's first itemset array.
            for (int k = 1; LargeItemset.Count > (k - 1) && LargeItemset[k - 1].Length != 0; k++)
            {
                List<ItemSet> Candidates = AprioriGen(k - 1);
                for (int row = 0; row < data.GetLength(0); row++) //For every row of data.
                {
                    for (int j = 0; j < Candidates.Count; j++) // for every candidate
                    {
                        if (Subset(Candidates[j], data[row]))
                        {
                            Candidates[j].Count++;
                        }
                    }
                }
                List<ItemSet> retVal = new List<ItemSet>();
                foreach (var candidate in Candidates)
                {
                    if (candidate.GetSupport(data.GetLength(0)) >= minSupport)// retain if have enough support.
                    {
                        retVal.Add(candidate);
                    }
                }
                if (retVal.Count >= 1) // if there's one or more candidates, add to L.
                    LargeItemset.Add(retVal.ToArray());
            }
        }

        /// <summary>
        /// Checks to see if an itemset is contained within a row of the data.
        /// </summary>
        /// <param name="set"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool Subset(ItemSet set, int[] row)
        {
            List<string> retVal = new List<string>();
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] >= 1)
                {
                    retVal.Add(items[i]);
                }
            }
            if (set.ContainedIn(retVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Create all candidates from previous Itemset.
        /// </summary>
        /// <param name="kIndex"></param>
        /// <returns></returns>
        private List<ItemSet> AprioriGen(int kIndex)
        {
            List<ItemSet> retVal = new List<ItemSet>();

            for (int i = 0; i < LargeItemset[kIndex].Length; i++)// for each itemset in L at kIndex
            {
                for (int j = LargeItemset[kIndex][i].FurthestItemIndex + 1; j < items.Length; j++) // for every item, starting after the furthest used item index lexilogically.
                {
                    List<string> retItems = new List<string>();
                    var itemSet = LargeItemset[kIndex][i]; //pulled out for easy debugging
                    var item = items[j];                   //pulled out for easy debugging
                    if (!itemSet.Contains(item))
                    {
                        retVal.Add(new ItemSet(LargeItemset[kIndex][i], items[j], j));//create new itemset from the previous, appending the new item that shouldnt be duplicate.
                    }
                }
            }

            return retVal;

        }





        private void GetFrequentItemsForL1()
        {
            //Create list of candidates and add all item types there as single item sets.
            List<ItemSet> candidates = new List<ItemSet>();
            int i = 0;
            foreach (string item in items)
            {
                candidates.Add(new ItemSet(item, i));
                i++;
            }

            for (int row = 0; row < data.GetLength(0); row++)
            {
                for (int col = 0; col < items.Length; col++)
                {
                    if (data[row][col] >= 1)
                    {
                        candidates[col].Count++;
                    }
                }
            }

            List<ItemSet> retval = new List<ItemSet>();
            foreach (var itemset in candidates)
            {
                var support = itemset.GetSupport(data.GetLength(0));
                if (support > minSupport)
                {
                    retval.Add(itemset);
                }
            }
            LargeItemset.Add(retval.ToArray());

        }

        private bool EnoughSupport(int itemIndex)
        {
            int itemCount = 0;
            for (int i = 0; i < data.GetLength(0); i++) //Iterate through all the rows
            {
                if (data[i][itemIndex] >= 1)// the item index per row has a number count it.
                {
                    itemCount++;
                }
            }
            if ((itemCount / data.GetLength(0)) > minSupport)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
