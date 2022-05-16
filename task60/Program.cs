// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
void ConsoleElement3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.WriteLine("array[{0}, {1}, {2}] = {3}", i, j, k, array[i, j, k]);
            }
        }
    }
}

int GetUniqueNumber(int[,,] array)
{
    int deep = array.GetLength(0);
    int rowCount = array.GetLength(1);
    int columnCount = array.GetLength(2);
    int elementsCount = rowCount * columnCount * deep;
    int r = new Random().Next(-elementsCount, elementsCount + 1);
    for (int i = 0; i < deep; i++)
    {
        for (int j = 0; j < rowCount; j++)
        {
            for (int k = 0; k < columnCount; k++)
            {
                if (array[i, j, k] == r)
                {
                    GetUniqueNumber(array);
                }
            }
        }
    }
    return r;
}

void Fill3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = GetUniqueNumber(array);   
            }
        }
    }
}

int GetParamsArray(string partsMessage)
{
    Console.Write($"Введите {partsMessage}: ");
    return Convert.ToInt32(Console.ReadLine());
}
int deep = GetParamsArray("глубину массива");
int rowCount = GetParamsArray("количество строк");
int columnCount = GetParamsArray("количество столбцов");
int[,,] array3D = new int[deep, rowCount, columnCount];

Fill3DArray(array3D);
ConsoleElement3DArray(array3D);