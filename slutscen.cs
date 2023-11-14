using Raylib_cs;
using System.Numerics;


namespace Gymnasiearbete;

public class Ending : Thing
{
    

    public Rectangle MySpriteBox { get; set; }

    

    
    static List<Texture2D> listOfTextureLists = new();
    List<Texture2D> Alex = new List<Texture2D>
    {
        Raylib.LoadTexture("Pixel/Alex.png"),
        Raylib.LoadTexture("Pixel/Alex_Closeup.png"),
        Raylib.LoadTexture("Pixel/Alex_CloseupThinking.png"),
        Raylib.LoadTexture("Pixel/Alex_CloseupHappy.png"),

    };
    // List<Texture2D> Tom = new List<Texture2D>
    // {
    //     Raylib.LoadTexture("Pixel/Tom.png"),
    //     Raylib.LoadTexture("Pixel/Tom_Closeup.png"),
    //     Raylib.LoadTexture("Pixel/Tom_CloseupThinking.png"),
    //     Raylib.LoadTexture("Pixel/Tom_CloseupHappy.png"),

    // };
    public override void Start()
    {
        MySpriteBox = new Rectangle(670, 300, 200, 200);
    }

    public override void Update()
    {
        
    }
    public override void Draw()
    {
        //Raylib.DrawTexturePro(Alex[0], new Rectangle(0, 0, Alex[0].width, Alex[0].height), MySpriteBox, Vector2.Zero, 0f, Color.WHITE);
    }

    
}