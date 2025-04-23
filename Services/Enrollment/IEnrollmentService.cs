using NhuThuan_K2023_THIGK.Dtos.Course;
using NhuThuan_K2023_THIGK.Dtos.Enrollment;
using NhuThuan_K2023_THIGK.Entity;

namespace NhuThuan_K2023_THIGK.Services.Enrollment
{
    public interface IEnrollmentService
    {
        Task<List<EnrollmentEntity>> GetbyCourseId(Guid courseId);
        Task<Guid> Create(EnrollmentCreateRequest request);
        Task<EnrollmentEntity> Update(EnrollmentConfirmedRequest request);
        Task Delete(Guid Id);
    }
}
