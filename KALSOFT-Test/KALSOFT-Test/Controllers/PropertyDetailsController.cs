using KALSOFT_Test.Domain.Models;
using KALSOFT_Test.Repositories.Abstract.IRepository;
using KALSOFT_Test.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KALSOFT_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyDetailsController : ControllerBase
    {
        private readonly IPropertiesDetailRepository _propertiesDetailRepository;

        public PropertyDetailsController(IPropertiesDetailRepository propertiesDetailRepository)
        {
            _propertiesDetailRepository = propertiesDetailRepository;   
        }

        [HttpGet]
        [Route("GetAllProperties")]
        public async Task<CustomResponse<PropertyDetailsModel>> GetAll()
        {
            try
            {
                var result = await _propertiesDetailRepository.GetAll();
                if (result == null || result.Count() == 0)
                {
                    var emptyResponse = new CustomResponse<PropertyDetailsModel>
                    {
                        Message = "Record list is empty.",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = null
                    };
                    return emptyResponse;
                }

                var successResponse = new CustomResponse<PropertyDetailsModel>
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

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<CustomResponse<PropertyDetailsModel>> GetById(int id)
        {
            try
            {
                var result = await _propertiesDetailRepository.GetById(id);
                if (result == null)
                {
                    var emptyResponse = new CustomResponse<PropertyDetailsModel>
                    {
                        Message = "Requested Record Not Found!",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = null
                    };
                    return emptyResponse;
                }

                IEnumerable<PropertyDetailsModel> iResponceList = new List<PropertyDetailsModel> { result };

                var successResponse = new CustomResponse<PropertyDetailsModel>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = iResponceList
                };
                return successResponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [HttpPost]
        [Route("AddProperty")]
        public async Task<CustomResponse<PropertyDetailsModel>> AddProperty(PropertyDetailsModel model)
        {
            try
            {
                var result = await _propertiesDetailRepository.AddProperty(model);
                if (result == null || result.Count() == 0)
                {
                    var emptyResponse = new CustomResponse<PropertyDetailsModel>
                    {
                        Message = "Record list is empty.",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = null
                    };
                    return emptyResponse;
                }

                var successResponse = new CustomResponse<PropertyDetailsModel>
                {
                    Message = "Record Created Successfully",
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

        [HttpPut]
        [Route("UpdateProperty/{id}")]
        public async Task<CustomResponse<PropertyDetailsModel>> UpdateProperty(int id, PropertyDetailsModel model)
        {
            try
            {
                var result = await _propertiesDetailRepository.UpdateProperty(id, model);
                if (result == null || result.Count() == 0)
                {
                    var emptyResponse = new CustomResponse<PropertyDetailsModel>
                    {
                        Message = "Record list is empty.",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = null
                    };
                    return emptyResponse;
                }

                var successResponse = new CustomResponse<PropertyDetailsModel>
                {
                    Message = "Updated Successfully.",
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

        [HttpDelete]
        [Route("DeleteProperty/{id}")]
        public async Task<CustomResponse<PropertyDetailsModel>> DeleteProperty(int id)
        {
            try
            {
                var result = await _propertiesDetailRepository.DeleteProperty(id);
                if (result == null || result.Count() == 0)
                {
                    var emptyResponse = new CustomResponse<PropertyDetailsModel>
                    {
                        Message = "Deleted Successfully.",
                        StatusCode = StatusCodes.Status204NoContent,
                        Data = null
                    };
                    return emptyResponse;
                }

                var successResponse = new CustomResponse<PropertyDetailsModel>
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
