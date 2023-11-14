using Raylib_cs;
using System.Numerics;


namespace Gymnasiearbete;

public class AnimatedSprite : Thing
{
    public AnimatedSprite(List<Texture2D> allTextures, Rectangle spriteBox)
    {
        this.allTextures = allTextures;
        this.spriteBox = spriteBox;
    }
    public List<Texture2D> allTextures;
    public Rectangle spriteBox;
    public int currentFrame;

    public int frameTime = 5;
    int frameCounter;
    public override void Update()
    {
        frameCounter += 1;


        if (frameCounter >= frameTime)
        {
            frameCounter = 0;
            currentFrame += 1;
        }
        if (currentFrame >= allTextures.Count)
        {
            currentFrame = 0;
        }
    }
    public override void Draw()
    {
        Raylib.DrawTexturePro(allTextures[currentFrame], new Rectangle(0, 0, allTextures[0].width, allTextures[0].height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
    }
}