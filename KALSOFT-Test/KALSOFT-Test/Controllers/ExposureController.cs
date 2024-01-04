using KALSOFT_Test.Domain.Models;
using KALSOFT_Test.Repositories.Abstract.IRepository;
using KALSOFT_Test.Repositories.Domain.Repository;
using KALSOFT_Test.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KALSOFT_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExposureController : ControllerBase
    {
        private readonly IExposureRepository _exposureRepository;
        public ExposureController(IExposureRepository exposureRepository)
        {
            _exposureRepository = exposureRepository;
        }

        [HttpGet]
        [Route("GetAllExposure")]
        public async Task<CustomResponse<ExposureModel>> GetAll()
        {
            try
            {
                var result = await _exposureRepository.GetAll();
                if (result == null || result.Count() == 0)
                {
                    var emptyResponse = new CustomResponse<ExposureModel>
                    {
                        Message = "Record list is empty.",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = null
                    };
                    return emptyResponse;
                }

                var successResponse = new CustomResponse<ExposureModel>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = result
                };
                return successResponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
