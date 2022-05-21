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
    int r = new Random().Next(10, 100);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
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
bool correctParams = false;
Console.WriteLine("Введите параметры массива. Произведение параметров не должно превышать 89");
int deep = 0, rowCount = 0, columnCount = 0;
while (!correctParams)
{
    deep = GetParam("глубину массива");
    rowCount = GetParam("количество строк");
    columnCount = GetParam("количество столбцов");
    if (deep * rowCount * columnCount < 90)
        correctParams = true;
        else
        Console.WriteLine("Вы ввели некорректные значения. Повторите ввод");
}
int[,,] array3D = new int[deep, rowCount, columnCount];

Fill3DArray(array3D);
ConsoleElement3DArray(array3D);