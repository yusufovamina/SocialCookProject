using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.Json;

List<User> users = LoadUserCredentials();
User loggedInUser = new User();
loggedInUser.YourMeals = LoadRecipesFromFile("userMeals.dat", loggedInUser.Username);
List<Meal> meals = new List<Meal> {
    new Meal
    {
        Name="Scrambled Eggs",
        Type=MealType.Breakfast,
        Recipe= new Recipe
    {
        Name = "Scrambled Eggs",
        Ingredients = new List<string> { "Eggs", "Milk", "Salt", "Pepper" },
        Instructions = "Whisk eggs, milk, salt, and pepper in a bowl. Heat a non-stick skillet over medium heat. Pour egg mixture into the skillet and cook, stirring, until eggs are set.",
        CookingTime = 10
    },
    },
    new Meal{
    Name="Pancakes",
    Type=MealType.Breakfast,
    Recipe = new Recipe
    {
        Name = "Pancakes",
        Ingredients = new List<string> { "Flour", "Milk", "Eggs", "Baking Powder", "Salt", "Sugar" },
        Instructions = "In a bowl, mix flour, baking powder, salt, and sugar. In a separate bowl, whisk eggs, add milk and mix well. Combine wet and dry ingredients. Cook spoonfuls of the batter on a greased pan until bubbles form, then flip and cook the other side.",
        CookingTime = 20
    },
    },
new Meal
{
    Name="Chicken Salad",
    Type=MealType.Lunch,
    Recipe= new Recipe
    {
        Name = "Chicken Salad",
        Ingredients = new List<string> { "Chicken Breast", "Lettuce", "Tomatoes", "Cucumbers", "Olives", "Olive Oil", "Salt", "Pepper" },
        Instructions = "Grill the chicken breast, slice into strips. Mix with lettuce, tomatoes, cucumbers, and olives. Drizzle with olive oil and season with salt and pepper.",
        CookingTime = 30
    },
},
    new Meal
{
    Name="Vegetarian Pasta",
    Type=MealType.Lunch,
    Recipe=  new Recipe
    {
        Name = "Vegetarian Pasta",
        Ingredients = new List<string> { "Pasta", "Bell Peppers", "Zucchini", "Cherry Tomatoes", "Olive Oil", "Garlic", "Basil", "Salt", "Pepper" },
        Instructions = "Cook pasta according to package instructions. In a pan, sauté chopped vegetables and garlic in olive oil. Toss with cooked pasta. Season with salt, pepper, and fresh basil.",
        CookingTime = 25
    },
    },
    new Meal
    {
   Name="Chocolate Cake",
    Type = MealType.Dessert,

    Recipe=new Recipe
    {
    Name = "Chocolate Cake",
    Ingredients = new List<string> { "Flour", "Sugar", "Cocoa Powder", "Baking Powder", "Salt", "Eggs", "Milk", "Vegetable Oil", "Vanilla Extract" },
    Instructions = "Mix dry ingredients, then add wet ingredients. Pour into a cake pan and bake in a preheated oven. Allow to cool before frosting.",
    CookingTime = 40
},
    },
    new Meal
    {
        Name="Pizza Margarita",
        Type =MealType.Dinner,
        Recipe= new Recipe
        {
            Name = "Pizza Margarita",
            Ingredients = new List<string> { "Pizza Dough", "Tomato Sauce", "Fresh Mozzarella", "Fresh Basil", "Olive Oil", "Salt" },
            Instructions = "Preheat oven to 475°F (245°C). Roll out the pizza dough. Spread tomato sauce over the dough. Add slices of fresh mozzarella. Bake in the preheated oven until crust is golden and cheese is bubbly. Top with fresh basil leaves and a drizzle of olive oil.",
            CookingTime = 20
        }
    },
    new Meal
    {
        Name="Fruit Salad",
        Type=MealType.Dessert,
        Recipe=new Recipe
    {
        Name = "Fruit Salad",
        Ingredients = new List<string> { "Assorted Fruits (e.g., apples, bananas, berries, oranges)", "Honey", "Lemon Juice", "Mint Leaves" },
        Instructions = "Cut fruits into bite-sized pieces and mix in a bowl. Drizzle with honey and lemon juice. Garnish with mint leaves.",
        CookingTime = 15
    },
    },
    new Meal
    {
        Name="Grilled Salmon",
        Type=MealType.Dinner,
        Recipe= new Recipe
    {
        Name = "Grilled Salmon",
        Ingredients = new List<string> { "Salmon Fillets", "Lemon", "Garlic", "Olive Oil", "Salt", "Pepper" },
        Instructions = "Marinate salmon fillets in lemon juice, minced garlic, olive oil, salt, and pepper. Grill until fish is cooked through and flakes easily.",
        CookingTime = 60
    },
    }

};

