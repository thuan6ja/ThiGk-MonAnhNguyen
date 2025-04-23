using NhuThuan_K2023_THIGK.Dtos.Course;
using NhuThuan_K2023_THIGK.Entity;

namespace NhuThuan_K2023_THIGK.Services.Course
{
    public interface ICourseService
    {   // lấy danh sách Khóa học
        Task<List<CourseEntity>> GetAll();
        // Lấy chi tiết mọt khóa học
        Task<CourseEntity> Get(Guid Id);
            // Tạo một khóa học mới
        Task<Guid> Create(CourseCreateRequest request);
            // Cập nhật thông tin khóa học
        Task<Guid> Update(CourseUpdateRequest request);
            // xóa khóa học
        Task Delete(Guid Id);
    }
}
