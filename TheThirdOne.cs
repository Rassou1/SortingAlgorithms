using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace Sorteringsalgoritmer
{

    public class TheThirdOne : IntSorter
    {
        public void Sort(int[] a)
        {
            SortedDictionary<int, int> d = new SortedDictionary<int, int>();

            foreach (int i in a)
            {
                if (d.ContainsKey(i))
                {
                    d[i]++;
                }
                else
                {
                    d[i] = 1;
                }

                int index = 0;

                foreach (var keyValuePair in d)
                {
                    int number = keyValuePair.Key;
                    int count = keyValuePair.Value;

                    for (int j = 0; j < count; j++)
                    {
                        a[index++] = number;
                    }

                }

            }
        }
    }
}