startAnimation();
Console.WriteLine("Welcome!");
string[] startMenu = new string[]
{"Register",
    "Log in",
    "Exit"
};

int choice = Menu(startMenu);

switch (choice)
{
    case 1:
        Register(users);
        Console.WriteLine();
        break;
    case 2:
        Login(users);
        Console.WriteLine();
        var a = (Console.ReadKey().Key);
        if (a == ConsoleKey.Enter)
        {
            break;
        }
        break;
    case 3:
        return;
        break;
    default:
        Console.WriteLine("Invalid choice. try again.");
        break;

}
while (true)
{

    string[] menu = new string[] {
    "1. See recipes",
    "2. Add your recipe",
    "3. Find recipe by ingrediens",
    "4. Save recipes",
    "5. Your profile"
 };

    int choice2 = Menu(menu);

    switch (choice2)
    {
        case 1:

            string[] displayMenu = new string[]
            {
                "1. See all recipes",
                "2. See breakfast meals",
                "3. See lunch meals",
                "4. See dinner meals",
                "5. See dessert meals",
                "6. See fast-cookking meals"
            };
            int choice3 = Menu(displayMenu);
            switch(choice3){
                case 1:   
                    meals.ForEach(Console.WriteLine);
                    var k = (Console.ReadKey().Key);
                    if (k == ConsoleKey.LeftArrow)
                    {
                        break;
                    }
                    break;
                case 2:
                    var breakfastMeals = meals.Where(x=>x.Type==MealType.Breakfast).ToList();
                    breakfastMeals.ForEach(Console.WriteLine);
                    var k1 = (Console.ReadKey().Key);
                    if (k1 == ConsoleKey.LeftArrow)
                    {
                        break;
                    }
                    break;
                case 3:
                    var lunchMeals = meals.Where(x => x.Type == MealType.Lunch).ToList();
                    lunchMeals.ForEach(Console.WriteLine);
                    var k2 = (Console.ReadKey().Key);
                    if (k2 == ConsoleKey.LeftArrow)
                    {
                        break;
                    }
                    break;
                case 4:
                    var dinnerMeals = meals.Where(x => x.Type == MealType.Dinner).ToList();
                    dinnerMeals.ForEach(Console.WriteLine);
                    var k3 = (Console.ReadKey().Key);
                    if (k3 == ConsoleKey.LeftArrow)
                    {
                        break;
                    }
                    break;
                case 5:
                    var dessertMeals = meals.Where(x => x.Type == MealType.Dessert).ToList();
                    dessertMeals.ForEach(Console.WriteLine);
                    var k4 = (Console.ReadKey().Key);
                    if (k4 == ConsoleKey.LeftArrow)
                    {
                        break;
                    }
                    break;
                case 6:
                    int time;
                    Console.WriteLine("How much time do you have?");
                    time=int.Parse(Console.ReadLine());
                    var timingMeals=meals.Where(x=>x.Recipe.CookingTime<=time).ToList();
                    if (timingMeals == null)
                    {
                        Console.WriteLine("None");
                    }
                    timingMeals.ForEach(Console.WriteLine);
                    var k5 = (Console.ReadKey().Key);
                    if (k5 == ConsoleKey.LeftArrow) break;
                    
                    break;

            }

            var key = (Console.ReadKey().Key);
            if (key == ConsoleKey.LeftArrow)
            {
                break;
            }
            break;
        case 2:
            loggedInUser.AddRecipe(meals,loggedInUser.YourMeals);
            var key1 = (Console.ReadKey().Key);
            if (key1 == ConsoleKey.LeftArrow)
            {
                break;
            }
            break;
        case 3:
            Console.Write("Enter ingredients (comma-separated): ");
            string ingredientsInput = Console.ReadLine();
            List<string> ingredients = ingredientsInput.Split(',').Select(i => i.Trim()).ToList();
            loggedInUser.SearchRecipesByIngredients(ingredients, meals);
            var key2 = (Console.ReadKey().Key);

            if (key2 == ConsoleKey.LeftArrow)
            {
                break;
            }
            break;
        case 4:
            var recpts = meals.Select(x => x.Name).ToArray();
            int ch = Menu(recpts);

            loggedInUser.SaveMeal(meals[ch - 1]);
            SaveMealsToFile("usersSavedMeals.dat", loggedInUser.SavedMeals,loggedInUser.Name);
            var key7 = (Console.ReadKey().Key);

            if (key7 == ConsoleKey.LeftArrow)
            {
                break;
            }
            break;


        case 5:
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\tYour account:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(loggedInUser);
            var key3 = (Console.ReadKey().Key);
            if (key3 == ConsoleKey.Enter)
            {
                string[] profile_menu = new string[] {
                "1. See saved recipes",
                "2. See your recipes",

             };


                int profile_choice = Menu(profile_menu);

                switch (profile_choice)
                {
                    case 1:
                        loggedInUser.SavedMeals = LoadRecipesFromFile("usersSavedMeals.dat",loggedInUser.Name);
                        loggedInUser.DisplaySavedRecipes();
                        break;

                    case 2:
                        
                        loggedInUser.YourMeals.ForEach(Console.WriteLine);
                       
                        break;

                }
            }


            var key4 = (Console.ReadKey().Key);
            if (key4 == ConsoleKey.LeftArrow)
            {
                break;
            }
            break;
        default:
            Console.WriteLine("Invalid choice. try again.");
            break;

    }


}




