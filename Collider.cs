using Raylib_cs;
using System.Numerics;


namespace Gymnasiearbete;

public class Collider : Thing
{
    public Collider(Rectangle collider, Player player)
    {
        this.collider = collider;
        this.player = player;
    }
    public Rectangle collider = new Rectangle(100, 100, 100, 100);
    Player player;

    public override void Update()
    {
        if (Raylib.CheckCollisionRecs(player.spriteBox, collider))
        {
            player.spriteBox.x = player.lastPosition.X;
            player.spriteBox.y = player.lastPosition.Y;
        }
    }
    public override void Draw()
    {
        //Raylib.DrawRectangle((int)collider.x, (int)collider.y, (int)collider.width, (int)collider.height, Color.RED);
    }
}