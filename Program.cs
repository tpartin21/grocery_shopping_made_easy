using System;
using System.IO;

namespace grocery_shopping_made_easy
{
    class Program
    {
        static Food food = new Food ();
        static ExpirationDate expire = new ExpirationDate();
        {   
            void Program.Main(string[] args);
            {
                try
                {
                    //checking to see if food will log the food if it is will and adds them if not
                    string path = @"data/food.json";
                    if (!File.Exists(Path))
                    {
                        using (food = new streamWriter (path, true))
                    {
                        food.WriteLine("{\"milk\":[], \"pasta\" : []}");

        }
    }
               string path1 = @"data\log.txt";
if (!File.Exists(path1))

{
    using (var log = new StreamWriter(path1, true))
    {
        log.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Log created");
    }
}
            catch (Exception ex)
            {
            Console.WriteLine("ERROR: " + ex);
            }

            //intros
             Console.WriteLine(@"
            
            ***Welcome to Grocery Shopping Made Easy!***");
            //loops menu
            bool showMenu = true;
            while (showMenu)
           {
              showMenu = MainMenu();
            }           
           

        //menu
        private static bool MainMenu()
{

    //initial prompt
    Console.Clear();
    Console.WriteLine(@"
               ------------------------------       
                     ***MAIN MENU***
               Please select an option:
                
               1 - View Food
               2 - Edit Food
               3 - Expired Food
               0 - Exit
            
             ------------------------------
            
            ");
    string menuInput;
    menuInput = Console.ReadLine();
    switch (menuInput)
    {
        case "1": //display Food
            Console.Clear();
            Food.Display();
            return true;
        case "2": //edit Food
            Console.Clear();
            Food.Edit();
            return true;
        case "3": //expiration date
            Console.Clear();
            Expire.Prompt();
            return true;
        case "0": //exit
            Console.Clear();
            Console.WriteLine("Goodbye!\n");
            return false;
        default:
            Console.Clear();
            Console.WriteLine("Please enter 1, 2, 3, or 0 next time. Press any key to return to main menu");
            Console.ReadKey();
            return true;
    }
}
  