#region Methods


 List<Meal> LoadRecipesFromFile(string filename,string name)
{
    string namefile = name + filename;
    List<Meal> meals = new List<Meal>();

    try
    {

        using (FileStream fs = new FileStream(namefile, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            meals = (List<Meal>)bf.Deserialize(fs);
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File not found");
    }
    catch (SerializationException)
    {
        Console.WriteLine("Couldn't serialize the file");
    }
    return meals;
}
 void SaveMealsToFile(string filename, List<Meal> meals,string name)

{
    string namefile = name + filename;

    try
    {

        using (FileStream fs = new FileStream(namefile, FileMode.Create))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, meals);
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File not found");
    }
    catch (SerializationException)
    {
        Console.WriteLine("Couldn't serialize the file");
    }

}
void startAnimation()
{
    string asciiArt = @"
                    (\
                     \\
                 __    \\___,.-------..__         __
                //\\ _,-'\\               `'--._ //\\
                \\ ;'      \\                   `: //
                 `(          \\                   )'
                   :.          \\,----,         ,;
                    `.`--.___   (    /  ___.--','
                      `.     ``-----'-''     ,'
                         -.               ,-
                            `-._______.-'
";

    string greeting = @"
.d88888b                    oo          dP  a88888b.                   dP       
88.    ""'                              88 d8'   `88                   88       
`Y88888b. .d8888b. .d8888b. dP .d8888b. 88 88        .d8888b. .d8888b. 88  .dP  
      `8b 88'  `88 88'  `"""" 88 88'  `88 88 88        88'  `88 88'  `88 88888""   
d8'   .8P 88.  .88 88.  ... 88 88.  .88 88 Y8.   .88 88.  .88 88.  .88 88  `8b. 
 Y88888P  `88888P' `88888P' dP `88888P8 dP  Y88888P' `88888P' `88888P' dP   `YP 

";

    
     


    for (int i = 0; i < 20; i++)
    {
        try
        { 
                Console.Clear();
                Console.ForegroundColor = (ConsoleColor)i;
                Console.WriteLine(greeting);
                Console.WriteLine();
                Console.WriteLine(asciiArt);
                Thread.Sleep(100);
            
        }
        catch (Exception) {}
   }
}

static void DisplayMenu(string[] menu, int selectedOption)
{
    Console.Clear();
    for (int i = 0; i < menu.Length; i++)
    {
        if (i == selectedOption)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("> " + menu[i]);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  " + menu[i]);
        }


    }
    Console.ForegroundColor = ConsoleColor.White;
}

int Menu(string[] menu)
{

    int selectedOption = 0;

    while (true)
    {
        DisplayMenu(menu, selectedOption);

        var key = (Console.ReadKey().Key);

        switch (key)
        {
            case ConsoleKey.UpArrow:
                selectedOption = (selectedOption == 0) ? menu.Length - 1 : selectedOption - 1;
                break;
            case ConsoleKey.DownArrow:
                selectedOption = (selectedOption == menu.Length - 1) ? 0 : selectedOption + 1;
                break;
            case ConsoleKey.Enter:
                Console.Clear();
                return selectedOption + 1;
        }
    }
}




List<User> LoadUserCredentials()
{
    List<User> users = new List<User>();
    User currentUser = null;

    try
    {
        using (StreamReader reader = new StreamReader("users.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("---"))
                {
                    if (currentUser != null)
                        users.Add(currentUser);

                    currentUser = new User();
                }
                else
                {
                    string[] parts = line.Split(new char[] { ':' }, 2);

                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        switch (key)
                        {
                            case "Name":
                                currentUser.Name = value;
                                break;
                            case "Surname":
                                currentUser.Surname = value;
                                break;
                            case "Age":
                                currentUser.Age = int.Parse(value);
                                break;
                            case "Username":
                                currentUser.Username = value;
                                break;
                            case "Password":
                                currentUser.Password = value;
                                break;
                        }
                    }
                }
            }

            
            if (currentUser != null)
                users.Add(currentUser);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while loading users: " + ex.Message);
    }

    return users;
}

void SaveUserCredentials(List<User> users)
{
  
        try
        {
            using (StreamWriter writer = new StreamWriter("users.txt"))
            {
                foreach (var user in users)
                {
                    writer.WriteLine("---"); 
                    writer.WriteLine($"Name:{user.Name}");
                    writer.WriteLine($"Surname:{user.Surname}");
                    writer.WriteLine($"Age:{user.Age}");
                    writer.WriteLine($"Username:{user.Username}");
                    writer.WriteLine($"Password:{user.Password}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while saving users: " + ex.Message);
        }
    }

void Register(List<User> users)
{
   
    Console.Write("Enter your name: ");
    string name = Console.ReadLine().Trim();
    Console.Write("Enter your surname: ");
    string surname = Console.ReadLine().Trim();
    Console.Write("Enter your age: ");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter a new username: ");
    string username = Console.ReadLine().Trim();
    foreach (var i in users)
    {
        if (i.Username == username)
        {
            Console.WriteLine("User with that username already exists");
            return;
        }
    }

    Console.Write("Enter a password: ");
    string password = GetMaskedPassword();
    while(!isStrongPassword(password))
    {
        Console.Write("Enter a password: ");
        password = GetMaskedPassword();
    }


    loggedInUser = new User(name, surname, age, username, password);
    users.Add(loggedInUser);
    SaveUserCredentials(users);

    Console.WriteLine("User registered successfully");
}

void Login(List<User> users)
{

    Console.Write("Enter your username:  ");
    string username = Console.ReadLine().Trim();


    Console.Write("Enter your password: ");
    string password = GetMaskedPassword();
    loggedInUser = users.FirstOrDefault(x => x.Username == username && x.Password == password);
    while (loggedInUser == null)
    {
        Console.WriteLine("Wrong username or password.Try again!");
        Console.Write("Enter your username:  ");
        username = Console.ReadLine().Trim();


        Console.Write("Enter your password: ");
        password = GetMaskedPassword();

        Console.Clear();
        loggedInUser = users.FirstOrDefault(x => x.Username == username && x.Password == password);
    }
    Console.WriteLine($"Welcome, {username}!");

}

bool isStrongPassword(string password)
{
    if (password.Length<8) return false;

    bool hasUpper=false, hasLower=false, hasNumb=false;

    if (password.Any(char.IsUpper)) { hasUpper = true; }
     if (password.Any(char.IsLower)) { hasLower = true; }
     if (password.Any(char.IsDigit)) { hasNumb = true; }
    return hasUpper&&hasUpper && hasLower;
    
}

string GetMaskedPassword()
{
    string password = "";
    ConsoleKeyInfo key;
    do
    {
        key = Console.ReadKey(true);

        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
        {
            password += key.KeyChar;
            Console.Write("*");
        }
        else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
        {
            password = password.Substring(0, (password.Length - 1));
            Console.Write("\b \b");
        }
    } while (key.Key != ConsoleKey.Enter);

    Console.WriteLine();
    return password;
}




#endregion
abstract class Person
{
    public abstract string Name { get; set; }
    public abstract string Surname { get; set; }
    public abstract int Age { get; set; }
}

class User : Person
{
    public override string Name { get; set; }
    public override string Surname { get; set; }
    public override int Age { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
    public List<Meal> SavedMeals { get; set; } 

    public List<Meal> YourMeals { get; set; } = new List<Meal>();
    public User()
    {

    }
    public User(string name, string surname, int age, string username, string password)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Username = username;
        Password = password;
        SavedMeals = new List<Meal>();
        YourMeals = new List<Meal>();
    }


    public void SaveMeal(Meal meal)
    {
        SavedMeals.Add(meal);

        Console.WriteLine($"Recipe '{meal.Name}' saved in your account.");
    }

  

    public void DisplaySavedRecipes()
    {
        Console.WriteLine("Saved recipes:");
        if (SavedMeals.Count == 0)
        {
            Console.WriteLine("No saved recipes found");
        }
        else
        {
            foreach (var meal in SavedMeals)
            {
                if (meal.Recipe != null)
                {
                    Console.WriteLine($"{meal}");
                    Console.WriteLine();
                }
            }
        }
    }


    void SaveUsersMealsToFile(string filename, List<Meal> meals, string name)

    {
        string namefile = name + filename;

        try
        {

            using (FileStream fs = new FileStream(namefile, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, meals);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (SerializationException)
        {
            Console.WriteLine("Couldn't serialize the file");
        }

    }

    public void AddRecipe(List<Meal> meals, List<Meal> YourMeals)

    {
        Console.Write("Enter recipe name: ");
        string name = Console.ReadLine().Trim();

        Console.Write("Enter ingredients (comma-separated): ");
        List<string> ingredients = Console.ReadLine().Split(',').Select(i => i.Trim()).ToList();

        Console.Write("Enter instructions: ");
        string instructions = Console.ReadLine().Trim();

        Console.WriteLine("Enter the cooking time(minutes): ");
        int time = int.Parse(Console.ReadLine());

        Console.WriteLine("Select a meal type:");
        Console.WriteLine("1. Breakfast");
        Console.WriteLine("2. Lunch");
        Console.WriteLine("3. Dinner");
        Console.WriteLine("4. Dessert");

        int choice = int.Parse(Console.ReadLine());

        MealType type;
        switch (choice)
        {
            case 1:
                type = MealType.Breakfast;
                break;
            case 2:
                type = MealType.Lunch;
                break;
            case 3:
                type = MealType.Dinner;
                break;
            case 4:
                type = MealType.Dessert;
                break;
            default:
                Console.WriteLine("Invalid meal type. Recipe not added.");
                return;
        }

        Meal newMeal = new Meal(name, type, new Recipe(name, ingredients, instructions, time, this.Username));

        YourMeals.Add(newMeal);
        SaveUsersMealsToFile("userMeals.dat", YourMeals, Username);

        meals.Add(newMeal);


        Console.WriteLine("Recipe added successfully!");
    }

    public void SearchRecipesByIngredients(List<string> ingredients, List<Meal> meals)
    {
        bool foundMatchingMeal = false;

        foreach (var meal in meals)
        {

            if (ingredients.All(meal.Recipe.Ingredients.Contains))
            {
                foundMatchingMeal = true;
                Console.WriteLine();
                Console.WriteLine(meal);
                Console.WriteLine();
                Console.WriteLine("Missing Ingredients:");
                var missingIngredients = meal.Recipe.Ingredients.Where(ingredient => !ingredients.Contains(ingredient)).ToList();

                if (missingIngredients.Any())
                {
                    foreach (var ingredient in missingIngredients)
                    {
                        Console.WriteLine($"- {ingredient}");
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }
                Console.WriteLine();
            }
        }

        if (!foundMatchingMeal)
        {
            Console.WriteLine("No recipes found containing the given ingredients.");
        }
    }

    public override string ToString()
    {
        return $"Name: {Name}\nSurname: {Surname}\nAge: {Age}\nUsername: {Username}";
    }
}
[Serializable]
class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public string Instructions { get; set; }
    public int CookingTime { get; set; }
    public string Author { get; set; } = "Admin";

    public Recipe(string name, List<string> ingredients, string instructions, int cookingTime, string author)
    {
        Name = name; Ingredients = ingredients;
        Instructions = instructions; CookingTime = cookingTime;
        Author = author;
    }
    public Recipe()
    {

    }

    public override string ToString()
    {
        return $"\nRecipe: {Name} (by {Author})\n" +
               $"Cooking Time: {CookingTime} minutes\n" +
               $"Ingredients: {string.Join(", ", Ingredients)}\n" +
               $"Instructions: {Instructions}\n";
    }

}


enum MealType
{
    Breakfast,
    Lunch,
    Dinner,
    Dessert
}
interface IMeal
{
    string Name { get; set; }
    public MealType Type { get; set; }
    public Recipe Recipe { get; set; }


}

[Serializable]
class Meal : IMeal
{
    public string Name { get; set; }
    public MealType Type { get; set; }
    public Recipe Recipe { get; set; }
    public Meal()
    {

    }
    public Meal(string name, MealType type, Recipe recipe)
    {
        Name = name; Type = type; Recipe = recipe;
    }
    public override string ToString()
    {


        return $"\t\t{Name}\n\t\t-{Type}\n{Recipe}";

    }

}


