using KALSOFT_Test.Domain.Models;

namespace KALSOFT_Test.Repositories.Abstract.IRepository
{
    public interface IPropertiesDetailRepository
    {
        public Task<List<PropertyDetailsModel>> GetAll();
        public Task<PropertyDetailsModel> GetById(int id);
        public Task<List<PropertyDetailsModel>> AddProperty(PropertyDetailsModel model);
        public Task<List<PropertyDetailsModel>> UpdateProperty(int id, PropertyDetailsModel model);
        public Task<List<PropertyDetailsModel>> DeleteProperty(int id);
    }
}
