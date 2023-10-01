[Serializable]
class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public string Instructions { get; set; }
    public int CookingTime { get; set; }
    public string Author { get; set; } = "Admin";
    public int Id { get; set; } = new Random().Next(10000, 99999);
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
