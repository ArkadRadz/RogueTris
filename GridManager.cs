namespace RaySharp;

public class GridManager
{
    public void ResetGrid(ref int[,] grid)
    {
        for (int y = 0; y < Config.RowAmount; y++)
        {
            for (int x = 0; x < Config.ColumnAmount; x++)
            {
                grid[x, y] = 0;
            }
        }
    }
    
    public void PullRowsDown(ref int[,] grid)
    {
        for (int y = Config.RowAmount - 1; y > 0; y--)
        {
            for (int x = 0; x < Config.ColumnAmount; x++)
            {
                grid[x, y] = grid[x, y - 1];
            }
        }
    }
    
    public void ClearRow(int y, ref int[,] grid)
    {
        for (int x = 0; x < Config.ColumnAmount; x++)
        {
            grid[x, y] = 0;
        }
    }
    
    public void CheckRows(ref int[,] grid, ref int score)
    {
        for (int y = Config.RowAmount - 1; y > 0; y--)
        {
            bool rowFilled = true;
            for (int x = 0; x < Config.ColumnAmount; x++)
            {
                if (rowFilled == false)
                {
                    continue;
                }
    
                if (grid[x, y] == 0)
                {
                    rowFilled = false;
                }
            }
    
            if (rowFilled)
            {
                score++;
                ClearRow(y, ref grid);
                PullRowsDown(ref grid);
            }
        }
    }
    
    public int GetFirstAvailableVerticalPos(int x, ref int[,] grid)
    {
        int y = 0;
        for (int _y = Config.RowAmount - 1; _y > 0; _y--)
        {
            if (grid[x, _y] == 1)
            {
                continue;
            }
    
            y = _y;
            break;
        }
    
        return y;
    }
}