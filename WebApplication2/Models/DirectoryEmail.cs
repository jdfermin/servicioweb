using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class DirectoryEmail
{

    public int id { get; set; }
    
    public Directory directory { get; set; }
    public int directoryID { get; set; }
    
    public int emailID { get; set; }
    public Email email { get; set; }
}