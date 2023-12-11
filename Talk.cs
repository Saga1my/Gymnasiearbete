using Raylib_cs;
using System.Numerics;
using System.Transactions;
using System.Xml.Serialization;


namespace Gymnasiearbete;

public class Text : Thing
{

    int CurrentChat = 0;


    public bool isMinigameActive = false;

    public int stage = 0;


    bool me = false;

    bool still = false;
    bool left = false;

    bool choice = false;

    bool evilAppeared = false;



    Player player = new();


    Texture2D ChatTexture = Raylib.LoadTexture("Pixel/Chat.png");
    Texture2D EvilGuyTexture = Raylib.LoadTexture("Pixel/evil.png");



    static public bool Talking = false;
    Rectangle spriteBox = new Rectangle(5, 0, 1500, 900);
    Rectangle evilBox = new Rectangle(1250, 100, 200, 200);
    Rectangle TomBox = new Rectangle(120, 150, 400, 400);
    Rectangle MeBox = new Rectangle(1020, 150, 400, 400);

    int tomMood = 0;
    public Minigame minigame;









    List<Texture2D> TomTexture = new List<Texture2D>{
        Raylib.LoadTexture("Pixel/Alex_Closeup.png"),
        Raylib.LoadTexture("Pixel/Alex_CloseupThinking.png"),
        Raylib.LoadTexture("Pixel/Alex_CloseupHappy.png"),
    };

    //  List<Texture2D> TomTexture = new List<Texture2D>
    // {
    //     Raylib.LoadTexture("Pixel/Tom_Closeup.png"),
    //     Raylib.LoadTexture("Pixel/Tom_CloseupThinking.png"),
    //     Raylib.LoadTexture("Pixel/Tom_CloseupHappy.png"),

    // };

    List<string> Chat1 = new List<string>{
            "Bartender:  Hello there! I'm Tom! Welcome to my bar!",
            "You:  Hello! Why is it so empty?",
            "Tom:  I have used all my money to feed my little sisters so i have not had any money over to furnish the place sadly... Although i was just about meet with this man who might be able to help me! Ive been waiting to meet with him for months now, and now he finally had a few minutues free! This place is finally gonna look the way i always imagined it would..",
            "You:  I meant empty as in lack of people",
            "Tom:  Oh! Thats awkward hehe. Thats probably because it is only 9 in the morning here, im guessing youre not from this planet?",
            "You:  No..My ship crashed and im trying to find a way to get home",
            "Tom:  That's tough luck. I'm really sorry to hear that...tell you what, you get me five batteries and you can take my ship. Dont worry about the furniture, ill be fine without it."


        };
    List<string> Chat2 = new List<string>{
            "Bartender:  You made it! Ill go start the ship, you can go hang out in the bar whilst i do so. Ill come get you when im done!",
            "You:  Great! Okay",
            "Tom:  ...",
            "You: Whos that?",
            "Tom: Dont worry about it. I have to go. DONT leave this bar",

        };




    public override void Start()
    {
        minigame.played = false;
        minigame.won = false;
    }

