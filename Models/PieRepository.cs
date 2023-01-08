using Microsoft.EntityFrameworkCore;

namespace MithrasPieShop.Models;

public class PieRepository : IPieRepository
{
    // because we registered the DbContext with the dependency injection container
    // we can now access that here also through a constructor injection
    private readonly MithrasPieShopDbContext _mithrasPieShopDbContext;

    public PieRepository(MithrasPieShopDbContext mithrasPieShopDbContext)
    {
        _mithrasPieShopDbContext = mithrasPieShopDbContext;
    }

    // Returns all the pies and their associated categories
    public IEnumerable<Pie> AllPies
    {
        get { return _mithrasPieShopDbContext.Pies.Include(c => c.Category); }
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get { return _mithrasPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek); }
    }

    // Returns first pie that matches id or otherwise returns default
    public Pie? GetPieById(int pieId)
    {
        return _mithrasPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
    }
}