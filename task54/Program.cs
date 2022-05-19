// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

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
    Console.WriteLine();
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

int FindRowMaxValueIndex(int[,] array, int rowIndex, int startIndex)
{
    int maxValueIndex = startIndex;
    int maxValue = array[rowIndex, startIndex];
    for (int i = startIndex + 1; i < array.GetLength(1); i++)
    {
        if(array[rowIndex, i] > maxValue)
        {
            maxValue = array[rowIndex, i];
            maxValueIndex =  i;
        }
    }
    return maxValueIndex;
}

void SortRow(int[,] array, int rowIndex)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        int maxValueIndex = FindRowMaxValueIndex(array, rowIndex, i);
        if(array[rowIndex, i] < array[rowIndex, maxValueIndex])
        {
            int temp = array[rowIndex, i];
            array[rowIndex, i] = array[rowIndex, maxValueIndex];
            array[rowIndex, maxValueIndex] = temp;
        }
    }
}

void SortAllRows(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        SortRow(array, i);
    }
}

FillRandomIntArray(array);
PrintArray(array);
SortAllRows(array);
PrintArray(array);