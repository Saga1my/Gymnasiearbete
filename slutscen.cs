using Raylib_cs;
using System.Numerics;


namespace Gymnasiearbete;

public class Ending : Thing
{
    bool tomhidden = true;
    bool talk = false;
    int CurrentChat = 0;

    int timeindex = 0;



    Texture2D family = Raylib.LoadTexture("Pixel/Family.png");
    //Texture2D tom = Raylib.LoadTexture("Pixel/Tom.png");
    Texture2D evil = Raylib.LoadTexture("Pixel/Evil.png");
    Texture2D Me = Raylib.LoadTexture("Pixel/Idle_Main.png");

    Texture2D tom = Raylib.LoadTexture("Pixel/Alex.png");

    Texture2D ChatTexture = Raylib.LoadTexture("Pixel/Chat1.png");
    List<string> Chat = new List<string>{
        "Crazy man:  Have you ever heard of the trolley problem?",

        "  You:  I might have, if its the one im thinking of",

        "Crazy man:  Its the one where you find yourself walking by a railway, and see five people tied to the tracks. There is a lever nearby that you can switch, causing the train to change paths, killing a singular person who is tied to the second track. What do you do?",

        "  You:  Why are you asking me this?",

        "Crazy man:  Let's bring this theory to reality. I've got six hostages, including your friend Tom. Time to make a choice. Who should I shoot?",

        "  You:  This isn't a thought experiment! You can't force someone into a real-life trolley problem. There has to be another way to resolve this.",

        "Crazy man:  Life doesn't always offer easy choices. Decide now, or I make the choice for you.",

        "  You:  Please, there has to be another solution. Let's talk about this. Shooting anyone won't solve anything.",

        "Crazy man:  Choices have consequences, my friend. Make yours."
    };


    Rectangle spriteBox = new Rectangle(5, -600, 1500, 900);


    Rectangle TomBox = new Rectangle(910, 250, 170, 170);
    Rectangle FamilyBox = new Rectangle(1200, 600, 200, 200);
    Rectangle EvilBox = new Rectangle(1100, 400, 150, 150);
    Rectangle MeBox = new Rectangle(950, 300, 150, 150);
    public override void Start()
    {

        Text.Talking = true;
    }

    public override void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && CurrentChat <= Chat.Count - 1)
        { CurrentChat += 1; }

        if (timeindex < 60 && tomhidden == true)
        {
            timeindex++;
        }

        else if (timeindex == 60)
        {
            tomhidden = false;


        }

        if (TomBox.y < 600 && tomhidden==false) { TomBox.y += 5;}
        else if (TomBox.y >= 550 && tomhidden==false)
        {
            talk = true;
        }


    }
    public override void Draw()
    {
        Raylib.DrawTexturePro(family, new Rectangle(0, 0, family.width, family.height), FamilyBox, Vector2.Zero, 0f, Color.WHITE);
        Raylib.DrawTexturePro(evil, new Rectangle(0, 0, evil.width, evil.height), EvilBox, Vector2.Zero, 0f, Color.WHITE);
        Raylib.DrawTexturePro(Me, new Rectangle(0, 0, Me.width, Me.height), MeBox, Vector2.Zero, 0f, Color.WHITE);
        if (tomhidden == false)
        { Raylib.DrawTexturePro(tom, new Rectangle(0, 0, tom.width, tom.height), TomBox, Vector2.Zero, 0f, Color.WHITE); }
        if (talk)
        {
            Raylib.DrawTexturePro(ChatTexture, new Rectangle(0, 0, ChatTexture.width, ChatTexture.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
            TextWrapper.DrawTextWithWordWrap(Chat[CurrentChat], new Rectangle(100, 60, 1300, 400), 25, 2, Color.BLACK);
            Raylib.DrawText("[ENTER] Continue", 150, 150, 25, Color.BLACK);
        }

    }


}