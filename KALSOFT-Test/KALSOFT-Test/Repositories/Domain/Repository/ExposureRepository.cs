using KALSOFT_Test.DataContext;
using KALSOFT_Test.Domain.Models;
using KALSOFT_Test.Repositories.Abstract.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KALSOFT_Test.Repositories.Domain.Repository
{
    public class ExposureRepository : IExposureRepository
    {
        private readonly ApplicationDbContext _context;
        public ExposureRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExposureModel>> GetAll()
        {
            var result = await _context.Exposure.ToListAsync();
            if (result is null)
                return null;
            return result;
        }
    }
}
