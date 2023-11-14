using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;
using Gymnasiearbete;

namespace Gymnasiearbete;
public class Player : Thing
{
    Dictionary<string, Texture2D> PlayerTextures = new Dictionary<string, Texture2D> {
        {"avatar", Raylib.LoadTexture("Pixel/Idle_Main.png")},
        {"back", Raylib.LoadTexture("Pixel/WalkUp_Main2.png")},
        {"left", Raylib.LoadTexture("Pixel/WalkLeft_Main1.png")},
        {"right", Raylib.LoadTexture("Pixel/WalkRight_Main1.png")}
    };

    List<Texture2D> WalkingLeft = new List<Texture2D>(){
        Raylib.LoadTexture("Pixel/WalkLeft_Main1.png"),
        Raylib.LoadTexture("Pixel/WalkLeft_Main2.png"),
        Raylib.LoadTexture("Pixel/WalkLeft_Main3.png"),
        Raylib.LoadTexture("Pixel/WalkLeft_Main4.png"),
    };
    List<Texture2D> WalkingRight = new List<Texture2D>(){
        Raylib.LoadTexture("Pixel/WalkRight_Main1.png"),
        Raylib.LoadTexture("Pixel/WalkRight_Main2.png"),
        Raylib.LoadTexture("Pixel/WalkRight_Main3.png"),
        Raylib.LoadTexture("Pixel/WalkRight_Main4.png"),
    };

    List<Texture2D> WalkingUp = new List<Texture2D>(){
        Raylib.LoadTexture("Pixel/WalkUp_Main1.png"),
        Raylib.LoadTexture("Pixel/WalkUp_Main2.png"),
        Raylib.LoadTexture("Pixel/WalkUp_Main3.png"),

    };
    List<Texture2D> WalkingDown = new List<Texture2D>(){
        Raylib.LoadTexture("Pixel/WalkDown_Main1.png"),
        Raylib.LoadTexture("Pixel/WalkDown_Main2.png"),
        Raylib.LoadTexture("Pixel/WalkDown_Main3.png"),

    };

    public Rectangle spriteBox = new Rectangle(600, 500, 150, 150);

    Texture2D currentTexture;
    float walkingAnimationTime = 0;
    int walkingAnimationIndex = 0;

    public Vector2 lastPosition = new Vector2(0, 0);


    private float movementSpeed = 5.0f;


    public override void Update()
    {
        if(!Text.Talking){Walk();}
        if (Raylib.IsMouseButtonDown(0))
        {
            Console.WriteLine(Raylib.GetMousePosition());
        }
    }
    void Walk()
    {
        List<Texture2D> currentTextureSet = new List<Texture2D>() { PlayerTextures["avatar"] };

        lastPosition = new Vector2(spriteBox.x, spriteBox.y);


        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            currentTextureSet = WalkingLeft;
            spriteBox.x -= movementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            spriteBox.x += movementSpeed;
            currentTextureSet = WalkingRight;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            currentTextureSet = WalkingUp;
            spriteBox.y -= movementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            spriteBox.y += movementSpeed;
            currentTextureSet = WalkingDown;
        }

        walkingAnimationTime++;
        if (walkingAnimationTime >= 10)
        {
            walkingAnimationTime = 0;
            if (walkingAnimationIndex >= currentTextureSet.Count() - 1)
            {
                walkingAnimationIndex = 0;
            }
            else
            {
                walkingAnimationIndex++;
            }
            currentTexture = currentTextureSet[walkingAnimationIndex];
        }
    }
    public void Draw()
    {
        Raylib.DrawTexturePro(currentTexture, new Rectangle(0, 0, currentTexture.width, currentTexture.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
    }
}