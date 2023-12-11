using Raylib_cs;
using System.Numerics;


namespace Gymnasiearbete;

public class Ending : Thing
{
    bool tomhidden = true;
    bool talk = false;

    bool killedtom = false;
    bool timestart = false;

    bool chosefamily = false;

    bool hidetext = false;
    bool killedfamily = false;
    bool shotfamily = false;
    bool shottom = false;

    int CurrentChat = 0;
    int CurrentChat2 = 0;

    public bool me = false;

    int next = 0;

    int currentcolor = 0;

    List<Color> colors = new List<Color>{

     new Color(0, 0, 0, 255),
     new Color(71, 21, 21, 255)

    };





    int timeindex = 0;



    Texture2D family = Raylib.LoadTexture("Pixel/Family.png");
    Texture2D shot = Raylib.LoadTexture("Pixel/shot.png");
    Texture2D familydead = Raylib.LoadTexture("Pixel/deadfamily.png");
    //Texture2D tom = Raylib.LoadTexture("Pixel/Tom.png");
    //Texture2D tomdead = Raylib.LoadTexture("Pixel/Tomdead.png");

    Texture2D evil = Raylib.LoadTexture("Pixel/evil.png");
    Texture2D evilshot = Raylib.LoadTexture("Pixel/evilshot.png");
    Texture2D Me = Raylib.LoadTexture("Pixel/Idle_Main.png");

    Texture2D tom = Raylib.LoadTexture("Pixel/Alex.png");
    Texture2D tomdead = Raylib.LoadTexture("Pixel/alexdead.png");
    Texture2D DEADTOM1 = Raylib.LoadTexture("Pixel/cutscene1.png");
    Texture2D winter = Raylib.LoadTexture("Pixel/cutscene3.png");
    Texture2D end = Raylib.LoadTexture("Pixel/cutscene4.png");
    Texture2D DEADFAMILY1 = Raylib.LoadTexture("Pixel/cutscene2.png");



    Texture2D ChatTexture = Raylib.LoadTexture("Pixel/Chat1.png");
    List<string> Chat = new List<string>{
        "Crazy man:  Have you ever heard of the trolley problem?",

        "  You:  I might have..",

        "Crazy man:  Its the one where you find yourself walking by a railway, and see five people tied to the tracks. There is a lever nearby that you can switch, causing the train to change paths, killing a singular person who is tied to the second track. What do you do?",

        "  You:  Why are you asking me this?",

        "Crazy man:  Let's bring this theory to reality. I've got 3 hostages and I am going to kill them. I saw you speaking to that bartender in there, so i am giving you a choice, you can choose to do nothing, and these innocent people will die, OR you can get your buddy to come here, so that you can murder him. ",

        "  You:  Youre insane! There has to be another way to resolve this.",

        "Crazy man:  Life doesn't always offer easy choices. Decide now, or they die.",

        "  You:  Please, there has to be another solution. Let's talk about this. Shooting anyone won't solve anything.",

        "Crazy man:  Choices have consequences, my friend. Make yours.",

        "PRESS 1 TO GET TOM OUT HERE. PRESS 2 TO LET THE INNOCENTS DIE."


    };

    List<string> ChatTom = new List<string>{
        "You left the planet soon after the incident, you made sure to bury Tom first. You made a promise to yourself never to return. After his death his sisters, Alice and Isabelle, visited his grave every night, they still do not know what happend to him. They spend their night wondering what they could have done to stop it. Alice goes out at night and steals food for them to eat, she usually doesnt find much. The crazy man left town to find his next victim, he would go on killing people this exact way for another 5 years. When he finally got caught, the cops realized what he had done and how many people he had killed and killed him immediately, altough the reports say he got hit by a car trying to escape",
        "The girls, being as young as they were, did not survive the winter."
    };
    List<string> ChatFamily = new List<string>{
        "The three victims, Sam, John and Sophie were buried by their family. Sam and John had several children together who ended up being seperated and sent to different foster homes, they never recovered after their parents brutal death. The youngest of the children became an addict and died at a young age whilst the last children ended up with severe mental problems. Sophies family, which consisted of her parents and multiple siblings, never stopped missing her. They keep her room tidy and still puts out a plate for her at the dinner table.  ",
        "You wanted to attend the funeral but couldnt, the guilt became too much, you went on meeting with multiple therapists before you ultimately killed yourself."
    };

