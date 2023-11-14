using Raylib_cs;
using System.Numerics;
using Gymnasiearbete;


Raylib.InitWindow(1500, 900, "SPEL :D");
Raylib.SetTargetFPS(60);

SceneManager.Start();

Raylib.SetExitKey(KeyboardKey.KEY_NULL);

while (!Raylib.WindowShouldClose())
{
    SceneManager.Update();
    SceneManager.Draw();
}