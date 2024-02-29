
int W = 9;
int[] costs = {0, 10, 8, 5, 6, 7, 4};
int[] weights = {0, 4, 2, 1, 2, 3, 1};
int n = weights.Length;
int[,] arr = new int[n, W];
for (int i = 1; i < n; i++)
{
    for (int w = 1; w < W; w++)
    {
        if (weights[i] > w)
            arr[i, w] = arr[i - 1, w];
        else
        {
            arr[i, w] = Math.Max(arr[i - 1, w], arr[i - 1, w - weights[i]] + costs[i]);
        }
    }
}
for (int i = 0; i < n; i++)
{
    for (int w = 0; w < W; w++)
    {
        Console.Write(arr[i, w] + "\t");
    }
    Console.WriteLine();
}

int[] arr1 = new int[W+1];
arr1[0] = 0;
int max = 0;
for (int w = 1; w < W+1; w++)
{
    for (int i = 1; i < n; i++)
    {
        if (weights[i] <= w && arr1[w - weights[i]] + costs[i] > max)
            max = arr1[w - weights[i]] + costs[i];
    }
    arr1[w] = max;
}
Console.Write(String.Join(" ", arr1));
