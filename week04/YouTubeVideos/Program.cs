using System;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        var comment1 = Comment.CreateComment("Joseph Bowen", "What is this? ");
        var comment2 = Comment.CreateComment("John Hancock", "This is the best video ever");
        var comment3 = Comment.CreateComment("Purity Bowen", "I disagree!  This is the most worthless video I have ever seen!");
        var comment4 = Comment.CreateComment("John Hancock", "(Crying emoji)");
        var comment5 = Comment.CreateComment("Lisa Hendricks", "You can have abs like mine in just 35 minutes!");
        var comment6 = Comment.CreateComment("Sally Ford", "Liar!");
        var comment7 = Comment.CreateComment("Lisa Hendricks", "No...Really!  You can!");
        var comment8 = Comment.CreateComment("Sally Ford", "I know you Lisa!  Those aren't even your abs!");
        var comment9 = Comment.CreateComment("Susan Decker", "I have to go buy that right now.  Her hair is so beautiful!");
        var comment10 = Comment.CreateComment("Jared Villanueva", "We've been married for over 10 years and Francine has never been blonde!  I like blondes!");
        var comment11 = Comment.CreateComment("Francine Villanueva", "Shut up Jared!  I'm trying to make some money here!");
        var comment12 = Comment.CreateComment("Jared Villanueva", "Oh...Sorry honey.  You look very nice in the photo!");
        var comment13 = Comment.CreateComment("Susan Decker", "How do I get a refund? (angry emoji)" );
        var video1 = new Video("The funniest Comedy Show", "John Hancock", 36);
        var video2 = new Video("Tone your abs in 1 day...Guaranteed", "Lisa Hendricks", 2100);
        var video3 = new Video("Francine's Longer, Stronger Hair Infomercial", "Francine Villanueva", 2000); 

        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);
        video1.AddComment(comment4);
        video2.AddComment(comment5);
        video2.AddComment(comment6);
        video2.AddComment(comment7);
        video2.AddComment(comment8);
        video3.AddComment(comment9);
        video3.AddComment(comment10);
        video3.AddComment(comment11);
        video3.AddComment(comment12);
        video3.AddComment(comment13);

        List<Video> videoList = new List<Video>();
        videoList.Add(video1);
        videoList.Add(video2);
        videoList.Add(video3);

        foreach (Video item in videoList)
        {
             item.PrintVideo();
        }       
    }
}