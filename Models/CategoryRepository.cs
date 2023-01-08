namespace MithrasPieShop.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly MithrasPieShopDbContext _mithrasPieShopDbContext;

    public CategoryRepository(MithrasPieShopDbContext mithrasPieShopDbContext)
    {
        _mithrasPieShopDbContext = mithrasPieShopDbContext;
    }

    public IEnumerable<Category> AllCategories => _mithrasPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
}