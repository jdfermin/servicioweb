using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class Directory
{
    public int id { get; set; }
    public String name { get; set; }
    public List<DirectoryEmail> directoryEmails { get; set; }
}