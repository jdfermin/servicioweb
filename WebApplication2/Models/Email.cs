namespace WebApplication2.Models;

public class Email
{
    public int id { get; set; }
    public String adress { get; set; }
    public List<DirectoryEmail> directoryEmails { get; set; }
}