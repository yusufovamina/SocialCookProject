using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;

class User : Person
{
    public override string Name { get; set; }
    public override string Surname { get; set; }
    public override int Age { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
    public List<Meal> SavedMeals { get; set; } = new List<Meal>();

    public List<Meal> YourMeals { get; set; } = new List<Meal>();
    public int Id { get; set; } = new Random().Next(10000, 99999);
    public User()
    {}
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



 static void SaveUsersMealsToFile(string filename, List<Meal> meals, string name)
    {
        string namefile = name + filename;
        try
        {

            using (FileStream fs = new FileStream(filename, FileMode.Create))
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
    fileOperationsDelegate saving = new(SaveUsersMealsToFile);
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
        saving("userMeals.dat", YourMeals, Username);
        meals.Add(newMeal);

        saving("Allmeals.dat", meals,"");
        

        Console.WriteLine("Recipe added successfully!");
    }

    public void SearchRecipesByIngredients(List<string> ingredients, List<Meal> meals)
    {
        var matchingRecipes = meals.Where(m => m.Recipe.Ingredients.Any(x => ingredients.Any(inputIng =>
                x.IndexOf(inputIng, StringComparison.OrdinalIgnoreCase) >= 0)));

       
            if (matchingRecipes.Any())
            {
          foreach(var meal in matchingRecipes) { 
                Console.WriteLine();
                Console.WriteLine(meal);
                Console.WriteLine();
            var missingIngredients = meal.Recipe.Ingredients.Where(ing => ingredients.All(inputIng =>
               !ing.Contains(inputIng, StringComparison.OrdinalIgnoreCase)))
           .ToList();

            if (missingIngredients.Any())
            {
                Console.WriteLine("Missing Ingredients:");
                foreach (var missingIngredient in missingIngredients)
                {
                    Console.WriteLine($"- {missingIngredient}");
                }
            }

            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("No recipes found with the specified ingredients.");
    }
    }

    public override string ToString()
    {
        return $"Name: {Name}\nSurname: {Surname}\nAge: {Age}\nUsername: {Username}";
    }
}
