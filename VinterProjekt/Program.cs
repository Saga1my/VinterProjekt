using Raylib_cs;
using System.Numerics;


Raylib.InitWindow(1280, 720, "SPEL :D");
Raylib.SetTargetFPS(60);

int currentScene = 1;
bool jesusSedd = false;
bool val_1 = false;
bool val_2 = false;
bool Continue = false;
bool JesusIsHurting = false;
bool JesusHasBeenHurt = false;
bool still = false;
bool letar = false;
bool IsInventoryOpen = false;
bool frejoffrad = false;
bool mobbatAxel = false;
bool tagitAvocado = false;
bool tagitVatten = false;
bool tagitAllt = false;




int timeJesusIsHurt = (int)(0.2 * 60);
int JesusHurtTimeLeft = timeJesusIsHurt;
int WalkingAnimation = 0;
int WalkingAnimationIndex = 0;
int inventoryI = 0;



List<Texture2D> backgrounds = new List<Texture2D>();
foreach (string path in Directory.GetFiles("Bilder/backgrounds"))
{
    backgrounds.Add(Raylib.LoadTexture(path));
}
Console.WriteLine(backgrounds);

Dictionary<string, Texture2D> JesusTextures = new Dictionary<string, Texture2D> {
    {"black", Raylib.LoadTexture("Bilder/JesusBlack.png")},
    {"normal", Raylib.LoadTexture("Bilder/JesusNormal.png")},
    {"hurt", Raylib.LoadTexture("Bilder/JesusHurt.png")},
};

Dictionary<string, Texture2D> SagaTextures = new Dictionary<string, Texture2D> {
    {"avatar", Raylib.LoadTexture("Bilder/FrontViewSaga.png")},
    {"back", Raylib.LoadTexture("Bilder/BackViewSaga.png")},
    {"left", Raylib.LoadTexture("Bilder/LeftViewSaga.png")},
    {"right", Raylib.LoadTexture("Bilder/RightViewSaga.png")}
};

List<Texture2D> SagaWalkingRight = new List<Texture2D>();
SagaWalkingRight.Add(Raylib.LoadTexture("Bilder/SagaWalkingRight1.png"));
SagaWalkingRight.Add(Raylib.LoadTexture("Bilder/RightViewSaga.png"));
SagaWalkingRight.Add(Raylib.LoadTexture("Bilder/SagaWalkingRight1.png"));
SagaWalkingRight.Add(Raylib.LoadTexture("Bilder/RightViewSaga.png"));



List<Texture2D> SagaWalkingLeft = new List<Texture2D>();
SagaWalkingLeft.Add(Raylib.LoadTexture("Bilder/SagaWalkingLeft1.png"));
SagaWalkingLeft.Add(Raylib.LoadTexture("Bilder/LeftViewSaga.png"));
SagaWalkingLeft.Add(Raylib.LoadTexture("Bilder/SagaWalkingLeft1.png"));
SagaWalkingLeft.Add(Raylib.LoadTexture("Bilder/LeftViewSaga.png"));

List<Texture2D> SagaWalkingUp = new List<Texture2D>();
SagaWalkingUp.Add(Raylib.LoadTexture("Bilder/SagaWalkingUp1.png"));
SagaWalkingUp.Add(Raylib.LoadTexture("Bilder/BackViewSaga.png"));
SagaWalkingUp.Add(Raylib.LoadTexture("Bilder/SagaWalkingUp2.png"));
SagaWalkingUp.Add(Raylib.LoadTexture("Bilder/BackViewSaga.png"));

List<Texture2D> SagaWalkingDown = new List<Texture2D>();
SagaWalkingDown.Add(Raylib.LoadTexture("Bilder/SagaWalkingDown1.png"));
SagaWalkingDown.Add(Raylib.LoadTexture("Bilder/FrontViewSaga.png"));
SagaWalkingDown.Add(Raylib.LoadTexture("Bilder/SagaWalkingDown2.png"));
SagaWalkingDown.Add(Raylib.LoadTexture("Bilder/FrontViewSaga.png"));

