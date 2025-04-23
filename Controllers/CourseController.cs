using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhuThuan_K2023_THIGK.Dtos.Course;
using NhuThuan_K2023_THIGK.Services.Course;

namespace NhuThuan_K2023_THIGK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;

        }
        // Lấy danh sách khóa học
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseService.GetAll();
            return Ok(result);
        }

        // Lấy chi tiết một khóa học theo id
        [HttpGet("get/{id}")]

        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _courseService.Get(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("crete")]

        public async Task<IActionResult> Create(CourseCreateRequest request)
        {
            try
            {
                var result = await _courseService.Create(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]

        public async Task<IActionResult> Update(CourseUpdateRequest request)
        {
            try
            {
                var result = await _courseService.Update(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete /{id}")]

        public async Task<IActionResult> Delete(Guid id) 
        {
            try
            {
                 await _courseService.Delete(id);
                return Ok("Xóa khóa học thành công");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
