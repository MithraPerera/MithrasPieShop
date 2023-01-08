namespace MithrasPieShop.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty; //made to initially be empty because it should not be nullable in the application
    public string? Description { get; set; }
    public List<Pie>? Pies { get; set; }
}