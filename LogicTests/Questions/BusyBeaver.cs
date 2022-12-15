using System.Text;

namespace LogicTests.Questions;

public static class BusyBeaver
{
    private static int _logsAmount;
    private static int _rowIndex;
    private static int _colIndex;

    public static int LogsCalculate(List<List<int>> forest)
    {
        SetBeaverPosition(forest);

        do
        {
            CollectLog(forest, _rowIndex, _colIndex);
            ShowMatrix(forest);

        } while (BeaverCanMove(forest));
        
        return _logsAmount;
    }

    private static bool BeaverCanMove(List<List<int>> forest)
    {
        int? upValue = _rowIndex != 0 ? forest[_rowIndex - 1][_colIndex] : 0;
        int? downValue = _rowIndex < forest.Count - 1 ? forest[_rowIndex + 1][_colIndex] : 0;
        int? leftValue = _colIndex != 0 ? forest[_rowIndex][_colIndex - 1] : 0;
        int? rightValue = _colIndex < forest[0].Count - 1 ? forest[_rowIndex][_colIndex + 1] : 0;

        if (upValue == 0 && downValue == 0 && leftValue == 0 && rightValue == 0)
            return false;

        if (upValue > downValue && upValue > leftValue && upValue > rightValue)
        {
            _rowIndex--;
            return true;
        }

        if (downValue > upValue && downValue > leftValue && downValue > rightValue)
        {
            _rowIndex++;
            return true;
        }

        if (leftValue > upValue && leftValue > downValue && leftValue > rightValue)
        {
            _colIndex--;
            return true;
        }

        if (rightValue > upValue && rightValue > downValue && rightValue > leftValue)
        {
            _colIndex++;
            return true;
        }

        return false;
    }

    private static void SetBeaverPosition(List<List<int>> forest)
    {
        _rowIndex = Convert.ToInt32(Math.Floor(forest.Count / 2.00));
        _colIndex = Convert.ToInt32(Math.Floor(forest[0].Count / 2.00));

        if (forest[_rowIndex][_colIndex] < forest[_rowIndex][_colIndex - 1])
            _colIndex--;

        if (forest[_rowIndex][_colIndex] < forest[_rowIndex - 1][_colIndex])
            _rowIndex--;
    }

    private static void CollectLog(List<List<int>> forest, int rowIndex, int colIndex)
    {
        _logsAmount += forest[rowIndex][colIndex];
        forest[rowIndex][colIndex] = 0;
    }

    private static void ShowMatrix(List<List<int>> forest)
    {
        StringBuilder matrix = new();
        for (int r = 0; r < forest.Count; r++)
        {
            for (int c = 0; c < forest[0].Count; c++)
            {
                matrix.Append(forest[r][c]);
            }
            matrix.Append(Environment.NewLine);
        }
        Console.WriteLine(matrix);
    }
}