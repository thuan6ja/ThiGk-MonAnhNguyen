using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhuThuan_K2023_THIGK.Dtos.Course;
using NhuThuan_K2023_THIGK.Dtos.Enrollment;
using NhuThuan_K2023_THIGK.Services.Course;
using NhuThuan_K2023_THIGK.Services.Enrollment;

namespace NhuThuan_K2023_THIGK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _EnrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _EnrollmentService = enrollmentService;

        }
        // Lấy danh sách điểm danh của một khóa học
        

        [HttpGet]

        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _EnrollmentService.GetbyCourseId(id);
            return Ok(result);
        }
        [HttpPut ("update")]
        public async Task<IActionResult> Update(EnrollmentConfirmedRequest request)
        {
            try
            {
                var result = await _EnrollmentService.Update(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _EnrollmentService.Delete(id);
                return Ok("Xóa khóa học thành công");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EnrollmentCreateRequest request)
        {
            try
            {
                var result = await _EnrollmentService.Create(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
