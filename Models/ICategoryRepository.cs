namespace MithrasPieShop.Models;

public interface ICategoryRepository
{
    IEnumerable<Category> AllCategories { get; }
}