using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteringsalgoritmer
{
    internal class QuickSortWInsertion: IntSorter
    {
        int m = 10;
        public void Sort(int[] unsortedArray)
        {
            ArrayUtil.Shuffle(unsortedArray);
            PartitionSort(unsortedArray, 0, unsortedArray.Length - 1);
        }

        public void PartitionSort(int[] unsortedArray, int lo, int hi)
        {
            if (hi - lo + 1 <= m)
            {
                insertSort(unsortedArray,lo,hi);
                return;
            }
            if (hi <= lo) return;
            int partition = Partition(unsortedArray, lo, hi);
            PartitionSort(unsortedArray, partition + 1, hi);
            PartitionSort(unsortedArray, lo, partition - 1);
        }

        public void insertSort(int[] array, int lo, int hi)
        {
            for (int i = lo + 1; i <= hi; i++)
            {
                int currentValue = array[i];
                int j = i - 1;

                while (j >= lo && array[j] > currentValue)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = currentValue;
            }
        }

        public int Partition(int[] array, int lo, int hi)
        {
            int pivotPoint = array[hi];
            int i = lo - 1;

            for (int j = lo; j < hi; j++)
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
