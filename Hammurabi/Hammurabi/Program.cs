using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hammurabi
{
    public class Program
    // Declaring intergers & strings and setting default values for the first year
    {
        static Random rnd = new Random();
        static int menuLocation = 0;
        static int yearNumber = 1;
        static int lastYrDeath = 0;
        static int lastYrHarvestNumber = rnd.Next(1, 8);
        static int lastYrPriceOfLand = rnd.Next(17,27);
        static int lastYrPlagePopulation = 0;
        static int lastYrNewPopulation = 0;
        static int lastYrRatsEaten = 0;        
        static int totalDeathStarving;
        static int totalDeathPlage;
        static int totalNewPopulation;
        static int totalBushelsHarvested;        
        static int land = 1000;
        static int priceOfLand = rnd.Next(17, 27);
        static int userLandSell;
        static int userLandBuy;
        static int userLandPlant;
        static int userBushelsGive;
        static int bushels = 3800;
        static int bushelsFromSelling;
        static int bushelsForBuying;
        static int population = 100;
        static int eatenPopulation;
        static int newPopulation;
        static int deadPopulation;
        static int plagePercent = rnd.Next(0, 100);
        static int plagePopulation= rnd.Next(4, 56);
        static int harvest;
        static int harvestNumber = rnd.Next(1, 8);
        static int sellLoop = 0;
        static int buyLoop = 0;
        static int plantLoop = 0;
        static int feedingLoop = 0;
        static int gameOverLoop = 0;
        static int ratsPercent = rnd.Next(1, 11);
        static int ratsEaten = rnd.Next(0, 5482);                
        static int acresPerCiticzen = 0;
        static int lastYrTornadoDamage = 0;
        static int totalTornadoDamade;
        static int tornadoPercent = rnd.Next(1,100);
        static int tornadoDamage = rnd.Next(3, 25);
        static int isItUltimate = 0;        
        static string mockUser;
        static string yearOrdSuf = "st";
        static string userInputLandSell;
        static string userInputLandBuy;
        static string userInputLandPlant;
        static string userInputBushelsGive;
        
        static void NewGameReset()
        // When this is called all intergers and strings are reset to the default value to start a new game
        {
            yearNumber = 1;
            yearOrdSuf = "st";
            lastYrDeath = 0;
            lastYrHarvestNumber = rnd.Next(2, 8);
            lastYrPriceOfLand = rnd.Next(17, 27);
            lastYrNewPopulation = 0;
            lastYrRatsEaten = 0;
            totalDeathStarving = 0;
            totalDeathPlage = 0;
            totalNewPopulation =0;
            totalBushelsHarvested =0;
            land = 1000;
            priceOfLand = rnd.Next(17, 27);
            bushels = 3800;
            bushelsFromSelling = 0;
            bushelsForBuying = 0;
            population = 100;
            plagePercent = rnd.Next(0, 100);
            plagePopulation = rnd.Next(4, 56);
            harvest = 0;
            harvestNumber = rnd.Next(2, 8);
            sellLoop = 0;
            buyLoop = 0;
            plantLoop = 0;
            feedingLoop = 0;
            gameOverLoop = 0;
            ratsPercent = rnd.Next(1, 11);
            ratsEaten = rnd.Next(0, 5482);
            lastYrTornadoDamage = 0;
            totalTornadoDamade =0;
            tornadoPercent = rnd.Next(1, 100);
            tornadoDamage = rnd.Next(3, 25);
        }
        static void AcresToSell()
        // User selecting how many Acres they would like to SELL
        // 100% Working 
        {
            while (sellLoop < 1)
            {
                Console.Write("How many acres of land would you like to Sell --> ");
                userInputLandSell = Console.ReadLine();
                // Console.WriteLine("TEST: user input = " + userInputLandSell);
                // userLandSell = int.Parse(Console.ReadLine());
                if (Int32.TryParse(userInputLandSell, out userLandSell))
                {
                    if (userLandSell > land)
                    {
                        Console.WriteLine("ERROR: You can't do that you only have " + land + " Acres of land.");
                    }
                    // Logic
                    else if (userLandSell > 0)
                    {
                        land = land - userLandSell;
                        bushelsFromSelling = userLandSell * priceOfLand;
                        bushels = bushels + bushelsFromSelling;
                        Console.WriteLine("You now have " + land + " Acres");
                        Console.WriteLine("You now have " + bushels + " Bushels");
                        sellLoop++;
                    }
                    else
                    {
                        sellLoop++;
                    }
                }
                else if (userInputLandSell == "Quit" || userInputLandSell == "quit" || userInputLandSell == "Q" || userInputLandSell == "q")
                {
                    GameMenu();
                }
                else
                {
                    Console.WriteLine("ERROR: You must enter a number or Quit");
                }
            }
        }
        static void AcresToBuy()
        // User selecting how many Acres they would like to BUY
        // 100% Working
        {
            while (buyLoop < 1)
            {
                Console.Write("How many acres of land would you like to Buy --> ");
                userInputLandBuy = (Console.ReadLine());
                // Console.WriteLine("TEST: user input = " + userInputLandBuy);
                if (Int32.TryParse(userInputLandBuy, out userLandBuy))
                {
                    // Input Validation
                    if ((priceOfLand * userLandBuy) > bushels)
                    {
                        Console.WriteLine("ERROR: You can't do that you only have " + bushels + " to spend.");
                    }
                    // Logic
                    else if (userLandBuy > 0)
                    {
                        land = land + userLandBuy;
                        bushelsForBuying = userLandBuy * priceOfLand;
                        bushels = bushels - bushelsForBuying;
                        Console.WriteLine("You now have " + land + " Acres");
                        Console.WriteLine("You now have " + bushels + " Bushels");
                        buyLoop++;
                    }
                    else
                    {
                        buyLoop++;
                    }
                }
                else if (userInputLandBuy == "Quit" || userInputLandBuy == "quit" || userInputLandBuy == "Q" || userInputLandBuy == "q")
                {
                    GameMenu();
                }
                else
                {
                    Console.WriteLine("ERROR: You must enter a number or Quit");
                }
            }
        }
        static void BushelsForPlanting()
        // User selecting how many Acres they would like to PLANT Bushels  
        // 100% Working
        {
            while (plantLoop < 1)
            {
                Console.Write("How many acres of land would you like to Plant Bushels on --> ");
                userInputLandPlant = (Console.ReadLine());
                // Console.WriteLine("TEST: user input = " + userInputLandPlant);
                if (Int32.TryParse(userInputLandPlant, out userLandPlant))
                {
                    if (userLandPlant > land)
                    {
                        Console.WriteLine("ERROR: You can't do that you only have " + land + " Acres of land.");
                    }
                    else if ((population * 10) < userLandPlant)
                    {
                        Console.WriteLine("ERROR: You can't do that your population is only " + population + ".");
                    }
                    else
                    {
                        bushels = bushels - userLandPlant;
                        harvest = harvestNumber * userLandPlant;
                        totalBushelsHarvested = totalBushelsHarvested + harvest;
                        lastYrHarvestNumber = harvestNumber;
                        Console.WriteLine("You now have " + bushels + " Bushels");
                        // Console.WriteLine("TEST: Harvest will be " + harvest);
                        plantLoop++;
                    }
                }
                else if (userInputLandPlant == "Quit" || userInputLandPlant == "quit" || userInputLandPlant == "Q" || userInputLandPlant == "q")
                {
                    GameMenu();
                }
                else
                {
                    Console.WriteLine("ERROR: You must enter a number or Quit");
                }                    
            }
        }
        static void FeedingPopulation()
        // User selecting how many BUSHELS they would like to feed POPULATION
        // 100% Working
        {
            while (feedingLoop < 1)
            {
                Console.Write("How many bushles would you like to feed to your people --> ");
                userInputBushelsGive = (Console.ReadLine());
                // Console.WriteLine("TEST: user Input = " + userInputBushelsGive);
                if (Int32.TryParse(userInputBushelsGive, out userBushelsGive))
                {
                    if (userBushelsGive > bushels)
                    {
                        Console.WriteLine("ERROR: You can't do that you only have " + bushels + " to give away.");
                    }
                    else
                    {
                        eatenPopulation = userBushelsGive / 20;
                        // if statment bellow is shortcut to fix bug that 
                        // increaced population if you gave more than 20 per populant  
                        if (eatenPopulation > population)
                        {
                            eatenPopulation = population;
                        }
                        deadPopulation = population - eatenPopulation;
                        totalDeathStarving = totalDeathStarving + deadPopulation;
                        lastYrDeath = deadPopulation;
                        population = population - deadPopulation;
                        bushels = bushels - userBushelsGive;
                        Console.WriteLine("You now have " + bushels + " Bushels");
                        // Console.WriteLine("TEST: Population that will live " + eatenPopulation);
                        // Console.WriteLine("TEST: Population that will die " + deadPopulation);
                        feedingLoop++;
                    }
                }
                else if (userInputBushelsGive == "Quit" || userInputBushelsGive == "quit" || userInputBushelsGive == "Q" || userInputBushelsGive == "q")
                {
                    GameMenu();
                }
                else
                {
                    Console.WriteLine("ERROR: You must enter a number or Quit");

                }
            }                
        }
        static void Rats()
        // Game determing if rats will accour, 
        // Rats will accour if harvestNum is > 5 and harvest is > ratsEaten
        {
            if (harvestNumber > 5 && harvest > ratsEaten)
            {
                // Previous soloution for Rats eatEaten ammount changed do to getting simalar numbers consistently 
                // ratsEaten = harvest - (harvest / ratsPercent);
                harvest = harvest - ratsEaten;
                lastYrRatsEaten = ratsEaten;
                // Console.WriteLine("TEST: Rats will eat " + ratsEaten);
            }
            else
            {
                lastYrRatsEaten = 0;
                // Console.WriteLine("TEST: Rats will eat " + lastYrRatsEaten);
            }
        }
        static void Plauge()
        // Game determinig if a plauge will accour
        // A plauge accours when plage% is > 60 and the pop is > plagePop
        {
            if (plagePercent > 60 && population > plagePopulation)
            {                
                population = population - plagePopulation;
                lastYrPlagePopulation = plagePopulation;
                totalDeathPlage = totalDeathPlage + plagePopulation;
                // Console.WriteLine("TEST: Plague will kill " + plagePopulation);
            }
            else
            {
                lastYrPlagePopulation = 0;
                // Console.WriteLine("TEST: Plague will kill " + lastYrPlagePopulation);
            }
        }
        static void Tornado()
        // New iteration 4 ! 
        {
            if (tornadoPercent > 45 && land > tornadoDamage)
            {
                land = land - tornadoDamage;
                lastYrTornadoDamage = tornadoDamage;
                totalTornadoDamade = totalTornadoDamade + tornadoDamage;
                // Console.WriteLine("TEST: Tornado will destroy " + tornadoDamage + " acres of land");
            }
            else
            {
                lastYrTornadoDamage = 0;
                // Console.WriteLine("TEST: Tornado will destroy " + lastYrTornadoDamage + " acres of land");
            }
        }
        static void NewPopulation()
        // Game determining if new population will accour
        // New Population will accour when no one dies that year or when harvest is <= 5 
        {
            if (deadPopulation + plagePopulation == 0 || harvestNumber <= 5)
            {
                population = population + newPopulation;
                lastYrNewPopulation = newPopulation;
                totalNewPopulation = totalNewPopulation + newPopulation;
                // Console.WriteLine("TEST: Population will increase by " + newPopulation);
            }
            else
            {
                lastYrNewPopulation = 0;
                // Console.WriteLine("TEST: Population will increase by " + lastYrNewPopulation);
            }
        }
        static void IsItGameOver()
        // Game determining if user decions have lost them the game and also used to mock user if a few pop die  
        //  
        {
            if (isItUltimate > 0)
            {
                if (population == 0 || deadPopulation > 22)
                {
                    Console.WriteLine("\nGG you have survived " + yearNumber + " years in power!\nBellow are your resaults");
                    Console.WriteLine("Your Total Deaths from Starvation --> " + totalDeathStarving);
                    Console.WriteLine("Your Total Deaths from Plauge --> " + totalDeathPlage);
                    Console.WriteLine("Your Total Bushels from Harvest --> " + totalBushelsHarvested);
                    Console.WriteLine("Your Ending Population --> " + population);
                    Console.WriteLine("Your Ending Land --> " + land);
                    Console.WriteLine("Your Ending Bushels --> " + bushels + "\n");
                    Console.Write("Would you like to play again? Y/N --> ");
                    ConsoleKeyInfo PlayAgain1 = Console.ReadKey();
                    if (PlayAgain1.KeyChar == 'y')
                    {
                        NewGameReset();
                        PlayUltimateHammurabi();
                    }
                    else if (PlayAgain1.KeyChar == 'n')
                    {
                        GameMenu();
                        //Before I added a menu pressing 'n' would close application
                        //Environment.Exit(0);
                    }
                }
                else if (deadPopulation > 0 && deadPopulation <= 7)
                {
                    mockUser = "\nMaybe they just died of old age...?";
                    // This will give user this message on year update "Maybe they just died of old age..."
                }
                else if (deadPopulation > 7 && deadPopulation <= 22)
                {
                    mockUser = "\nWhat are you doing we need to eat!\nKing Nahire would not have allowed this to happen!";
                    // This will give user this message on year update "What are you doing we need to eat!\nKing Nahire..."
                }
                else
                {
                    mockUser = "";
                }

            }
            else if (population == 0 || deadPopulation > 22)
            // This used to be 2 quite long if & else if statment that was almost identical
            // apart from the line "You have been kicked out of office!
            {
                while (gameOverLoop < 1)
                {
                    if (deadPopulation > 22)
                    {
                        Console.WriteLine("You have been kicked out of office!\nYou killed " + deadPopulation + " People!");
                    }
                    Console.WriteLine("You have failed! Sumeria has crumbled!");
                    Console.Write("Would you like to play again? Y/N --> ");
                    ConsoleKeyInfo PlayAgain = Console.ReadKey();
                    if (PlayAgain.KeyChar == 'y')
                    {
                        NewGameReset();
                        PlayClassicHammurabi();
                    }
                    else if (PlayAgain.KeyChar == 'n')
                    {
                        GameMenu();                        
                        //Before I added a menu pressing 'n' would close application
                        //Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: You must enter Y/N");
                    }
                }              
            }
            else if (deadPopulation > 0 && deadPopulation <= 7)
            {
                mockUser = "\nMaybe they just died of old age...?";
                // This will give user this message on year update "Maybe they just died of old age..."
            }
            else if (deadPopulation > 7 && deadPopulation <= 22)
            {
                mockUser = "\nWhat are you doing we need to eat!\nKing Nahire would not have allowed this to happen!";
                // This will give user this message on year update "What are you doing we need to eat!\nKing Nahire..."
            }            
            else
            {
                mockUser = "";
            }
        }
        static void NewYear()
        // Game reseting values for the next year 
         {
            //priceOfLand = rnd.Next(17, 27);
            if (harvestNumber >5)
            {
                priceOfLand = rnd.Next(21, 27);
            }
            else if (harvestNumber <=5)
            {
                priceOfLand = rnd.Next(17, 21);
            }
            bushels = bushels + harvest;            
            sellLoop = 0;
            buyLoop = 0;
            plantLoop = 0;
            feedingLoop = 0;
            harvest = 0;            
            newPopulation = rnd.Next(1, 16);
            harvestNumber = rnd.Next(2, 8);
            plagePercent = rnd.Next(0, 100);
            ratsPercent = rnd.Next(0, 11);
            ratsEaten = rnd.Next(0, 5482);
            tornadoPercent = rnd.Next(1, 100);
            tornadoDamage = rnd.Next(3, 25);
            if (yearNumber == 1)
            {
                yearOrdSuf = "st";
            }
            else if (yearNumber == 2)
            {
                yearOrdSuf = "nd";
            }
            else if (yearNumber == 3)
            {
                yearOrdSuf = "rd";
            }
            else
            {
                yearOrdSuf = "th";
            }
        }
        static void GameTitle()
        // String cotaining Game title screen
        {
            Console.Clear();
            Console.WriteLine("\n\n");            
            var hammurabi = new[]
                        {
                 @"________________________________________________________________________________",
                 @"            _    _                                           _     _           ",
                 @"           | |  | |                Hammurabi                | |   (_)          ",
                 @"           | |__| | __ _ _ __ ___  _ __ ___  _   _ _ __ __ _| |__  _           ",
                 @"           |  __  |/ _` | '_ ` _ \| '_ ` _ \| | | | '__/ _` | '_ \| |          ",
                 @"           | |  | | (_| | | | | | | | | | | | |_| | | | (_| | |_) | |          ",
                 @"           | |  | | (_| | | | | | | | | | | | |_| | | | (_| | |_) | |          ",
                 @"           |_|  |_|\__,_|_| |_| |_|_| |_| |_|\__,_|_|  \__,_|_.__/|_|          ",
                 @"                                                                               ",
                 @"                  Try your hand at governing Ancient Sumeria                   ",
                 @"                       for a ten year term in office.                           ",
                 @"        You can navigate the menu using the WASD Keys and the Arrow Keys       ",
                 @"________________________________________________________________________________",
            };
            foreach (string line in hammurabi)
                Console.WriteLine(line);
        }
        static void GameMenu()
        // This sets up the List of options in the game menu and what happends when its chosen
        // 100% Working
        {
             string DrawMenu(List<string> MenuItems)
            {
                
                for (int i = 0; i < MenuItems.Count; i++)
                {
                    if (i == menuLocation)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(MenuItems[i]);
                    }
                    else
                    {
                        Console.WriteLine(MenuItems[i]);
                    }
                    Console.ResetColor();
                }
                ConsoleKeyInfo userKey = Console.ReadKey();
                if (userKey.Key == ConsoleKey.DownArrow || userKey.Key == ConsoleKey.RightArrow || userKey.Key == ConsoleKey.S || userKey.Key == ConsoleKey.D)
                {
                    if (menuLocation == MenuItems.Count - 1)
                    {
                        // if this IF statment was removed menuLocation could go in to values that are over the list ammount
                    }
                    else
                    {
                        menuLocation++;
                    }
                }
                else if (userKey.Key == ConsoleKey.UpArrow || userKey.Key == ConsoleKey.LeftArrow || userKey.Key == ConsoleKey.W || userKey.Key == ConsoleKey.A)
                {
                    if (menuLocation <= 0)
                    {
                        // if this IF statment  is removed menuLocation could go in to values that are negitive the list ammount
                    }
                    else
                    {
                        menuLocation--;
                    }
                }
                else if (userKey.Key == ConsoleKey.Enter)
                {
                    return MenuItems[menuLocation];
                }               
                return "";
            }            
            Console.CursorVisible = false;
            List<string> menuItems = new List<string>()
                {
                @" " + @"Play Ultimate Hammurabi",
                @" " + @"Play Classic Hammurabi",
                @" " + @"What is Hammurabi?",
                @" " + @"How To Play",
                @" " + @"Exit"
                };
            while (true)
            {
                GameTitle();
                string selectedMenuItem = DrawMenu(menuItems);
                if (selectedMenuItem == @" " + @"Play Ultimate Hammurabi")
                {
                    Console.Clear();
                    Console.WriteLine("Play Ultimate Hammurabi!");
                    NewGameReset();
                    isItUltimate=1;
                    PlayUltimateHammurabi();
                }
                else if (selectedMenuItem == @" " + @"Play Classic Hammurabi")
                {
                    Console.Clear();
                    Console.WriteLine("Play Classic Hammurabi");
                    NewGameReset();
                    PlayClassicHammurabi();
                }                
                else if (selectedMenuItem == @" " + @"What is Hammurabi?")
                {
                    Console.Clear();
                    Console.WriteLine("What is Hammurabi?");
                    WhatIsHammurabi();
                }
                else if (selectedMenuItem == @" " + @"How To Play")
                {
                    Console.Clear();
                    Console.WriteLine("How To Play!");
                    HowToPlay();
                }
                else if (selectedMenuItem == @" " + @"Exit")
                {
                    Environment.Exit(0);
                }
            }
        }
        
        static void Hammurabi()
        {
            Console.WriteLine("You can quit at any time by entering 'Quit' into the console\n\n\n");
            Console.WriteLine("Sir, Its the " + yearNumber + yearOrdSuf + " year of your reign");
            if (lastYrPlagePopulation > 0 && lastYrTornadoDamage > 0)
            {
                Console.WriteLine("ITS BEEN A DARK YEAR!");
                Console.WriteLine("A TORNADO HAS DESTROYED " + lastYrTornadoDamage + " ACRES OF LAND AND");
                Console.WriteLine("A PLAUGE HAS STRUCK " + lastYrPlagePopulation + " CITIZENS HAVE DIED!");
                Console.WriteLine("We must pray to the lost King Nahire");
                lastYrPlagePopulation = 0;
            }
            else if (lastYrPlagePopulation > 0)
            {
                Console.WriteLine("A PLAUGE HAS STRUCK " + lastYrPlagePopulation + " CITIZENS HAVE DIED!");
                lastYrPlagePopulation = 0;
            }
            else if (lastYrTornadoDamage > 0)
            {
                Console.WriteLine("A TORNADO HAS DESTROYED " + lastYrTornadoDamage + "ACRES OF LAND AND");
                lastYrTornadoDamage = 0;
            }            
            Console.WriteLine("Population is now " + population + " inhabitants\n" +
                              "Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria" +
                               mockUser);
            Console.WriteLine("Sumeria now owns " + land + " acres of land\n" +
                              "The current price is " + priceOfLand + " bushels per acre");
            Console.WriteLine("You now have " + bushels + " bushels in store\n" +
                              "Last year harvest was " + lastYrHarvestNumber + " bushels per acre, rats ate " + lastYrRatsEaten + " bushels");
            AcresToSell();
            AcresToBuy();
            BushelsForPlanting();
            FeedingPopulation();
            Rats();
            Plauge();
            NewPopulation();
            Tornado();
            IsItGameOver();
            Console.WriteLine("END OF YEAR " + yearNumber + "\n\n");
            NewYear();
        }
       
        static void PlayUltimateHammurabi()
        {
            Console.CursorVisible = true;
            for (yearNumber = 1; yearNumber <= 10000; yearNumber++)
            {
                Hammurabi();
            }
            Console.WriteLine("Congratulations you survived all 10000 years King Nahire would be proud!");
            Console.WriteLine("Your Total Deaths from Starvation --> " + totalDeathStarving);
            Console.WriteLine("Your Total Deaths from Plauge --> " + totalDeathPlage);
            Console.WriteLine("Your Total Bushels from Harvest --> " + totalBushelsHarvested);
            Console.WriteLine("Your Ending Population --> " + population);
            Console.WriteLine("Your Ending Land --> " + land);
            Console.WriteLine("Your Ending Bushels --> " + bushels + "\n");
            Console.WriteLine("With these resaults your score is " + acresPerCiticzen);
            Console.WriteLine("This is APC (Acres Per Citizen) your Ending Land / Ending Population");
            Console.ReadKey();
        }
        static void PlayClassicHammurabi()
        // This starts a new game of Hammurabi
        // 100% Working
        {
            Console.CursorVisible = true;
            for (yearNumber = 1; yearNumber < 11; yearNumber++)
            {
                Hammurabi();
            }
            acresPerCiticzen = land / population;
            Console.WriteLine("Congratulations you have survived 10 years in power!\nBellow are your resaults");
            Console.WriteLine("Your Total Deaths from Starvation --> " + totalDeathStarving);
            Console.WriteLine("Your Total Deaths from Plauge --> " + totalDeathPlage);
            Console.WriteLine("Your Total Bushels from Harvest --> " + totalBushelsHarvested);
            Console.WriteLine("Your Ending Population --> " + population);
            Console.WriteLine("Your Ending Land --> " + land);
            Console.WriteLine("Your Ending Bushels --> " + bushels + "\n");
            Console.WriteLine("With these resaults your score is " + acresPerCiticzen );
            Console.WriteLine("This is APC (Acres Per Citizen) your Ending Land / Ending Population");
            Console.ReadKey();               
        }
        static void WhatIsHammurabi()
        // This prints out a brief history of Hammurabi

        {
            GameTitle();
            Console.WriteLine("Hammurabi was originally called The Sumer Game it was developed by Doug Dyment \n" +
                              "at Digital Equipment Corporation and released 1968, this was done using the\n" +
                              "computer language FOCAL(Formulating On-Line Calculations in Algebraic Language).\n" +
                              "In 1973 David H. Ahl released “BASIC Computer Games” this was a library of games\n" +
                              "written using the computer language BASIC (Beginner's All-purpose Symbolic \n" +
                              "Instruction Code). Hammurabi was one of those games, David H. Ahl had expanded\n" +
                              "from The Sumer Game and added a 10-year assessment.\n");
            Console.WriteLine("There are 2 versions of Hammurabi in this game Classic and Ultimate");
            Console.WriteLine("I recommend mastering Classic before attempting Ultimate");
            Console.WriteLine("Classic follows the same style as David H.Ahl giving you a 10-year assessment\n" +
                              "that is your score");
            Console.WriteLine("Ultimate follows the same style as David H. Ahl but does not end at 10-years\n" +
                              "instead can play for up to 10000 - years");
            Console.WriteLine("To close What Is Hammurabi press any key.");
            Console.ReadKey();
        }
        static void HowToPlay()
        // This prints out a basic How to guide for Hammurabi
        {
            Console.WriteLine("You will start the game with\n");
            Console.WriteLine("3800 Bushels of Wheat, 1000 Acres of Land and 100 Citizens.\n");
            Console.WriteLine("To survive the 10 years in power you will need to use your resources wisely!\n");
            Console.WriteLine("1. Each year you will get the opportunity to Buy and Sell Acres of Land\n" +
                              "the price will vary between 17 and 27 Bushel per Acre of Land depending\n" +
                              "on the harvest yield of the previous year\n");
            Console.WriteLine("2. Each citizen needs to eat 20 Bushels of wheat to survive the year.\n");                             
            Console.WriteLine("3. To get more Bushels you will need to plant 1 Bushel on 1 Acre of land\n" +
                              "and the next year you will receive between 2 and 8 Bushels, a yield greater\n" +
                              "than 5 of Bushels per Acre can attract rats.\n");
            Console.WriteLine("4. If neighbouring citizens hear that no one died of starvation and plague\n" +
                              "in the last year or that the last year’s harvest yield was over 4 they may\n" +
                              "choose to move to Sumeria.\n");
            Console.WriteLine("5. Plagues and Tornados can occur each year a plague will kill between 4 and\n" +
                              "56 Citizens and a Tornado will destroy between 3 and 25 Acres of land.\n");                              
            Console.WriteLine("If you survive the 10 years you will be ranked with previous great leaders.");
            Console.WriteLine("To close How to play press any key.");
            Console.ReadKey();
        }        
        static void Main(string[] args)
        {
            Console.Title = "Hammurabi";
            GameMenu();          
        }               
    }
}
