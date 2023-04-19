using Raylib_cs;
using RaySharp;

const int windowWidth = 1366;
const int windowHeight = 768;
const string windowTitle = "Prawie Tetris";
const int frameRate = 60;

int[,] grid = new int[Config.ColumnAmount, Config.RowAmount];
Renderer renderer = new();
GridManager gridManager = new();
int score = 0;
GameTimer timer = new GameTimer();

void Reset()
{
    score = 0;
    gridManager.ResetGrid(ref grid);
}

void Update()
{
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
    {
        Reset();
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
    {
        gridManager.CheckRows(ref grid, ref score);
    }

    if (timer.IsDone() || Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
    {
        timer.Start(0.5);
    }
}

void Draw()
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);

    renderer.DrawGrid(Raylib.GetScreenWidth() / 3, 10, ref grid);
    renderer.DrawBlocks(Raylib.GetScreenWidth() / 3, 10, ref grid);

    Raylib.EndDrawing();
}

void Main()
{
    Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
    Raylib.SetTargetFPS(frameRate);

    timer.Start(0.5);

    while (!Raylib.WindowShouldClose())
    {
        Update();
        Draw();
    }

    Raylib.CloseWindow();
}

Main();