Texture2D CurrentTexture = SagaTextures["avatar"];
Texture2D CurrentJesus = JesusTextures["black"];
Texture2D InventoryTexture = Raylib.LoadTexture("Bilder/SagaInventory.png");
Texture2D OpenInventoryTexture = Raylib.LoadTexture("Bilder/SagaInventoryOpen.png");
Texture2D ErikaOchElliot = Raylib.LoadTexture("Bilder/ErikaOchElliot.png");
Texture2D AxelTexture = Raylib.LoadTexture("Bilder/Axel.png");
Texture2D FrejTexture = Raylib.LoadTexture("Bilder/frej.png");
Texture2D VattenGlasTexture = Raylib.LoadTexture("Bilder/vattenglas.png");
Texture2D AvocadoTexture = Raylib.LoadTexture("Bilder/Avocado.png");
Texture2D FrejDeadTexture = Raylib.LoadTexture("Bilder/frejDead.png");
Texture2D JenniferTexture = Raylib.LoadTexture("Bilder/jennifer.png");
Texture2D SebastianTexture = Raylib.LoadTexture("Bilder/sebastian.png");
Texture2D LokeUtanAvokado = Raylib.LoadTexture("Bilder/LokeUtanAvokado.png");
Texture2D LokeMedAvokado = Raylib.LoadTexture("Bilder/LokeMedAvokado.png");
Texture2D himlen = Raylib.LoadTexture("Bilder/himlen.png");


Rectangle character = new Rectangle(Raylib.GetScreenWidth() / 3, Raylib.GetScreenHeight() / 2, 100, 100);
Rectangle Jesus = new Rectangle(980, 300, 100, 100);
Rectangle Source = new Rectangle(0, 0, backgrounds[0].width, backgrounds[0].height);
Rectangle Destination = new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
Rectangle ElliotOchErikaBox = new Rectangle(800, 70, 100, 100);
Rectangle LokeRec = new Rectangle(100, 300, 100, 100);
Rectangle FrejRec = new Rectangle(100, 300, 100, 100);
Rectangle AxelRec = new Rectangle(100, 300, 100, 100);
Rectangle JenniferRec = new Rectangle(150, 200, 100, 100);
Rectangle SebatsianRec = new Rectangle(650, 300, 100, 100);
Rectangle TextBox = new Rectangle(40, 550, 1200, 140);
Rectangle InventoryTextBox = new Rectangle(40, 20, 500, 600);
Rectangle Inventory = new Rectangle(5, 5, 50, 50);
Rectangle InventoryOpen = new Rectangle(700, 15, 10, 10);


while (!Raylib.WindowShouldClose())
{


    // Console.WriteLine(Continue);


    if (character.y < 5)
    {
        currentScene += 1;
        character.y = 500;
        Continue = false;
        val_1 = false;
        val_2 = false;


    }

    if (character.y > 700)
    {
        currentScene -= 1;
        character.y = 100;
        Continue = false;
        val_1 = false;
        val_2 = false;

    }

    if(tagitAvocado&&tagitVatten&&frejoffrad){
        tagitAllt = true;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_I))
    {
        inventoryI++;
        if (inventoryI >= 2)
        {
            inventoryI = 0;
        }

    }
    if (inventoryI == 1)
    {
        IsInventoryOpen = true;
    }
    else { IsInventoryOpen = false; }

    walk();
     
    val();

    draw();



    if (currentScene == 2 && character.x > 700)
    {
        Jesus.x += 5;
        jesusSedd = true;
    }



  


    if (currentScene == 7)
    {
        if (character.y <= 300 && Continue == false && letar == false)
        {
            still = true;
            CurrentTexture = SagaTextures["back"];
        }

        if (JesusHasBeenHurt == false)
        {
            Jesus.x = 440;
            Jesus.y = 40;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE))
        {
            val_1 = true;
            val_2 = false;
        }



        if (Raylib.IsKeyDown(KeyboardKey.KEY_TWO))
        {
            val_2 = true;

            if (JesusIsHurting == false && JesusHasBeenHurt == false)
            {
                JesusHurtTimeLeft = timeJesusIsHurt;
                JesusIsHurting = true;
            }
        }

        if (JesusIsHurting)
        {
            CurrentJesus = JesusTextures["hurt"];
            JesusHurtTimeLeft--;
        }
        if (JesusHasBeenHurt == false && JesusHurtTimeLeft <= 0)
        {
            CurrentJesus = JesusTextures["black"];
            JesusIsHurting = false;
            JesusHasBeenHurt = true;

        }

        if (JesusHasBeenHurt && Continue == true)
        { }
        //frej hjälpt till med att få figuren att blinka
    }

}

