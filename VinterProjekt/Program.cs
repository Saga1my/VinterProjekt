using Raylib_cs;
using System.Numerics;


Raylib.InitWindow(1280, 720, "SPEL :D");
Raylib.SetTargetFPS(60);

int currentScene = 1;
bool jesusSedd = false;
bool val_1 = false;
bool val_2 = false;
bool Continue = false;
bool bossFight = false;
bool JesusIsHurting = false;
bool JesusHasBeenHurt = false;
bool still = false;
bool letar = false;
bool IsInventoryOpen = false;



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
Texture2D LokeUtanAvokado = Raylib.LoadTexture("Bilder/LokeUtanAvokado.png");
Texture2D LokeMedAvokado = Raylib.LoadTexture("Bilder/LokeMedAvokado.png");


Rectangle character = new Rectangle(Raylib.GetScreenWidth() / 3, Raylib.GetScreenHeight() / 2, 100, 100);
Rectangle Jesus = new Rectangle(980, 300, 100, 100);
Rectangle Source = new Rectangle(0, 0, backgrounds[0].width, backgrounds[0].height);
Rectangle Destination = new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
Rectangle ElliotOchErikaBox = new Rectangle(800,70,100,100);
Rectangle LokeRec = new Rectangle(100,300,100,100);
Rectangle TextBox = new Rectangle(40, 550, 1200, 140);
Rectangle InventoryTextBox = new Rectangle(40, 20, 500, 600);
Rectangle Inventory = new Rectangle(5,5,50,50);
Rectangle InventoryOpen = new Rectangle(700,15,10,10);


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
        character.y=100;
        Continue = false;
        val_1 = false;
        val_2 = false;

    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_I)){
        inventoryI++;
        if (inventoryI>=2){
            inventoryI=0;
        } 

    }
    if (inventoryI==1){
     IsInventoryOpen=true;
    }
    else {IsInventoryOpen=false;
    still=false;}

    walk();

    draw();



    if (currentScene == 2 && character.x > 700)
    {
        Jesus.x += 5;
        jesusSedd = true;
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

        if (JesusHasBeenHurt == false)
        {
            Jesus.x = 440;
            Jesus.y = 40;
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
            CurrentJesus=JesusTextures["normal"];
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)){
            Continue=true;
            
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

        //frej hjälpt till med att få figuren att blinka

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

    if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
    {
        Continue = true;
    }

    if (JesusHasBeenHurt && Continue == true)
    {
    
    }

}

//RITA 

void draw()

{
    Raylib.BeginDrawing();

    Raylib.DrawTexturePro(backgrounds[currentScene - 1], Source, Destination, new Vector2(0, 0), 0, Color.WHITE);
    
    Raylib.DrawTexture(CurrentTexture, (int)character.x, (int)character.y, Color.WHITE);

    if (IsInventoryOpen==false){
        Raylib.DrawTexture(InventoryTexture,(int)Inventory.x,(int)Inventory.y, Color.WHITE);
    }

    if (IsInventoryOpen==true){
        Raylib.DrawTexture(OpenInventoryTexture,(int)InventoryOpen.x,(int)InventoryOpen.y, Color.WHITE);
        still=true;
        Raylib.DrawRectangleRec(InventoryTextBox, Color.BLACK); 
        Raylib.DrawText("I din väska har du just nu:", 55, 40, 20, Color.WHITE);
        }


    if (currentScene == 1 && character.y > 200&&letar==false&&!IsInventoryOpen)
    {

        Raylib.DrawRectangleRec(TextBox, Color.BLACK);
        Raylib.DrawText("Du är ute på en promenad för att njuta av det vackra vädret!", 70, 575, 20, Color.WHITE);
        Raylib.DrawText("Klicka på W,A,S,D för att röra på dig och I för att öppna eller stänga ditt inventory", 70, 600, 20, Color.WHITE);
    }

    if (currentScene == 2 && bossFight == false&&!IsInventoryOpen)
    {


        Raylib.DrawTexture(CurrentJesus, (int)Jesus.x, (int)Jesus.y, Color.WHITE);
        if (jesusSedd == false && character.y < 500 && character.x < 700&&letar==false)
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

    if (currentScene == 3&&letar==false&&!IsInventoryOpen)
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
    if (currentScene==6&&letar==true){
        Raylib.DrawTexture(ErikaOchElliot,(int)ElliotOchErikaBox.x,(int)ElliotOchErikaBox.y,Color.WHITE);
        Raylib.DrawTexture(LokeMedAvokado, (int)LokeRec.x, (int)LokeRec.y,Color.WHITE );
    }
    if (currentScene == 7&&!IsInventoryOpen)
    {
        Raylib.DrawTexture(CurrentJesus, (int)Jesus.x, (int)Jesus.y, Color.WHITE);
        if (character.y < 300&&Continue==false&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Okänd person:  Jag är...vägen...", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka 1 för att lyssna, och 2 för att kasta en sten på figuren", 70, 650, 20, Color.WHITE);
        }

        if (val_1&&Continue==false&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Jag är jesus. Hämta saker till mig eller hamna i helvetet.", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka ENTER för att säga ja (du har inget val)", 70, 650, 20, Color.WHITE);
            
          
        }
        

        if (JesusHasBeenHurt == true&&Continue==false&&letar==false)
        {
            Raylib.DrawRectangleRec(TextBox, Color.BLACK);
            Raylib.DrawText("Okänd person: Ow varför gjorde du så :C Jag ville bara dela med mig av mina visdomar", 70, 575, 20, Color.WHITE);
            Raylib.DrawText("Klicka ENTER för att för att säga förlåt och lyssna på hans visdomar", 70, 650, 20, Color.WHITE);
            CurrentJesus=JesusTextures["normal"];
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
    WalkingAnimation++;
    if(WalkingAnimation>=10){
        WalkingAnimation=0;
        if(WalkingAnimationIndex>=SagaWalkingRight.Count()-1){
            WalkingAnimationIndex=0;
        }

        else {WalkingAnimationIndex ++;}
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && still == false)
    {
        if (!(currentScene >= 7 && character.y <= 10))
        {
            character.y -= 7;
            CurrentTexture=SagaWalkingUp[WalkingAnimationIndex];
        }
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && still == false)
    {
        if (!(character.x < 2))
        {
            character.x -= 7;
            CurrentTexture=SagaWalkingLeft[WalkingAnimationIndex];
        }
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && still == false)
    {
        if (!(currentScene <= 1 && character.y >= Raylib.GetScreenHeight() - SagaTextures["avatar"].height))
        {
            character.y += 7;
            CurrentTexture=SagaWalkingDown[WalkingAnimationIndex];
        }
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && still == false)
    {
        if (!(character.x >= Raylib.GetScreenWidth() - SagaTextures["avatar"].width))
        {
            character.x += 7;
            CurrentTexture=SagaWalkingRight[WalkingAnimationIndex];
        }   
    }

}

    
    


