public class Comment
{
    private string _userid;
    private string _comment;
    public Comment()
    {
        _userid = "";
        _comment = "";

    }

    public string GetUserID()
    {
        return _userid;
    }

    public string GetComment()
    {
        return _comment;
    }
    

    public static Comment CreateComment(string name, string userComment) 
    {
        Comment comment = new Comment(); 
        comment._userid = name; 
        comment._comment=userComment;    
        return comment;  
    }

}