//RITA 

void draw()

{
    Raylib.BeginDrawing();

    Raylib.DrawTexturePro(backgrounds[currentScene - 1], Source, Destination, new Vector2(0, 0), 0, Color.WHITE);

    Raylib.DrawTexture(CurrentTexture, (int)character.x, (int)character.y, Color.WHITE);

    if (!IsInventoryOpen)
    {
        Raylib.DrawTexture(InventoryTexture, (int)Inventory.x, (int)Inventory.y, Color.WHITE);
    }

    if (IsInventoryOpen)
    {
        Raylib.DrawTexture(OpenInventoryTexture, (int)InventoryOpen.x, (int)InventoryOpen.y, Color.WHITE);
        Raylib.DrawRectangleRec(InventoryTextBox, Color.BLACK);
        Raylib.DrawText("I din väska har du just nu:", 55, 40, 20, Color.WHITE);
        Raylib.DrawText("-Alvedon som smälter på tungan ", 55, 70, 20, Color.WHITE);
        Raylib.DrawText("-Skoldator ", 55, 100, 20, Color.WHITE);
        Console.WriteLine(Continue);
        Console.WriteLine(val_1);
        if (frejoffrad)
        {
            Raylib.DrawText("-En död frej", 55, 130, 20, Color.WHITE);
            Raylib.DrawTexture(FrejDeadTexture, 900, 470, Color.WHITE);
        }

        if (tagitAvocado)
        {
            Raylib.DrawText("-Avocado", 55, 160, 20, Color.WHITE);
            Raylib.DrawTexture(AvocadoTexture, 845, 320, Color.WHITE);
        }
        if (tagitVatten)
        {
            Raylib.DrawText("-Ett glas vatten", 55, 190, 20, Color.WHITE);
            Raylib.DrawTexture(VattenGlasTexture, 980, 410, Color.WHITE);
        }
    }


    if (currentScene == 1 && !IsInventoryOpen)
    {
        if (letar == false && character.y > 200)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Du är ute på en promenad för att njuta av det vackra vädret!", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka på W,A,S,D för att röra på dig och I för att öppna eller stänga ditt inventory", 70, 600, 20, Color.WHITE);
        }


        if (letar == true)
        {
            Raylib.DrawTexture(JenniferTexture, (int)JenniferRec.x, (int)JenniferRec.y, Color.WHITE);
            if (Raylib.CheckCollisionRecs(character, JenniferRec))
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Jennifer:", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Hej! Ett glas vatten? Ja det har jag! Här!", 70, 600, 20, Color.WHITE);
                Raylib.DrawText("*jennifer gav dig ett glas med vatten*", 70, 650, 20, Color.WHITE);
                tagitVatten=true;
            }
        }


    }

    if (currentScene == 2 && !IsInventoryOpen)
    {
        if (letar == true)
        {
            Raylib.DrawTexture(SebastianTexture, (int)SebatsianRec.x, (int)SebatsianRec.y, Color.WHITE);
            if (Raylib.CheckCollisionRecs(character, SebatsianRec))
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Sebastian:", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Vad som hände med alla vattenflaskor? Jag hann dricka upp dem precis innan du kom..hehe sorry...", 70, 600, 20, Color.WHITE);
                Raylib.DrawText("Klicka ENTER för att ifrågasätta varför han drack så jävla mycket vatten", 70, 650, 20, Color.WHITE);

                if (Continue)
                {
                    Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                    Raylib.DrawText("Sebastian:", 70, 575, 20, Color.WHITE);
                    Raylib.DrawText("Fuck you ", 70, 600, 20, Color.WHITE);
                }
            }
        }

        else
        {
            Raylib.DrawTexture(CurrentJesus, (int)Jesus.x, (int)Jesus.y, Color.WHITE);
            if (jesusSedd == false && character.y < 500 && character.x < 700 && letar == false)
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Du ser en mörk skugga stirra på dig från bakom ett träd. Du blir nyfiken.", 70, 575, 20, Color.WHITE);
            }
            if (character.x > 700 && letar == false)
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("När du försöker gå närmare springer han iväg. Fegis. ", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Du antar att det var någon galen muterad ekorre och fortsätter din promenad. ", 70, 600, 20, Color.WHITE);
            }
        }
    }

    if (currentScene == 3 && !IsInventoryOpen)
    {
        if (letar == true)
        {
            Raylib.DrawTexture(AxelTexture, (int)AxelRec.x, (int)AxelRec.y, Color.WHITE);
            if (Raylib.CheckCollisionRecs(character, AxelRec))
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Axel:", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("vad vill du", 70, 600, 20, Color.WHITE);
                Raylib.DrawText("Klicka 1 för att kalla axel dum eller 2 för att säga att loke vill att du skulle mobba honom", 70, 650, 20, Color.WHITE);

                if (val_1)
                {
                    Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                    Raylib.DrawText("Axel:", 70, 575, 20, Color.WHITE);
                    Raylib.DrawText("bitch", 70, 600, 20, Color.WHITE);
                    Raylib.DrawText("*Axel slår dig*", 70, 650, 20, Color.WHITE);
                    mobbatAxel=true;
                }

                if (val_2)
                {
                    Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                    Raylib.DrawText("Axel:", 70, 575, 20, Color.WHITE);
                    Raylib.DrawText("snitch", 70, 600, 20, Color.WHITE);
                    Raylib.DrawText("*Axel slår dig*", 70, 650, 20, Color.WHITE);
                }


            }
        }


        if (letar == false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Du ser en röd pöl på marken. Du undrar vad det är för något.", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka på 1 för att peta i det eller 2 för att smaka på det. Du kan också bara gå därifrån.", 70, 650, 20, Color.WHITE);

            if (val_2 == true)
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Vem fan smakar direkt?", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Som tur var den myskiska röda sörjan vin. men det kunde lika gärna varit blod..", 70, 600, 20, Color.WHITE);
                Raylib.DrawText("Klicka ENTER för att fortsätta", 70, 650, 20, Color.WHITE);
            }

            if (val_1 == true)
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Den röda sörjan känns som vatten...", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Du luktar på det och kommer till slutsats att det troligtvis är vin.", 70, 600, 20, Color.WHITE);
                Raylib.DrawText("Klicka ENTER för att fortsätta", 70, 650, 20, Color.WHITE);
            }

            if (Continue == true && (val_1 == true || val_2 == true))
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Men vad gör rödvin i mitten av skogen? Du beslutar dig för att följa efter fotspåren du ser på marken", 70, 575, 20, Color.WHITE);
            }

            else if (Continue == true)
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText(" Du beslutar dig för att följa efter fotspåren du ser på marken. trots att det troligtvis är blod.", 70, 575, 20, Color.WHITE);
            }
        }
    }

    if (currentScene == 4 && letar == true && !IsInventoryOpen)
    {
        if (frejoffrad == false&&(!val_2)) { Raylib.DrawTexture(FrejTexture, (int)FrejRec.x, (int)FrejRec.y, Color.WHITE); }

        if (Raylib.CheckCollisionRecs(character, FrejRec)){
            if (Continue == false && frejoffrad == false&&(!val_1)&&(!val_2))
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Frej:", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Hej hej varsågod för all hjälp med programmeringen!", 70, 600, 20, Color.WHITE);
                Raylib.DrawText("klicka 1 för att säga tack eller 2 för att offra honom till jesus kristus", 70, 650, 20, Color.WHITE);
            }

            if (val_1 == true&&Continue==false)
            {    Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Frej:", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Ingen fara :)", 70, 600, 20, Color.WHITE);
                Raylib.DrawText("klicka 2 för att offra honom till jesus kristus >:(", 70, 650, 20, Color.WHITE);
            }
                
            

            if (val_2 == true&&Continue==false)
            {
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawTexture(FrejDeadTexture, (int)FrejRec.x, (int)FrejRec.y, Color.WHITE);
                Raylib.DrawText("Frej:", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("*frej är nu död*", 70, 600, 20, Color.WHITE);
                Raylib.DrawText("klicka enter för att plocka upp honom", 70, 650, 20, Color.WHITE);
                frejoffrad=true;
            }

        }
    }

    if (currentScene == 6 && letar == true && IsInventoryOpen == false)
    {
        Raylib.DrawTexture(ErikaOchElliot, (int)ElliotOchErikaBox.x, (int)ElliotOchErikaBox.y, Color.WHITE);
        if (Raylib.CheckCollisionRecs(character, ElliotOchErikaBox))
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Erika och Elliot:", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Heeeeeeej! Dig känner vi igen. Vi såg dig gå mot Jesus där uppe. Jag hörde att du behövde ett glas vatten?", 70, 600, 20, Color.WHITE);
            Raylib.DrawText("Vi såg precis Sebastian med hur många vattenflaskor som helst! Han är nere vid trädet! ", 70, 625, 20, Color.WHITE);


        }
        if (!mobbatAxel){Raylib.DrawTexture(LokeMedAvokado, (int)LokeRec.x, (int)LokeRec.y, Color.WHITE);}
        if(mobbatAxel){Raylib.DrawTexture(LokeUtanAvokado, (int)LokeRec.x, (int)LokeRec.y, Color.WHITE);}
        if (Raylib.CheckCollisionRecs(character, LokeRec))
        {   if (!mobbatAxel)
            {Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Loke:", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Hehehe..jag har tagit avokadon du letar efter, du får den om du mobbar axel. Lycka till kortis :)", 70, 600, 20, Color.WHITE);
            }   

            else{
                
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Loke:", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Wooo! Här har du din avokado :)", 70, 600, 20, Color.WHITE);
                tagitAvocado=true;
            }
        }
    }
    if (currentScene == 7 && !IsInventoryOpen)
    {
        Raylib.DrawTexture(CurrentJesus, (int)Jesus.x, (int)Jesus.y, Color.WHITE);
        if (character.y < 300)  
        {   
            if(!tagitAvocado&&!tagitVatten&&!frejoffrad)
            {   if(Continue == false && letar == false)
                {
                    Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                    Raylib.DrawText("Okänd person:  Jag är...vägen...", 70, 575, 20, Color.WHITE);
                    Raylib.DrawText("Klicka 1 för att lyssna, och 2 för att kasta en sten på figuren", 70, 650, 20, Color.WHITE);
                }

                if (val_1 && Continue == false && letar == false)
                {
                    Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                    Raylib.DrawText("Jag är jesus. Vill du lyssna på mina visdomar?", 70, 575, 20, Color.WHITE);
                    Raylib.DrawText("Klicka ENTER för att säga ja (du har inget val)", 70, 650, 20, Color.WHITE);
                    CurrentJesus = JesusTextures["normal"];


                }


                if (JesusHasBeenHurt == true && Continue == false && letar == false)
                {
                    Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                    Raylib.DrawText("Jesus: Ow varför gjorde du så :C Jag ville bara dela med mig av mina visdomar", 70, 575, 20, Color.WHITE);
                    Raylib.DrawText("Klicka ENTER för att för att säga förlåt och lyssna på hans visdomar", 70, 650, 20, Color.WHITE);
                    CurrentJesus = JesusTextures["normal"];
                }

                if (Continue == true)
                {
                    Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                    Raylib.DrawText("Jag ljög, jag har inga visdomar. Hämta dessa saker till mig annars hamnar du i helvetet:", 70, 575, 20, Color.WHITE);
                    Raylib.DrawText("   -Ett glas vatten som jag kan göra till vin, en avokado, och en person som skall offras", 70, 600, 20, Color.WHITE);
                    Raylib.DrawText("Kom tillbaka när du hittat allt.", 70, 650, 20, Color.WHITE);
                    still = false;
                    letar = true;
                }
            }
        
            if(letar==true&&(tagitAllt||tagitAvocado||frejoffrad||tagitVatten)){
                
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Har du hittat allt?", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Klicka 1 för ja eller 2 för nej", 70, 650, 20, Color.WHITE);
            
                if(val_1==true&&tagitAllt==true){
                
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("Hm ok", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Klicka ENTER för att komma till himlen", 70, 650, 20, Color.WHITE);
                }
                if(Continue==true&&tagitAllt==true){
                Raylib.DrawTexturePro(himlen, Source, Destination, new Vector2(0, 0), 0, Color.WHITE);
                still=true;
                Raylib.DrawTexture(CurrentTexture, 600, 500, Color.WHITE);
                Raylib.DrawTexture(CurrentJesus, 600, 200, Color.WHITE);
                }

                if(val_1==true&&tagitAllt==false){
                
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("LÖGNARE", 70, 575, 20, Color.WHITE);
                Raylib.DrawText("Klicka 2 för att säga nej", 70, 650, 20, Color.WHITE);
                }
                if(val_2==true){
                
                Raylib.DrawRectangleRec(TextBox, Color.BLACK);
                Raylib.DrawText("ehm okej vad gör du här då? Gå härifrån.", 70, 575, 20, Color.WHITE);
                }
            
            }
        
        
        
        }
    }
    //Raylib.DrawRectangleRec(TextBox, Color.BLACK); 
    //Raylib.DrawText("", 70, 575, 20, Color.WHITE);




    Raylib.EndDrawing();

}



