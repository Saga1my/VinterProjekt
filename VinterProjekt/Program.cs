using Raylib_cs;
using System.Numerics;


Raylib.InitWindow(1280, 720, "SPEL :D");
Raylib.SetTargetFPS(60);

int currentScene = 1;
bool jamesSedd = false;
bool val_1 = false;
bool val_2 = false;
bool Continue = false;
bool bossFight = false;
bool JamesIsHurting = false;
bool JamesHasBeenHurt = false;
bool still = false;
bool letar = false;



int timeJamesIsHurt = (int)(0.2 * 60);
int JamesHurtTimeLeft = timeJamesIsHurt;

List<Texture2D> backgrounds = new List<Texture2D>();
foreach (string path in Directory.GetFiles("Bilder/backgrounds"))
{
    backgrounds.Add(Raylib.LoadTexture(path));
}
Console.WriteLine(backgrounds);

Dictionary<string, Texture2D> JamesTextures = new Dictionary<string, Texture2D> {
    {"black", Raylib.LoadTexture("Bilder/JamesBlack.png")},
    {"normal", Raylib.LoadTexture("Bilder/JamesNormal.png")},
    {"hurt", Raylib.LoadTexture("Bilder/JamesHurt.png")},
    {"right", Raylib.LoadTexture("Bilder/JamesRight.png")}
};

Dictionary<string, Texture2D> SagaTextures = new Dictionary<string, Texture2D> {
    {"avatar", Raylib.LoadTexture("Bilder/FrontViewSaga.png")},
    {"back", Raylib.LoadTexture("Bilder/BackViewSaga.png")},
    {"left", Raylib.LoadTexture("Bilder/LeftViewSaga.png")},
    {"right", Raylib.LoadTexture("Bilder/RightViewSaga.png")}
};

Texture2D CurrentTexture = SagaTextures["avatar"];
Texture2D CurrentJames = JamesTextures["black"];


Rectangle character = new Rectangle(Raylib.GetScreenWidth() / 3, Raylib.GetScreenHeight() / 2, 100, 100);
Rectangle James = new Rectangle(980, 300, 100, 100);
Rectangle Source = new Rectangle(0, 0, backgrounds[0].width, backgrounds[0].height);
Rectangle Destination = new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
Rectangle TextBox = new Rectangle(40, 550, 1200, 140);

//LOGIK

while (!Raylib.WindowShouldClose())
{



    if (character.y < 5)
    {
        currentScene += 1;
        character.y = 500;
        Continue = false;
        val_1 = false;
        val_2 = false;


    }

    if (character.y > 600)
    {
        currentScene -= 1;
        character.y = 500;
        Continue = false;

    }

    walk();

    draw();



    if (currentScene == 2 && character.x > 700)
    {
        James.x += 5;
        jamesSedd = true;
    }

    if (currentScene == 3)
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE) && val_2 == false && Continue == false)
        {
            val_1 = true;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_TWO) && val_1 == false && Continue == false)
        {
            val_2 = true;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            Continue = true;
        }

    }

    if (currentScene == 7)
    {
        if (character.y <= 300&&Continue==false&&letar==false)
        {
            still = true;
            CurrentTexture = SagaTextures["back"];
        }

        if (JamesHasBeenHurt == false)
        {
            James.x = 440;
            James.y = 40;
        }

        bossFight = true;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            Continue = true;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE))
        {
            val_1 = true;
            val_2 = false;
            CurrentJames=JamesTextures["normal"];
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)){
            Continue=true;
            
        }


        if (Raylib.IsKeyDown(KeyboardKey.KEY_TWO))
        {
            val_2 = true;

            if (JamesIsHurting == false && JamesHasBeenHurt == false)
            {
                JamesHurtTimeLeft = timeJamesIsHurt;
                JamesIsHurting = true;
            }
        }

        //frej hjälpt till med att få figuren att blinka

    }



    if (JamesIsHurting)
    {
        CurrentJames = JamesTextures["hurt"];
        JamesHurtTimeLeft--;
    }
    if (JamesHasBeenHurt == false && JamesHurtTimeLeft <= 0)
    {
        CurrentJames = JamesTextures["black"];
        JamesIsHurting = false;
        JamesHasBeenHurt = true;
        
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
    {
        Continue = true;
    }

    if (JamesHasBeenHurt && Continue == true)
    {
    
    }

}

//RITA 

void draw()

