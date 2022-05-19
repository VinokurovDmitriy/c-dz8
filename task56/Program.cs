//  Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
int GetParamsArray(string partsMessage)
{
    Console.Write($"Введите количество {partsMessage}: ");
    return Convert.ToInt32(Console.ReadLine());
}

int rowCount = GetParamsArray("строк");
int columnCount = GetParamsArray("столбцов");
int[,] array = new int[rowCount, columnCount];
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],5}");
        }
        Console.WriteLine();
    }
}

void FillRandomIntArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = new Random().Next(-10, 11);
        }
    }
}

int FindIndexMinSumRow(int[,] array)
{
    int minSum = array[0, 0];
    int indexMinRow = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sumRow = array[i, 0];
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumRow += array[i, j];
        }
        if (i == 0)
        {
            minSum = sumRow;

        }
        else if (minSum > sumRow)
        {
            minSum = sumRow;
            indexMinRow = i;
        }
    }
    return indexMinRow;
}

FillRandomIntArray(array);
PrintArray(array);

Console.WriteLine($"{FindIndexMinSumRow(array) + 1} строка");
