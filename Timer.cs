namespace RaySharp;

using Raylib_cs;

public class GameTimer
{
    public double StartTime { get; set; }
    public double LifeTime { get; set; }

    public void Start(double lifetime)
    {
        StartTime = Raylib.GetTime();
        LifeTime = lifetime;
    }

    public bool IsDone()
    {
        return Raylib.GetTime() - StartTime >= LifeTime;
    }

    public double GetElapsed()
    {
        return Raylib.GetTime() - StartTime;
    }
}