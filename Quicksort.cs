using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteringsalgoritmer
{
    public class Quicksort : IntSorter
    {
        
        public void Sort(int[] unsortedArray)
        {
            ArrayUtil.Shuffle(unsortedArray);
            PartitionSort(unsortedArray, 0, unsortedArray.Length - 1);
        }

        public void PartitionSort(int[] unsortedArray, int lo, int hi)
        {
            if (hi <= lo) return;
            int partition = Partition(unsortedArray, lo, hi);
            PartitionSort(unsortedArray, partition+1, hi);
            PartitionSort(unsortedArray, lo, partition-1);
        }

        public int Partition(int[] array, int lo, int hi)
        {
            int pivotPoint = array[hi];
            int i = lo - 1;

            for(int j = lo; j < hi; j++)
            {
                if (array[j] <= pivotPoint)
                {
                    i++;

                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            int otherTemp = array[i + 1];
            array[i + 1] = array[hi];
            array[hi] = otherTemp;

            return i + 1;

        }

    }
}

