namespace RaySharp;

using Raylib_cs;
using RaySharp;

public class Renderer
{
    public void DrawGrid(int xOffset, int yOffset, ref int[,] grid)
    {
        // Draw vertical and horizontal lines for each cell
        for (int y = 0; y < Config.RowAmount; y++)
        {
            for (int x = 0; x < Config.ColumnAmount; x++)
            {
                int startX = x * Config.GridCellWidth + xOffset;
                int startY = y * Config.GridCellHeight + yOffset;
                int endX = startX + Config.GridCellWidth;
                int endY = startY + Config.GridCellHeight;

                Raylib.DrawLine(startX, startY, startX, endY, Color.WHITE);
                Raylib.DrawLine(startX, startY, endX, startY, Color.WHITE);
            }
        }

        // Draw border lines around the grid
        int gridWidth = Config.ColumnAmount * Config.GridCellWidth;
        int gridHeight = Config.RowAmount * Config.GridCellHeight;

        Raylib.DrawLine(xOffset, yOffset, xOffset + gridWidth, yOffset, Color.WHITE);
        Raylib.DrawLine(xOffset + gridWidth, yOffset, xOffset + gridWidth, yOffset + gridHeight, Color.WHITE);
        Raylib.DrawLine(xOffset + gridWidth, yOffset + gridHeight, xOffset, yOffset + gridHeight, Color.WHITE);
        Raylib.DrawLine(xOffset, yOffset + gridHeight, xOffset, yOffset, Color.WHITE);
    }


    public void DrawBlocks(int xOffset, int yOffset, ref int[,] grid)
    {
        for (int y = 0; y < Config.RowAmount; y++)
        {
            for (int x = 0; x < Config.ColumnAmount; x++)
            {
                int cellValue = grid[x, y];
                Color cellColor;

                switch (cellValue)
                {
                    case 1:
                        cellColor = Color.BLUE;
                        break;
                    case 2:
                        cellColor = Color.GRAY;
                        break;
                    default:
                        cellColor = Color.BLANK;
                        break;
                }

                Raylib.DrawRectangle(
                    x * Config.GridCellWidth + xOffset,
                    y * Config.GridCellHeight + yOffset,
                    Config.GridCellWidth - 1,
                    Config.GridCellHeight - 1,
                    cellColor);

                Raylib.DrawText(
                    $"{cellValue}",
                    x * Config.GridCellWidth + xOffset,
                    y * Config.GridCellHeight + yOffset,
                    20,
                    Color.PINK);
            }
        }
    }

}