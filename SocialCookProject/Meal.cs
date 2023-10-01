[Serializable]
class Meal : IMeal
{
    public string Name { get; set; }
    public MealType Type { get; set; }
    public Recipe Recipe { get; set; }
    public List<Comment> Сomments;
    public int Id { get; set; } 
    public Meal()
    {   Id = new Random().Next(10000, 99999);
        Сomments = new List<Comment>(); 
    }
    public Meal(string name, MealType type, Recipe recipe)
    {
        Name = name; Type = type; Recipe = recipe; Сomments = new List<Comment>();
    }

    public void AddComment(string username,int rate, string commentary)
    {
        Comment com = new Comment(username,rate, commentary);
        Сomments.Add(com);
    }

    public override string ToString()
     {    double averageRate;
        if (Сomments.Count > 0)
        {
            averageRate= Сomments.Average(comment => comment.Rate);
        }
        else { averageRate = 0; }
        string mealInfo = $"\t\t{Name}\n\t\t-{Type}\n{averageRate}/5\n{Recipe}\n";

        if (Сomments != null && Сomments.Any())
        {          
            mealInfo += "\nComments:\n";
            foreach (var comment in Сomments)
            {
                mealInfo += comment.ToString() + "\n";
            }
        }

        mealInfo += "\n";
        return mealInfo;
    }

}
