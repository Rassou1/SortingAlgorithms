namespace Sorteringsalgoritmer
{
    public class InsertionSorter : IntSorter
    {
        public void Sort(int[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                for (int j = i; j > 0 && a[j] < a[j - 1]; j--)
                {
                    int x = a[j]; a[j] = a[j - 1]; a[j - 1] = x;
                }
            }
        }
    }
}
