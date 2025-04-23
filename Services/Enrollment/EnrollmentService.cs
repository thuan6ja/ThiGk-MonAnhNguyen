using Microsoft.EntityFrameworkCore;
using NhuThuan_K2023_THIGK.Data;
using NhuThuan_K2023_THIGK.Dtos.Enrollment;
using NhuThuan_K2023_THIGK.Entity;

namespace NhuThuan_K2023_THIGK.Services.Enrollment
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext _context;
        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(EnrollmentCreateRequest request)
        {
            var enroll = new EnrollmentEntity
            {
                Id = Guid.NewGuid(),
                CourseId = request.CourseId,
                StudentName = request.StudentName,
                EnrollCode = Guid.NewGuid().ToString().Substring(0, 6),
                Confirmed = false
            };
            _context.Enrollment.Add(enroll);
            await _context.SaveChangesAsync();
            return enroll.Id;
        }

        public async Task Delete(Guid id)
        {
            var enroll = await _context.Enrollment.FirstOrDefaultAsync(e => e.Id == id);
            if (enroll == null)
            {
                throw new Exception("Không tồn tại ghi danh");
            }
            _context.Enrollment.Remove(enroll);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EnrollmentEntity>> GetbyCourseId(Guid courseId)
        {
            var enrollExits = await _context.Enrollment.Where(e => e.CourseId == courseId).ToListAsync();
            return enrollExits;
        }

        public async Task<EnrollmentEntity> Update(EnrollmentConfirmedRequest request)
        {
            var enroll = await _context.Enrollment.FirstOrDefaultAsync(e => e.Id == request.Id);
            if (enroll == null)
            {
                throw new Exception("Không tồn tại ghi danh");
            }
            enroll.Confirmed = true;
            await _context.SaveChangesAsync();
            return enroll;
        }
    }
}
