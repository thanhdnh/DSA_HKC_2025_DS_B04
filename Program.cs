internal class Program
{
    static int SeqSearch(int[] arr, int value)
    {
        int i = 0;
        while (arr[i] != value)
            i++;
        return i;
    }
    static int RecuSearch(int[] arr, int from, int value)
    {
        if (arr[from] == value)
            return from;
        else
            return RecuSearch(arr, from + 1, value);
    }
    static int SenSearch(int[] arr, int value)
    {
        int x = arr[arr.Length - 1];
        arr[arr.Length - 1] = value;//đặt cầm canh
        int index = SeqSearch(arr, value);
        arr[arr.Length - 1] = x;//hoàn lại
        if (index < arr.Length - 1)
            return index;
        else
            if (arr[arr.Length - 1] == value)
            return arr.Length - 1;
        else
            return -1;
    }
    static int BinSearch(int[] sarr, int value)
    {
        int left = 0, right = sarr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (sarr[mid] == value)
                return mid;
            else if (value > sarr[mid])
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
    static int BinSearchRecu(int[] sarr, int value, int from, int to)
    {
        int mid = (from + to) / 2;
        if (sarr[mid] == value)
            return mid;
        else if (value > sarr[mid])
            return BinSearchRecu(sarr, value, mid + 1, to);
        else
            return BinSearchRecu(sarr, value, from, mid - 1);
    }
    static int TriSearch(int[] sarr, int value)
    {
        int left = 0, right = sarr.Length - 1;
        while (left <= right)
        {
            int lmid = (left + right) / 3, rmid = Math.Min(2 * (left + right) / 3, sarr.Length-1);
            if (sarr[lmid] == value)
                return lmid;
            else if (sarr[rmid] == value)
                return rmid;
            else if (value < sarr[lmid])
                right = lmid - 1;
            else if (value > sarr[rmid])
                left = rmid + 1;
            else
            {
                left = lmid + 1;
                right = rmid - 1;
            }
        }
        return -1;
    }
    private static void Main(string[] args)
    {
        int[] arr = { 9, 7, 2, 4, 3, 11, 8 };
        int value = 4;
        // 5/3=1 và 5/3=3

        int index_seq = SeqSearch(arr, value);
        int index_recu = RecuSearch(arr, 0, value);

        Console.WriteLine($"Sequential: {index_seq}");
        Console.WriteLine($"Recusive: {index_recu}");

        int value2 = 8;
        int index_sen = SenSearch(arr, value2);
        Console.WriteLine($"Sentinel: {index_sen}");

        int[] sarr = { 1, 4, 6, 8, 9, 13 };
        int v = 9;
        int index_bin = BinSearch(sarr, v);
        Console.WriteLine($"Binary: {index_bin}");

        int index_bin_recu = BinSearchRecu(sarr, v, 0, sarr.Length - 1);
        Console.WriteLine($"Binary Recursive: {index_bin_recu}");

        int index_tri = TriSearch(sarr, v);
        Console.WriteLine($"Triple: {index_tri}");
    }
}