namespace WebApplication2.Models;

public class DirectoryPage
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<DirectoryDTO> results { get; set; }
}