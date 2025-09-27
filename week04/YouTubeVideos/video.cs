// Video.cs
using System.Collections.Generic;

public class Video
{
    // Properties
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to get all comments
    public List<Comment> GetComments()
    {
        return new List<Comment>(_comments);
    }
}