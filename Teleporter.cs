using Raylib_cs;
using System.Numerics;


namespace Gymnasiearbete;

public class Teleporter : Thing
{
    public Teleporter(Rectangle collider, int newScene, Vector2 newPosition, Player player)
    {
        this.collider = collider;
        this.newScene = newScene;
        this.newPosition = newPosition;

        this.player = player;
    }
    public Rectangle collider = new Rectangle(100, 100, 100, 100);
    public int newScene = 0; //den scen teleporten byter till
    public Vector2 newPosition;
    Player player;

    public override void Update()
    {
        if(newScene==1){newPosition = new Vector2(700,700);}
        else if (newScene==0) {newPosition = new Vector2(900,350);}

        if (Raylib.CheckCollisionRecs(player.spriteBox, collider)&&newScene==0)
        {

            player.spriteBox.x = newPosition.X;
            player.spriteBox.y = newPosition.Y;

            Console.WriteLine($"Changed scene to nr: {newScene}");
            SceneManager.ChangeScene(newScene);

        
        }

        

        if (Raylib.CheckCollisionRecs(player.spriteBox, collider)&&newScene==1)
        {

            player.spriteBox.x = newPosition.X;
            player.spriteBox.y = newPosition.Y;

            Console.WriteLine($"Changed scene to nr: {newScene}");
            SceneManager.ChangeScene(newScene);
            
        }
    }
    public override void Draw()
    {
       // Raylib.DrawRectangle((int)collider.x, (int)collider.y, (int)collider.width, (int)collider.height, Color.BLUE);
    }
}