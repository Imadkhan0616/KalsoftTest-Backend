using KALSOFT_Test.DataContext;
using KALSOFT_Test.Domain.Models;
using KALSOFT_Test.Repositories.Abstract.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KALSOFT_Test.Repositories.Domain.Repository
{
    public class PropertiesDetailsRepository : IPropertiesDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public PropertiesDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<PropertyDetailsModel>> GetAll()
        {
            var result = await _context.PropertyDetails.ToListAsync();
            if (result != null)
                return result;
            return null;
        }

        public async Task<PropertyDetailsModel> GetById(int id)
        {
            var result = await _context.PropertyDetails.FindAsync(id);
            if (result is null)
                return null;
            return result;
        }
        public async Task<List<PropertyDetailsModel>> AddProperty(PropertyDetailsModel model)
        {
            _context.PropertyDetails.Add(model);
            await _context.SaveChangesAsync();
            var result = _context.PropertyDetails.ToListAsync();
            return await result;
        }

        public async Task<List<PropertyDetailsModel>> UpdateProperty(int id, PropertyDetailsModel model)
        {
            var data = await _context.PropertyDetails.FindAsync(id);
            if (data is null)
                return null;

            data.developerName = model.developerName;
            data.projectName = model.projectName;
            data.unit = model.unit;
            data.unitType = model.unitType;
            data.level = model.level;
            data.size = model.size;
            data.bedroom = model.bedroom;
            data.bathroom = model.bathroom;
            data.parking = model.parking;
            data.locker = model.locker;
            data.balcony = model.balcony;

            await _context.SaveChangesAsync();

            var result = await _context.PropertyDetails.ToListAsync();
            return result;
        }

        public async Task<List<PropertyDetailsModel>> DeleteProperty(int id)
        {
            var data = await _context.PropertyDetails.FindAsync(id);
            if (data == null)
                return null;

            await _context.PropertyDetails.Where(x => x.id == id).ExecuteDeleteAsync();
            var result = await _context.PropertyDetails.ToListAsync();
            return result;
        }

    }
}
