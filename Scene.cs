using Raylib_cs;
using System.Numerics;


namespace Gymnasiearbete;



public abstract class Thing
{
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void Draw() { }
}
public class Scene
{

    public Scene(Texture2D backgroundTexture, List<Thing> allThingsInScene)
    {
        this.backgroundTexture = backgroundTexture;
        this.allThingsInScene = allThingsInScene;
    }

    public Texture2D backgroundTexture;

    public List<Thing> allThingsInScene;


}


public static class SceneManager
{
    public static bool isAlex = true;
    public static bool hasbeenadded = false;
    public static Player player = new();
    static int currentSceneIndex = 0;

    static List<Scene> scenes = new();

    static Text text = new();

    static List<Thing> things;


    public static void Start()
    {

        things = new()
        {
            new AnimatedSprite(new List<Texture2D>{ Raylib.LoadTexture("Pixel/ShipOnFire1.png"), Raylib.LoadTexture("Pixel/ShipOnFire2.png"), Raylib.LoadTexture("Pixel/ShipOnFire3.png"),} , new Rectangle(10, 200, 650, 650)),
            new Collider(new Rectangle(130,470,400,130), player), //ship
            new Collider(new Rectangle(-50,0,10,1000), player), //wall_left
            new Collider(new Rectangle(1550,0,10,1000), player), //wall_right
            new Collider(new Rectangle(0,900,1600,10), player), //wall_down
            new Collider(new Rectangle(450,470,80,200), player), //ship wing
            new Collider(new Rectangle(0,0,865,300), player), //berg 1
            new Collider(new Rectangle(900,0,200,80), player), //skylt
            new Collider(new Rectangle(1100,0,400,300), player), //berg 2
            //text,

            new Teleporter(new Rectangle(900,100,200,200), 1, new Vector2(), player)
        };

        Minigame minigame = new Minigame(text);
        List<Thing> things2 = new()
        {
            new NPC (),
            new Collider(new Rectangle(-20,0,10,1000), player), //wall_left
            new Collider(new Rectangle(1520,0,10,1000), player), //wall_right
            new Collider(new Rectangle(0,870,505,40), player), //wall_down
            new Collider(new Rectangle(430,300,600,215), player), //bar
            new Collider(new Rectangle(920,870,500,40), player), //wall_down_right
            new Collider(new Rectangle(0,0,1500,70), player), //wall_top
            new AnimatedSprite (new List<Texture2D>{Raylib.LoadTexture("Pixel/CounterBar.png")}, new Rectangle(0,0,1560,950)),
            text,
            minigame,




            new Teleporter(new Rectangle(505,850,400,200), 0, new Vector2(), player)
        };



        text.minigame = minigame;
        Scene startScene = new(Raylib.LoadTexture("Pixel/SpawnPoint.png"), things);
        scenes.Add(startScene);



        //barScene
        Scene barScene = new(Raylib.LoadTexture("Pixel/BarBackground.png"), things2);
        scenes.Add(barScene);
    }

    public static void Update()
    {
        if (!hasbeenadded)
        {
            if (text.stage == 2)
            {
                things.Add(new Ending());
                hasbeenadded=true;
                
            }

        }
        player.Update();

        foreach (Thing thing in scenes[currentSceneIndex].allThingsInScene)
        {
            thing.Update();
        }
    }

    public static void Draw()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.RAYWHITE);

        Raylib.DrawTexturePro(scenes[currentSceneIndex].backgroundTexture, new Rectangle(0, 0, 300, 180), new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight()), Vector2.Zero, 0, Color.WHITE);


        foreach (Thing thing in scenes[currentSceneIndex].allThingsInScene)
        {
            thing.Draw();
        }


        if (Text.Talking  == false)
        {

            player.Draw();
        }

        Raylib.EndDrawing();
    }
    //osäkert
    public static void ChangeScene(int sceneIndex)
    {
        currentSceneIndex = sceneIndex;
        foreach (Thing thing in scenes[currentSceneIndex].allThingsInScene)
        {
            thing.Start();
        }
    }
}