void walk()
{
    WalkingAnimation++;
    if (WalkingAnimation >= 10)
    {
        WalkingAnimation = 0;
        if (WalkingAnimationIndex >= SagaWalkingRight.Count() - 1)
        {
            WalkingAnimationIndex = 0;
        }

        else { WalkingAnimationIndex++; }
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && still == false)
    {
        if (!(currentScene >= 7 && character.y <= 10))
        {
            character.y -= 7;
            CurrentTexture = SagaWalkingUp[WalkingAnimationIndex];
        }
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && still == false)
    {
        if (!(character.x < 2))
        {
            character.x -= 7;
            CurrentTexture = SagaWalkingLeft[WalkingAnimationIndex];
        }
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && still == false)
    {
        if (!(currentScene <= 1 && character.y >= Raylib.GetScreenHeight() - SagaTextures["avatar"].height))
        {
            character.y += 7;
            CurrentTexture = SagaWalkingDown[WalkingAnimationIndex];
        }
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && still == false)
    {
        if (!(character.x >= Raylib.GetScreenWidth() - SagaTextures["avatar"].width))
        {
            character.x += 7;
            CurrentTexture = SagaWalkingRight[WalkingAnimationIndex];
        }
    }

}

void val(){

    if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE) && Continue == false)
    {
        val_1 = true;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_TWO) && Continue == false)
    {
        val_2 = true;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
    {
        Continue = true;
    }
}




