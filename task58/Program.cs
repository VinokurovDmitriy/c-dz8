// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int GetParam(string partsMessage, string nameMatrix)
{
    Console.Write("Введите количество {0} матрицы {1}: ", partsMessage, nameMatrix);
    return Convert.ToInt32(Console.ReadLine());
}
int rowCountA = GetParam("строк ", " A и количество стлбцов матрицы В");
int columnCountA = GetParam("столбцов", "А");
int columnCountB = GetParam("столбцов",  "В");

int[,] matrixA = new int[rowCountA, columnCountA];
int[,] matrixB = new int[columnCountA, columnCountB];


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

void FillRandArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(-5, 6);
        }
    }
}

int GetResultElement(int[,] arrayA, int[,] arrayB, int rowIndex, int columnIndex)
{
    int result = 0;
    for (int i = 0; i < arrayA.GetLength(1); i++)
    {
        result += arrayA[rowIndex, i] * arrayB[i, columnIndex];
    }
    return result;
}

int[,] FillMatrixMultiple(int[,] arrayA, int[,] arrayB)
{
    int[,] resultArray = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
    for (int i = 0; i < resultArray.GetLength(0); i++)
    {
        for (int j = 0; j < resultArray.GetLength(1); j++)
        {
            resultArray[i, j] = GetResultElement(arrayA, arrayB, i, j);
        }
    }
    return resultArray;
}

FillRandArray(matrixA);
FillRandArray(matrixB);

Console.WriteLine("Матрица А[{0}, {1}]:", matrixA.GetLength(0), matrixA.GetLength(1));
PrintArray(matrixA);

Console.WriteLine("Матрица B[{0}, {1}]:", matrixB.GetLength(0), matrixB.GetLength(1));
PrintArray(matrixB);

Console.WriteLine("А * B [{0}, {1}]:", matrixA.GetLength(0), matrixB.GetLength(1));
PrintArray(FillMatrixMultiple(matrixA,  matrixB));




