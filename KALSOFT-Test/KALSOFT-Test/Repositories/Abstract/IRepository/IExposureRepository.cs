using KALSOFT_Test.Domain.Models;

namespace KALSOFT_Test.Repositories.Abstract.IRepository
{
    public interface IExposureRepository
    {
       public Task<List<ExposureModel>> GetAll();
    }
}
