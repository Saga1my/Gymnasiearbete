using Raylib_cs;
using System.Numerics;

namespace Gymnasiearbete;




public class Minigame : Thing
{
    public Rectangle spriteBox;
    public Rectangle spriteBox2;

    public bool won = false;
    public bool played = false;
    int tasksDone = 0;

    int max = 1;
    bool red = false;
    int time = 0;
    Text text;
    Texture2D bil = Raylib.LoadTexture("Pixel/car.png");
    Texture2D road = Raylib.LoadTexture("Pixel/road.png");
    Texture2D wheel = Raylib.LoadTexture("Pixel/wheels.png");




    static List<Texture2D> listOfTextureLists = new List<Texture2D>();

    Rectangle[] fallingSprites = new Rectangle[4];
    float[] fallingSpeeds = new float[4];
    Random random = new Random();
    
    

    public Minigame(Text text)
    {
        this.text = text;
       
    }


    public override void Start()
    {
        red = false;
        
        tasksDone = 0;
        time = 0;
        spriteBox = new Rectangle(600, 600, 150, 300);
        spriteBox2 = new Rectangle(10, 0, 100, 100);
        for (int i = 0; i < fallingSprites.Length; i++)
        {
            fallingSprites[i] = new Rectangle(random.Next(0, Raylib.GetScreenWidth() - 140), -240, 180, 300);
            fallingSpeeds[i] = random.Next(6, 6);
        }
        listOfTextureLists.Add(Raylib.LoadTexture("Pixel/stone.png"));
        listOfTextureLists.Add(Raylib.LoadTexture("Pixel/battery.png"));
        listOfTextureLists.Add(Raylib.LoadTexture("Pixel/stone.png"));
        listOfTextureLists.Add(Raylib.LoadTexture("Pixel/stone.png"));

    }

    public override void Update()
    {


        if (text.isMinigameActive)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && spriteBox.x < 1350)
            {
                spriteBox.x += 7;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && spriteBox.x > 0)
            {
                spriteBox.x -= 7;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && spriteBox.y > 0)
            {
                spriteBox.y -= 7;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && spriteBox.y < 700)
            {
                spriteBox.y += 7;
            }


            for (int i = 0; i < fallingSprites.Length; i++)
            {
                fallingSprites[i].y += fallingSpeeds[i];

                if (fallingSprites[i].y > Raylib.GetScreenHeight())
                {
                    fallingSprites[i].x = random.Next(0, Raylib.GetScreenWidth() - 240);
                    fallingSprites[i].y = -240;
                    fallingSpeeds[i] = random.Next(6, 6);
                }

                Vector2 spriteCenter = new Vector2(fallingSprites[i].x + fallingSprites[i].width / 2, fallingSprites[i].y + fallingSprites[i].height / 2);
                
                if (Raylib.CheckCollisionPointRec(spriteCenter, spriteBox))
                {
                    if (i == 1 && tasksDone < max)
                    {
                        tasksDone++;
                    }

                    else if (tasksDone == max)
                    {
                        text.isMinigameActive = false;
                        won = true;
                        played = true;
                    }


                    else if (i == 0||i == 2||i == 3 && tasksDone < max)
                    {
                        red = true;
                        won = false;
                        played = true;

                    }

                    fallingSprites[i].x = random.Next(0, Raylib.GetScreenWidth() - 240);
                    fallingSprites[i].y = -240;
                    fallingSpeeds[i] = random.Next(6, 6);
                }

                if (red)
                {
                    time++;
                }

                if (time == 25)
                {
                    tasksDone = 0;
                    red = false;
                    text.isMinigameActive = false;
                }
            }
        }
    }



    public override void Draw()
    {
        if (text.isMinigameActive)
        {
            Raylib.DrawTexturePro(wheel, new Rectangle(0, 0, bil.width, bil.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
            Raylib.DrawTexturePro(road, new Rectangle(0, 0, 300, 180), new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight()), Vector2.Zero, 0, Color.WHITE);
            for (int i = 0; i < fallingSprites.Length; i++)
            {
                Raylib.DrawTexturePro(listOfTextureLists[i], new Rectangle(0, 0, listOfTextureLists[i].width, listOfTextureLists[i].height), fallingSprites[i], Vector2.Zero, 0f, Color.WHITE);
            }
            Raylib.DrawTexturePro(bil, new Rectangle(0, 0, bil.width, bil.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);

            Raylib.DrawText($"{tasksDone}", 30, 40, 25, Color.BLACK);
            Raylib.DrawTexturePro(listOfTextureLists[1], new Rectangle(0, 0, listOfTextureLists[1].width, listOfTextureLists[1].height), spriteBox2, Vector2.Zero, 0f, Color.WHITE);
            if (red && text.isMinigameActive) { Raylib.DrawRectangle(0, 0, 1500, 900, Color.RED); }
        }
    }
}
