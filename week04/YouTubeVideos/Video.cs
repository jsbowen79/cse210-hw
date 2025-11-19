using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private readonly List<Comment> _commentList;



    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _commentList = new List<Comment>(); 
    }

    public void AddComment (Comment comment)
    {
        _commentList.Add (comment);
 
    }

    public void printVideo ()
    {
        Console.WriteLine($"Video Title: {_title}");
        Console.WriteLine($"Video Author: {_author}");
        Console.WriteLine($"Video Length: {_length} seconds");
        Console.WriteLine($"There are {_commentList.Count} comments on this video!");

       int i = 1; 
        foreach (Comment item in _commentList)
            {
            Console.WriteLine($"Comment #{i} made by {item.GetUserID()}");
            Console.WriteLine($"Content: {item.GetComment()}"); 
            i++; 
            }
    }
}