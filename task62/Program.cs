// Заполните спирально массив 4 на 4.
int GetParams(string partsMessage)
{
    Console.Write($"Введите количество {partsMessage}: ");
    return Convert.ToInt32(Console.ReadLine());
}

int rowCount = GetParams("строк");
int columnCount = GetParams("столбцов");
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

void FillColumns(int[,] array)
{
    int leftColumnIndex = 0;
    int startRowIndex = 1;
    int lastRow = array.GetLength(0) - 1;
    while (array[startRowIndex, leftColumnIndex] == 0)
    {
        int rightColumnIndex = array.GetLength(1) - 1 - leftColumnIndex;
        int lastRowIndex = array.GetLength(0) - startRowIndex;
        int leftNum = array[lastRowIndex, leftColumnIndex] + lastRowIndex - startRowIndex + 1;
        Console.WriteLine($"{array[lastRowIndex, leftColumnIndex]} {lastRowIndex} {startRowIndex}");
        int rightNum = array[startRowIndex - 1, rightColumnIndex];
        for (int i = startRowIndex; i < lastRowIndex; i++)
        {
            array[i, rightColumnIndex] = ++rightNum;
            array[i, leftColumnIndex] = --leftNum;
        }
        startRowIndex ++;
        leftColumnIndex ++;
    }
}

FillRows(array);
FillColumns(array);
PrintArray(array);
