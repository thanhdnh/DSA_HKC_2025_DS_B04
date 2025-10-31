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
    static int SenSearch(int [] arr, int value)
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
    private static void Main(string[] args)
    {
        int[] arr = { 9, 7, 2, 4, 3, 11, 8 };
        int value = 4;

        int index_seq = SeqSearch(arr, value);
        int index_recu = RecuSearch(arr, 0, value);

        Console.WriteLine($"Sequential: {index_seq}");
        Console.WriteLine($"Recusive: {index_recu}");

        int value2 = 8;
        int index_sen = SenSearch(arr, value2);
        Console.WriteLine($"Sentinel: {index_sen}");
    }
}