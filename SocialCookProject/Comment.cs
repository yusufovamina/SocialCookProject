[Serializable]
class Comment
{
    public string Username { get; set; }
    public int Rate { get; set; }
    public string Commentariy { get; set; }
    public int Id { get; set; }
    public Comment(string name,int rate, string commentariy)
    {
        Id = new Random().Next(10000, 99999);
        Username = name;
        if (rate <= 5)
        {
            Rate = rate;
        }
        Commentariy = commentariy;
    }
    public override string ToString()
    {
        return $"\n>{Username}\n{Rate}/5\n{Commentariy}";
    }
}
