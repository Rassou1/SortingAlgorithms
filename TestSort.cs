using System;
namespace Sorteringsalgoritmer
{
    public class TestSort
    {
        private static int[] create(int N, bool ordered)
        {
            return ordered ?
                ArrayUtil.CreateOrdered(N) :
                ArrayUtil.CreateShuffled(N);
        }

        private static double timeit(IntSorter sorter, int[] a)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            sorter.Sort(a);
            return watch.ElapsedMilliseconds / 1000.0;
        }

        private static void testSort(IntSorter sorter, int firstN, bool ordered)
        {
            double t1 = 0;
            int N = firstN / 2;

            while (/*t1 < 0.7 &&*/ N < 5000000)
            {
                N *= 2;
                int[] a = create(N, ordered);
                t1 = timeit(sorter, a);
                Console.WriteLine("T(" + N + ")=" + t1);
                ArrayUtil.TestOrdered(a);
            }
            int[] b = create(4 * N, ordered);
            double t4 = timeit(sorter, b);
            ArrayUtil.TestOrdered(b);
            double t01 = t1 / (N * Math.Log(N)); // ”tid” per jämförelse
            double t04 = t4 / (4 * N * Math.Log(4 * N));
            Console.WriteLine("T(" + 4 * N + ")=" + t4 + " growth per N log N: " + t04 / t01);
            if (t04 / t01 > 1.5)
            { // should be 1.0, but we give it some slack
                Console.WriteLine(sorter.GetType().Name + ".sort appears not to run in O(N log N) time");
                Environment.Exit(1);
            }
        }

        public static void Main()
        {
            //IntSorter sorter = new QuickSortWInsertion();
            IntSorter sorter = new MergeSortWInsertion();
            //IntSorter sorter = new Merge();
             //IntSorter sorter = new Quicksort();
            
            int firstN = 10000;

            Console.WriteLine("Unordered:");
            testSort(sorter, firstN, false);
            Console.WriteLine("\nOrdered:");
            testSort(sorter, firstN, true);

            Console.WriteLine("\n" + sorter.GetType().Name + ".sort tested ok!");
            Environment.Exit(0);
        }
    }
}
