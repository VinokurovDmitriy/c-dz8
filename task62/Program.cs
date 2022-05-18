// Заполните спирально массив 4 на 4.
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

void FillRows(int[,] array)
{
    int startColumn = 0;
    int endColumn = array.GetLength(1) - 1;
    int startRow = 0;
    int endRow = array.GetLength(0) - 1;
    int startValue = 1;
    int rowCount = array.GetLength(0);

    while (rowCount > 0)
    {
        int startValueBottomRow = startValue + (endColumn - startColumn) * 2 + (endRow - startRow);
        Console.WriteLine(startValueBottomRow);
        for (int i = startColumn; i <= endColumn; i++)
        {
            array[startRow, i] = startValue;
            array[endRow, i] = startValueBottomRow;
            startValue++;
            startValueBottomRow--;
        }
        startValue = startValue + endColumn - startColumn - 1 + (endRow - startRow) * 2;
        rowCount -= 2;
        startRow++;
        endRow--;
        startColumn++;
        endColumn--;
    }
}

void FillColumn(int[,] array)
{
    int leftColumn = 0;
    int rightColumn = array.GetLength(1) - 1;
    int startRow = 1;
    int endRow = array.GetLength(0) - 2;
    while ((endRow - startRow) >= 2)
    {
    int startValue = array[startRow - 1, rightColumn] + 1;
    int startLeftValue = array[endRow + 1, leftColumn] + 1;
        for (int i = startRow; i <= endRow; i++)
        {
            array[i, rightColumn] = startValue;
            array[endRow - i + 1, leftColumn] = startLeftValue;
            startValue++;
            startLeftValue++;
        }
        endRow--;
        startRow++;
        rightColumn--;
        leftColumn++;
    }

}


FillRows(array);
FillColumn(array);
PrintArray(array);
