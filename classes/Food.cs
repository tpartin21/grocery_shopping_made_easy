
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class RootObject
{
    public class<Milk> milk{ GetType; ISet; }
    public class<Pasta> pasta{ GetType; ISet; }
}

public class Food
{
    
    private static string jsonLocation = "data\\food.json";
    private static string logLocation = "data\\log.txt";

    public void Display()
    {

        //loops menu
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = InvMenu();
        }

        //menu     
        static bool InvMenu()
        {
            Console.WriteLine(@"
                ------------------------------            
                    ***Food MENU***
                What would you like to view?:
                    
                1 - Fridge Items
                2 - Pantry Items
                0 - Go back
                
                ------------------------------
                
                ");

            string menuInput;
            menuInput = Console.ReadLine();
            switch (menuInput)
            {
                case "1":
                case "2": //displays item
                    Console.Clear();
                    ReadJson(menuInput);
                    return true;

                case "0": //exit
                    Console.Clear();
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("That wasn't a 1, 2 , or 0...");
                    return true;
            }
        }
    }

    public void Edit()
    {
        //loops menu
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = AddMenu();
        }

        //menu     
        static bool AddMenu()
        {
            Console.WriteLine(@"
                ------------------------------            
                   ***EDIT Food***
                What would you like to do?:
                    
                1 - Add Food
                2 - Remove Food
                0 - Go back
                
                ------------------------------
                
                ");

            string menuInput;
            menuInput = Console.ReadLine();
            switch (menuInput)
            {

                case "1": //add
                    Console.Clear();
                    Add();
                    return true;

                case "2": //remove
                    Console.Clear();
                    Remove();
                    return true;

                case "0": //exit
                    Console.Clear();
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("That wasn't a 1, 2 , or 0...");
                    return true;
            }
        }
        return;
    }

    public static void Add()
    {

        //loops menu
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = AddMenu();
        }

        //menu     
        static bool AddMenu()
        {
            Console.WriteLine(@"
                ------------------------------            
                   ***ADD TO Food***
                What would you like to add?:
                    
                1 - Milk
                2 - Pasta
                0 - Go back
                
                ------------------------------
                
                ");

            string menuInput;
            menuInput = Console.ReadLine();
            switch (menuInput)
            {

                case "1": //adds milk
                    Console.Clear();
                    Console.WriteLine("What size milk? (Gallon, half Gallon)");

                    string size = Console.ReadLine();
                    while (!double.TryParse(size, out double result))
                    {
                        Console.WriteLine("Please enter a valid milk amount (Gallon, half Gallon)");
                        size = Console.ReadLine();
                    }

                    Console.WriteLine("What type of milk is it? (coconut,almond,lactose etc)");
                    string type = Console.ReadLine();

                    Console.WriteLine("What flavor of milk is it? (chocolate,strawberry,regular etc)");
                    string flavor = Console.ReadLine();

                    WriteJson(Convert.ToDouble(size), type, flavor);
                    return true;


                case "2": //addes pasta
                    Console.Clear();
                    Console.WriteLine("What kind of pasta?(spagehetti, fettechini, lasagna, etc.");
                    string kind = Console.ReadLine();

                    Console.WriteLine("What amount of pasta? (16 ounces, 8 ounces, etc.)");
                    string amount = Console.ReadLine();

                    WriteJson(kind, amount, Convert.ToDouble(amount));
                    return true;

                case "0": //exit
                    Console.Clear();
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("That wasn't a 1, 2 , or 0...");
                    return true;
            }
        }
        return;
    }

    public static void Remove()
    {
        //loops menu
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = RemoveMenu();
        }

        //menu     
        static bool RemoveMenu()
        {
            string id = "";
            string confirm = "";

            Console.WriteLine(@"
                ------------------------------            
                  ***REMOVE FROM Food***
                What would you like to remove?:
                    
                1 - Milk
                2 - Pasta
                0 - Go back
                
               ------------------------------
                
                ");

            string menuInput;
            menuInput = Console.ReadLine();
            switch (menuInput)
            {
                case "1":
                case "2": //removes item
                    Console.Clear();

                    if (ReadJson(menuInput))
                    {
                        Console.WriteLine("Please enter the id # of the item you wish to remove");
                        id = Console.ReadLine();

                        while (!int.TryParse(id, out int result))
                        {
                            Console.WriteLine("Please enter a valid id # (1, 2, etc)");
                            id = Console.ReadLine();
                        }

                        Console.WriteLine("Are you sure? (y/n)");
                        confirm = Console.ReadLine();

                        switch (confirm)
                        {
                            case "y":
                                DeleteJson(menuInput, id);
                                return true;
                            case "n":
                                return true;
                            default:
                                Console.WriteLine("That wasn't a valid input, we cannot remove items");
                                return false;
                        }
                    }
                    else
                    {
                        return true;
                    }

                case "0": //exit
                    Console.Clear();
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("That wasn't a 1, 2 , or 0...");
                    return true;
            }
        }
        return;
    }

