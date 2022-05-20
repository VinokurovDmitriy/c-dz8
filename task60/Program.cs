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
    int r = new Random().Next(10, 101);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < GetLength(2); k++)
            {
                if (array[i, j, k] == r)
                {
                    r = GetUniqueNumber(array);
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

int GetParam(string partsMessage)
{
    Console.Write($"Введите {partsMessage}: ");
    return Convert.ToInt32(Console.ReadLine());
}
int deep = GetParam("глубину массива");
int rowCount = GetParam("количество строк");
int columnCount = GetParam("количество столбцов");
int[,,] array3D = new int[deep, rowCount, columnCount];

Fill3DArray(array3D);
ConsoleElement3DArray(array3D);