{
    Raylib.BeginDrawing();

    Raylib.DrawTexturePro(backgrounds[currentScene - 1], Source, Destination, new Vector2(0, 0), 0, Color.WHITE);

    Raylib.DrawTexture(CurrentTexture, (int)character.x, (int)character.y, Color.WHITE);

    if (currentScene == 1 && character.y > 200&&letar==false)
    {

        Raylib.DrawRectangleRec(TextBox, Color.BLACK);
        Raylib.DrawText("Du är ute på en promenad för att njuta av det vackra vädret! Klicka på W,A,S,D för att röra på dig!", 70, 575, 20, Color.WHITE);
    }

    if (currentScene == 2 && bossFight == false)
    {


        Raylib.DrawTexture(CurrentJames, (int)James.x, (int)James.y, Color.WHITE);
        if (jamesSedd == false && character.y < 500 && character.x < 700&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Du ser en mörk skugga stirra på dig från bakom ett träd. I hans hand ser du något gult glimmra. Du blir nyfiken.", 70, 575, 20, Color.WHITE);
        }
        if (character.x > 700&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("När du försöker gå närmare springer han iväg. Fegis. ", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Du antar att det var någon galen muterad ekorre och fortsätter din promenad. ", 70, 600, 20, Color.WHITE);
        }

    }

    if (currentScene == 3&&letar==false)
    {
        Raylib.DrawRectangleRec(TextBox, Color.BLACK);
        Raylib.DrawText("Du ser en gul pöl på marken. Du undrar vad det är för något.", 70, 575, 20, Color.WHITE);
        Raylib.DrawText("Klicka på 1 för att peta i det eller 2 för att smaka på det. Du kan också bara gå därifrån.", 70, 650, 20, Color.WHITE);

        if (val_2 == true)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Vem fan smakar direkt?", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Som tur var den myskiska gula sörjan olivolja. men det kunde lika gärna varit piss..", 70, 600, 20, Color.WHITE);
            Raylib.DrawText("Klicka ENTER för att fortsätta", 70, 650, 20, Color.WHITE);
        }

        if (val_1 == true)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Den gula sörjan känns tjock. som olja...", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Du luktar på det och kommer till slutsats att det troligtvis är olivolja.", 70, 600, 20, Color.WHITE);
            Raylib.DrawText("Klicka ENTER för att fortsätta", 70, 650, 20, Color.WHITE);
        }

        if (Continue == true && (val_1 == true || val_2 == true))
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Men vad gör olivolja i mitten av skogen? Du beslutar dig för att följa efter fotspåren du ser på marken", 70, 575, 20, Color.WHITE);
        }

        else if (Continue == true)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText(" Du beslutar dig för att följa efter fotspåren du ser på marken. trots att det troligtvis är piss.", 70, 575, 20, Color.WHITE);
        }
    }
    if (currentScene == 7)
    {
        Raylib.DrawTexture(CurrentJames, (int)James.x, (int)James.y, Color.WHITE);
        if (character.y < 300&&Continue==false&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Okänd person:  Vill du smaka...min avocado...", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka 1 för att smaka, och 2 för att inte göra det", 70, 650, 20, Color.WHITE);
        }
        if (val_2&&val_1==false&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Okänd person: ..SMAKA.. avocado...", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka 1 för att smaka avocado eller 2 för att kasta en sten på den okända figuren", 70, 650, 20, Color.WHITE);
            

        }

        if (val_1&&Continue==false&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Oj jag trodde ej du skulle säga ja, ehh jag har ej allt jag behöver här, kan du leta efter det åt mig?", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka ENTER för att säga ja (du har inget val)", 70, 650, 20, Color.WHITE);
            
          
        }
        

        if (JamesHasBeenHurt == true&&Continue==false&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Okänd person: Ow varför gjorde du så :C Jag ville bara dela med mig av min avocado", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka ENTER för att för att säga förlåt och smaka hans avocado", 70, 650, 20, Color.WHITE);
        }
       
        if (Continue==true){
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Det jag behöver är:", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("2 st avokader, 1 pöl olja och 5 st chili flakes", 70, 600, 20, Color.WHITE);
            Raylib.DrawText("Jag kommer till dig när du hittat allt", 70, 650, 20, Color.WHITE);
            still=false;
            letar=true;
        }
    
    }
    //Raylib.DrawRectangleRec(TextBox, Color.BLACK); 
    //Raylib.DrawText("", 70, 575, 20, Color.WHITE);


    Raylib.EndDrawing();

}



void walk()
{
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && still == false)
    {
        if (!(currentScene >= 7 && character.y <= 10))
        {
            character.y -= 7;
            CurrentTexture = SagaTextures["back"];
        }
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && still == false)
    {
        if (!(character.x < 2))
        {
            character.x -= 7;
            CurrentTexture = SagaTextures["left"];
        }
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && still == false)
    {
        if (!(currentScene <= 1 && character.y >= Raylib.GetScreenHeight() - SagaTextures["avatar"].height))
        {
            character.y += 7;
            CurrentTexture = SagaTextures["avatar"];
        }
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && still == false)
    {
        if (!(character.x >= Raylib.GetScreenWidth() - SagaTextures["avatar"].width))
        {

            character.x += 7;
            CurrentTexture = SagaTextures["right"];
        }
    }
}

