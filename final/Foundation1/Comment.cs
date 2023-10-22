using System;

public class Comment
{
    public string _name;
    public string _comment;

    public Comment(string name, string comment)
    {
        _name = name;
        _comment = comment;
    }
    public void Display()
    {
        Console.WriteLine($"{_name}: {_comment} ");
    }
}