using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apriori
{
    public class ItemSet
    {
        List<string> items = new List<string>();

        public List<string> Items
        {
            get { return items; }
        }

        public int FurthestItemIndex { get; set; }

        public ItemSet(List<string> items, int furthestIndex)
        {
            this.items = items;
            Count = 0;
            FurthestItemIndex = furthestIndex;
        }

        public ItemSet(string item, int furthestIndex)
        {
            this.items.Add(item);
            Count = 0;
            FurthestItemIndex = furthestIndex;
        }

        public ItemSet(ItemSet set, string item, int furthestIndex)
        {
            foreach (var i in set.Items)
            {
                Items.Add(i);
            }
            Items.Add(item);
            FurthestItemIndex = furthestIndex;
        }

        public int Count { get; set; }

        public float GetSupport(int numberOfRows)
        {
            var support = (float)Count / (float)numberOfRows;
            return support;
        }

        public bool Contains(string item)
        {
            bool contains = false;
            foreach (var i in Items)
            {
                if (i.Equals(item))
                {
                    contains = true;
                }
            }
            return contains;
        }

        public bool ContainedIn(List<string> items)
        {
            bool containedIn = true;
            Dictionary<string, bool> valuePairs = new Dictionary<string, bool>();
            foreach (var i in Items)
            {
                valuePairs.Add(i, false);
            }

            foreach (var i in Items)
            {
                foreach (var j in items)
                {
                    if (i.Equals(j))
                    {
                        valuePairs[i] = true;
                    }
                }
            }

            foreach (var stuff in valuePairs)
            {
                if (stuff.Value == false)
                {
                    containedIn = false;
                }
            }
            return containedIn;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            foreach (var item in Items)
            {
                sb.Append(item);
                sb.Append(",");
            }
            
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