    List<string> ChatTom2 = new List<string>{
        "Tom: Im done fixing up the ship! Lets get you home to your family",
        "You:  Thank you...youve been a great friend..."
    };

    Rectangle spriteBox = new Rectangle(5, -600, 1500, 900);
    Rectangle screen = new Rectangle(0, 0, 1500, 900);


    Rectangle TomBox = new Rectangle(910, 250, 170, 170);
    Rectangle FamilyBox = new Rectangle(1200, 600, 200, 200);

    Rectangle EvilBox = new Rectangle(1100, 400, 150, 150);
    Rectangle MeBox = new Rectangle(970, 300, 150, 150);
    public override void Start()
    {

        Text.Talking = true;
        talk = true;

    }

    public override void Update()
    {

        if (CurrentChat % 2 == 0)
        {
            me = false;
            currentcolor = 1;
        }
        if (CurrentChat % 2 == 1)
        {
            me = true;
            currentcolor = 0;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && CurrentChat <= Chat.Count - 2 && tomhidden)
        { CurrentChat += 1; }

        if (!tomhidden)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && CurrentChat2 <= ChatTom2.Count - 2)
            { CurrentChat2 += 1; }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && next <= 1 && (killedfamily || killedtom))
        {
            next++;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && CurrentChat == 9)
        { tomhidden = false; }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) && CurrentChat == 9)
        {
            timestart = true;
            hidetext = true;
            chosefamily = true;
        }


        if (!tomhidden && !chosefamily)
        {

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && CurrentChat2 >= ChatTom2.Count - 1)
            {
                timestart = true;
                hidetext = true;
            }

            if (timestart)
            {

                timeindex++;

                if (timeindex == 10)
                {
                    if (shotfamily == false && shottom == false)
                    {
                        timestart = false;
                        shottom = true;
                    }
                }
            }

            if (shottom)
            {

                timeindex++;

                if (timeindex == 100)
                {
                    killedtom = true;
                }
            }


        }


        if (timestart && chosefamily)
        {
            timeindex++;
            if (timeindex == 10)
            {
                if (shotfamily == false && shottom == false)
                {
                    timestart = false;
                    shotfamily = true;
                }
            }
        }

        if (shotfamily)
        {
            timeindex++;
            if (timeindex == 60)
            {
                killedfamily = true;
            }
        }



        if (TomBox.y < 600 && tomhidden == false) { TomBox.y += 5; }
        else if (TomBox.y >= 550 && tomhidden == false)
        {

        }




    }
    public override void Draw()
    {
        if (!killedtom && !killedfamily)
        {


            if (!shotfamily) { Raylib.DrawTexturePro(family, new Rectangle(0, 0, family.width, family.height), FamilyBox, Vector2.Zero, 0f, Color.WHITE); }
            if (shotfamily) { Raylib.DrawTexturePro(familydead, new Rectangle(0, 0, family.width, family.height), FamilyBox, Vector2.Zero, 0f, Color.WHITE); }
            Raylib.DrawTexturePro(evil, new Rectangle(0, 0, evil.width, evil.height), EvilBox, Vector2.Zero, 0f, Color.WHITE);
            if (timestart && chosefamily) { Raylib.DrawTexturePro(evilshot, new Rectangle(0, 0, evil.width, evil.height), EvilBox, Vector2.Zero, 0f, Color.WHITE); }
            if (timestart && !tomhidden) { Raylib.DrawTexturePro(shot, new Rectangle(0, 0, evil.width, evil.height), MeBox, Vector2.Zero, 0f, Color.WHITE); }
            Raylib.DrawTexturePro(Me, new Rectangle(0, 0, Me.width, Me.height), MeBox, Vector2.Zero, 0f, Color.WHITE);

            if (TomBox.y >= 550 && tomhidden == false)
            {
                Raylib.DrawTexturePro(ChatTexture, new Rectangle(0, 0, ChatTexture.width, ChatTexture.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
                TextWrapper.DrawTextWithWordWrap(ChatTom2[CurrentChat2], new Rectangle(100, 60, 1300, 400), 25, 2, colors[currentcolor]);

                if (CurrentChat2 == 0) { Raylib.DrawText("[ENTER] Kill Tom", 120, 150, 25, Color.BLACK); }
            }

            if (tomhidden == false)
            {
                if (!shottom) { Raylib.DrawTexturePro(tom, new Rectangle(0, 0, tom.width, tom.height), TomBox, Vector2.Zero, 0f, Color.WHITE); }
                if (shottom) { Raylib.DrawTexturePro(tomdead, new Rectangle(0, 0, tom.width, tom.height), TomBox, Vector2.Zero, 0f, Color.WHITE); }
            }
        }

        if (talk && tomhidden && !hidetext)
        {
            Raylib.DrawTexturePro(ChatTexture, new Rectangle(0, 0, ChatTexture.width, ChatTexture.height), spriteBox, Vector2.Zero, 0f, Color.WHITE);
            TextWrapper.DrawTextWithWordWrap(Chat[CurrentChat], new Rectangle(100, 60, 1300, 400), 25, 2, colors[currentcolor]);
            if (CurrentChat < 9) { Raylib.DrawText("[ENTER] Continue", 120, 150, 25, Color.BLACK); }

            if (CurrentChat == 9)
            {
                TextWrapper.DrawTextWithWordWrap(Chat[CurrentChat], new Rectangle(100, 60, 1300, 400), 25, 2, Color.RED);
                Raylib.DrawText("[1] kill tom", 150, 150, 25, Color.RED);
                Raylib.DrawText("[2] kill the family", 400, 150, 25, Color.RED);

            }

        }

        if (killedtom)
        {

            Raylib.DrawRectangle(0, 0, 100, 100, Color.RED);
            Raylib.DrawTexturePro(DEADTOM1, new Rectangle(0, 0, 300, 180), screen, Vector2.Zero, 0, Color.WHITE);

            TextWrapper.DrawTextWithWordWrap(ChatTom[0], new Rectangle(150, 600, 1300, 400), 25, 2, Color.WHITE);

            if (next == 1)
            {
                Raylib.DrawTexturePro(winter, new Rectangle(0, 0, DEADTOM1.width, DEADTOM1.height), screen, Vector2.Zero, 0f, Color.WHITE);
                TextWrapper.DrawTextWithWordWrap(ChatTom[1], new Rectangle(150, 600, 1300, 400), 25, 2, Color.WHITE);
            }

            if (next == 2)
            {
                Raylib.DrawTexturePro(end, new Rectangle(0, 0, DEADTOM1.width, DEADTOM1.height), screen, Vector2.Zero, 0f, Color.WHITE);
                TextWrapper.DrawTextWithWordWrap("THE END", new Rectangle(700, 500, 1300, 400), 25, 2, Color.RED);
            }
        }

        if (killedfamily)
        {

            Raylib.DrawTexturePro(DEADFAMILY1, new Rectangle(0, 0, DEADTOM1.width, DEADTOM1.height), screen, Vector2.Zero, 0f, Color.WHITE);
            TextWrapper.DrawTextWithWordWrap(ChatFamily[0], new Rectangle(150, 650, 1300, 400), 25, 2, Color.WHITE);

            if (next == 1)
            {
                Raylib.DrawTexturePro(winter, new Rectangle(0, 0, DEADTOM1.width, DEADTOM1.height), screen, Vector2.Zero, 0f, Color.WHITE);
                TextWrapper.DrawTextWithWordWrap(ChatFamily[1], new Rectangle(150, 650, 1300, 400), 25, 2, Color.WHITE);
            }

            if (next == 2)
            {
                Raylib.DrawTexturePro(end, new Rectangle(0, 0, DEADTOM1.width, DEADTOM1.height), screen, Vector2.Zero, 0f, Color.WHITE);
                TextWrapper.DrawTextWithWordWrap("THE END", new Rectangle(700, 500, 1300, 400), 25, 2, Color.RED);
            }
        }


    }


}