    public override void Update()
    {


        if (!choice && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && CurrentChat <= Chat1.Count - 1)
        { CurrentChat += 1; }

        else if (stage == 1 && CurrentChat >= Chat1.Count)
        { CurrentChat = 0; }
        else if (stage == 1 && CurrentChat >= Chat2.Count - 1)
        { CurrentChat = 0; }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
        { Talking = false; }

        if (choice && Raylib.IsKeyPressed(KeyboardKey.KEY_ONE))
        {
            isMinigameActive = true;
            CurrentChat = 0;
        }

        if (player.spriteBox.y > 450 && player.spriteBox.y < 530 && player.spriteBox.x > 430 && player.spriteBox.x < 1030 && Raylib.IsKeyPressed(KeyboardKey.KEY_E))
        { Talking = true; }

        if (CurrentChat == 2 && stage == 0)
        {
            tomMood = 1;
        }
        if (CurrentChat == 3 && stage == 0)
        {
            tomMood = 0;
        }
        if (CurrentChat == 4 && stage == 0)
        {
            tomMood = 2;
        }
        if (CurrentChat == 6 && stage == 0)
        {
            choice = true;

        }

        if (CurrentChat > Chat1.Count&&minigame.played==false)
        {
            Talking = false;
        }
        if (CurrentChat > Chat2.Count&&minigame.played==true)
        {
            Talking = false;
        }

        if (CurrentChat % 2 == 0)
        {
            me = false;
        }

        else if (CurrentChat % 2 == 1)
        {
            me = true;
        }

        if (CurrentChat >= 3 && stage == 1)
        {

            still = true;



            if (evilBox.y <= 600)
            {
                evilBox.y += 10;
            }

            else { left = true; }


            if (CurrentChat >= 3 && stage == 1 && left)
            {

                if (evilBox.x >= 670)
                {
                    evilBox.x -= 10;
                }

                if (evilBox.x <= 675)
                {
                    if (evilBox.y <= 930)
                        evilBox.y += 10;

                }
            }

        }

        if (evilBox.y >= 910 && minigame.played)
        {
            stage = 2;
            Talking = false;
        }



    }
    public override void Draw()
    {



        if (Talking && still == false)
        {
            if (stage == 0)
            {
                Raylib.DrawText("Press E to interact", 0, 10, 25, Color.WHITE);
                if (!me) { Raylib.DrawTexturePro(TomTexture[tomMood], new Rectangle(0, 0, TomTexture[0].width, TomTexture[0].height), TomBox, Vector2.Zero, 0f, Color.WHITE); }
                if (me) { Raylib.DrawTexturePro(Raylib.LoadTexture("Pixel/Main_Closeup.png"), new Rectangle(0, 0, TomTexture[0].width, TomTexture[0].height), MeBox, Vector2.Zero, 0f, Color.WHITE); }
                Raylib.DrawTexturePro(ChatTexture, new Rectangle(0, 0, ChatTexture.width, ChatTexture.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
                TextWrapper.DrawTextWithWordWrap(Chat1[CurrentChat], new Rectangle(100, 580, 1300, 400), 25, 2, Color.BLACK);
            }

            if (!choice && CurrentChat < 5 && !minigame.played)
            {
                Raylib.DrawText("[ESC] Goodbye", 1100, 740, 25, Color.BLACK);
                Raylib.DrawText("[ENTER] Continue", 170, 740, 25, Color.BLACK);
            }

            if (choice)
            {
                Raylib.DrawText("[ESC] Leave", 1100, 740, 25, Color.BLACK);
                Raylib.DrawText("[1] Look for batteries", 170, 740, 25, Color.BLACK);
            }



            if (minigame.won == false && minigame.played == true)
            {
                isMinigameActive = false;
                choice = true;
                Raylib.DrawTexturePro(ChatTexture, new Rectangle(0, 0, ChatTexture.width, ChatTexture.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
                TextWrapper.DrawTextWithWordWrap("you lost, wanna play again?", new Rectangle(100, 580, 1300, 400), 25, 2, Color.BLACK);
                Raylib.DrawText("[ESC] Goodbye", 1100, 740, 25, Color.BLACK);
                Raylib.DrawText("[1] yes", 170, 740, 25, Color.BLACK);

            }

            if (minigame.played && minigame.won)
            {
                choice = false;
                stage = 1;
                evilAppeared = true;
            }

            if (stage == 1)
            {
                Raylib.DrawText("Press E to interact", 0, 10, 25, Color.WHITE);
                if (CurrentChat < 5)
                {
                    if (!me) { Raylib.DrawTexturePro(TomTexture[tomMood], new Rectangle(0, 0, TomTexture[0].width, TomTexture[0].height), TomBox, Vector2.Zero, 0f, Color.WHITE); }
                    if (me) { Raylib.DrawTexturePro(Raylib.LoadTexture("Pixel/Main_Closeup.png"), new Rectangle(0, 0, TomTexture[0].width, TomTexture[0].height), MeBox, Vector2.Zero, 0f, Color.WHITE); }
                    Raylib.DrawTexturePro(ChatTexture, new Rectangle(0, 0, ChatTexture.width, ChatTexture.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
                    TextWrapper.DrawTextWithWordWrap(Chat2[CurrentChat], new Rectangle(100, 580, 1300, 400), 25, 2, Color.BLACK);
                }
            }

        }

        if (stage == 1) { if (evilAppeared) { Raylib.DrawTexturePro(EvilGuyTexture, new Rectangle(0, 0, EvilGuyTexture.width, EvilGuyTexture.height), evilBox, Vector2.Zero, 0f, Color.WHITE); } }

        // if(stage==2){
        //     Raylib.DrawTexturePro(EvilGuyTexture, new Rectangle(0, 0, EvilGuyTexture.width, EvilGuyTexture.height), evilBox, Vector2.Zero, 0f, Color.WHITE);

        // }


    }


}