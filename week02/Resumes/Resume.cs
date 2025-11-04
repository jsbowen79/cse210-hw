public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>(); 
    
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:"); 
        foreach ( Job job in _jobs)
        {
            Job.Display(job._jobTitle, job._company,  job._startYear, job._endYear); 
        }
    }
}