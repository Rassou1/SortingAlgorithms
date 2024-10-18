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
            if(unsortedArray.Length < 2)
            {
                return;
            }

            Split(unsortedArray);

        }

        public void Split(int[] unsortedArray)
        {
            int length = unsortedArray.Length;

            if (length == 2)
            {
                return unsortedArray;
            }

            int halfIndex = length / 2;
            int[] leftHalf = new int[halfIndex];
            int[] rightHalf = new int[length - halfIndex];

            for(int i = 0; i < halfIndex; i++)
            {
                leftHalf[i] = unsortedArray[i];
            }
                
            for (int i = halfIndex; i < length; i++)
            {
                int temp = i - halfIndex;
                rightHalf[temp] = unsortedArray[i];
            }
            Split(rightHalf);
            Split(leftHalf);

            Combine(unsortedArray, leftHalf, rightHalf);
            
        }

        public void Combine(int[] unsortedArray, int[] leftHalf, int[] rightHalf)
        {
            int leftLength = leftHalf.Length;
            int rightLength = rightHalf.Length;

            int i = 0; int j = 0; int k = 0;

            while (i < leftLength && j < rightLength)
            {
                if (leftHalf[i] <= rightHalf[j])
                {
                    unsortedArray[k++] = leftHalf[i++];
                }
                else 
                {
                    unsortedArray[k++] = rightHalf[j++];
                }
            }

            while(i < leftLength)
            {
                unsortedArray[k++] = leftHalf[i++];
            }

            while(j < rightLength)
            {
                unsortedArray[k++] = rightHalf[j++];
            }
        }
    }   


}
