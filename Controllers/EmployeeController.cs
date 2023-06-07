using APIAssignment1.EFCore;
using APIAssignment1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIAssignment1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbHelper _db;
        public EmployeeController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
        [HttpGet]
        [Route("api/[controller]/GetEmployee")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<EmployeeModel> data = _db.GetEmployee();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("api/[controller]/GetEmployeeById")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                EmployeeModel data = _db.GetEmployeeById(id);

                if (data.id==0)
                {
                    type = ResponseType.NotFound;
                    return NotFound(ResponseHandler.GetAppResponse(type, "Record Not Found"));
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("api/[controller]/SaveEmployee")]
        public IActionResult Post([FromBody] EmployeeModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var response = _db.SaveEmployee(model);
                if (Convert.ToInt16(response.StatusCode) == 409)
                {
                    type = ResponseType.Conflict;
                    return Ok(ResponseHandler.GetAppResponse(type, "key already exists"));
                }
                else
                {
                    return Ok(ResponseHandler.GetAppResponse(type, model));
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateEmployee")]
        public IActionResult Put([FromBody] EmployeeModel model)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                var response = _db.SaveEmployee(model);
                if (Convert.ToInt16(response.StatusCode) == 404)
                {
                    type = ResponseType.NotFound;
                    return Ok(ResponseHandler.GetAppResponse(type, "Record Not Found"));
                }
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _db.DeleteEmployee(id);
                ResponseType type = ResponseType.Success;
                if(Convert.ToInt16(response.StatusCode) == 404)
                {
                    type = ResponseType.NotFound;
                    return Ok(ResponseHandler.GetAppResponse(type, "Record Not Found"));
                }
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
                
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpPatch]
        [Route("api/[controller]/PatchEmployee/{id}")]
        public IActionResult UpdateEmployeePatch([FromBody] JsonPatchDocument EmployeeModel, [FromRoute] int id)
        {
            try
            {
                var response = _db.UpdateEmployeePatch(id, EmployeeModel);
                ResponseType type = ResponseType.Success;
                if (Convert.ToInt16(response.StatusCode) == 404)
                {
                    type = ResponseType.NotFound;
                    return Ok(ResponseHandler.GetAppResponse(type, "Record Not Found"));
                }
                
                return Ok(ResponseHandler.GetAppResponse(type, "Updated Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

    }
}