    //manipulates json file
    public static bool ReadJson(string menuInput)
    {
        try
        {
            var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonLocation));

            if (json != null)
            {
                switch (menuInput)
                {

                    case "1": //lists milk
                        if (json.milk != null && json.milk.Count > 0)
                        {
                            foreach (var i in json.milk)
                            {

                                foreach (var prop in i.GetType().GetProperties())
                                {
                                    Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(i, null));
                                }
                                Console.WriteLine("\n");
                            }
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry! You don't have milk in your fridge.");
                            return false;
                        }

                    case "2": //lists pasta
                        if (json.pasta != null && json.pasta.Count > 0)
                        {
                            foreach (var i in json.pasta)
                            {
                                foreach (var prop in i.GetType().GetProperties())
                                {
                                    Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(i, null));
                                }
                                Console.WriteLine("\n");
                            }
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry! You don't have any pasta in your panty.");
                            return false;
                        }

                    default:
                        Console.WriteLine("That's not a 1 or 2....");

                        return false;
                }
            }
            else
            {
                Console.WriteLine("Sorry! You don't have anything listed.");
                return false;
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("FILE NOT FOUND: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": FILE NOT FOUND: " + ex);
            return false;
        }
        catch (JsonException ex)
        {
            Console.WriteLine("INVALID JSON: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": INVALID JSON: " + ex);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": ERROR: " + ex);
            return false;
        }
    }

    public static void WriteJson(double size, string type, string material)
    {
        try
        {
            var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonLocation));

            int highestID = 0;

            foreach (var i in json.milk)
            {
                if (i.id > highestID)
                {
                    highestID = i.id;
                }
                else
                {
                    break;
                }
            }

            json.Milk.Add(new milk()
            {
                id = highestID + 1,
                size = size,
                type = type,
                flavor= flavor
            });

            string json1 = JsonConvert.SerializeObject(json, Formatting.Indented);
            File.WriteAllText(jsonLocation, json1);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Item added Needles");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("FILE NOT FOUND: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": FILE NOT FOUND: " + ex);
        }
        catch (JsonException ex)
        {
            Console.WriteLine("INVALID JSON: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": INVALID JSON: " + ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": ERROR: " + ex);
        }
    }

    public static void WriteJson(string color, string weight, double length)
    {
        try
        {
            var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonLocation));

            int highestID = 0;
            foreach (var i in json.yarn)
            {
                if (i.id > highestID)
                {
                    highestID = i.id;
                }
            }

            Pasta pasta = new Pasta
            {
                id = highestID + 1,
                amount= amount,
                kind= kind,
                
            };

            json.pasta.Add(new Pasta()
            {
                id = highestID + 1,
                amount = amount,
                kind = kind,
            });

            string json1 = JsonConvert.SerializeObject(json, Formatting.Indented);
            File.WriteAllText(jsonLocation, json1);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Item added to Yarn");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("FILE NOT FOUND: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": FILE NOT FOUND: " + ex);
        }
        catch (JsonException ex)
        {
            Console.WriteLine("INVALID JSON: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": INVALID JSON: " + ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": ERROR: " + ex);
        }
    }

    public static void DeleteJson(string menuInput, string id)
    {
        try
        {
            var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonLocation));
            string json1 = "";

            switch (menuInput)
            {
                case "1":
                    foreach (var i in json.milk)
                    {
                        if (i.id == Convert.ToInt32(id))
                        {
                            json.needles.Remove(i);
                            Console.WriteLine("Item Removed");
                            break;
                        }
                    }

                    json1 = JsonConvert.SerializeObject(json, Formatting.Indented);
                    File.WriteAllText(jsonLocation, json1);
                    File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Item removed from Needles");
                    return;

                case "2":
                    foreach (var i in json.pasta)
                    {
                        if (i.id == Convert.ToInt32(id))
                        {
                            json.yarn.Remove(i);
                            Console.WriteLine("Item Removed");
                            break;
                        }
                    }

                    json1 = JsonConvert.SerializeObject(json, Formatting.Indented);
                    File.WriteAllText(jsonLocation, json1);
                    File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Item removed from Yarn");
                    return;
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("FILE NOT FOUND: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": FILE NOT FOUND: " + ex);
        }
        catch (JsonException ex)
        {
            Console.WriteLine("INVALID JSON: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": INVALID JSON: " + ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex);
            File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": ERROR: " + ex);
        }
    }
}