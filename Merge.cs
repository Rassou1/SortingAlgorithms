using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteringsalgoritmer
{
    internal class Merge : IntSorter
    {
        public void Sort(int[] unsortedArray)
        {
            ArrayUtil.Shuffle(unsortedArray);

        }

        public void Split(int[] unsortedArray)
        {
            int maxIndex = unsortedArray.Length - 1;
            if(maxIndex%2 == 0)
            {
                int halfIndex = maxIndex / 2;
                int[] leftHalf = new int[halfIndex];
                int[] rightHalf = new int[halfIndex];
                for(int i = 0; i < halfIndex; i++)
                {
                    leftHalf[i] = unsortedArray[i];
                }
                if(leftHalf.Length > 2)
                {
                    Split(leftHalf);
                }
                else
                {
                    if (leftHalf[0] > leftHalf[1])
                    {
                        int temp = leftHalf[0];
                        leftHalf[0] = leftHalf[1];
                        leftHalf[1] = temp;
                    }
                }
                if (rightHalf.Length > 2)
                {
                    Split(rightHalf);
                }
                else
                {
                    if (rightHalf[0] > rightHalf[1])
                    {
                        int temp = rightHalf[0];
                        rightHalf[0] = rightHalf[1];
                        rightHalf[1] = temp;
                    }
                }
                Combine(leftHalf, rightHalf);
            }
        }

        public int[] Combine(int[] leftHalf, int[] rightHalf)
        {
            int sortedArrayMaxIndex = leftHalf.Length + rightHalf.Length - 2;
            int sortedArrayLeftIndex = leftHalf.Length - 1;
            int sortedArrayRightIndex = rightHalf.Length - 1;

            int[] sortedArray = new int[sortedArrayMaxIndex];

            for (int i = 0; i < sortedArrayLeftIndex; i++)
            {
                sortedArray[i] = leftHalf[i];
                sortedArray[i + sortedArrayLeftIndex] = rightHalf[i];
            }

            return sortedArray;
        }
    }   


}
