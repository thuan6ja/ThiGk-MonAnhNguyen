using Microsoft.EntityFrameworkCore;
using NhuThuan_K2023_THIGK.Data;
using NhuThuan_K2023_THIGK.Dtos.Course;
using NhuThuan_K2023_THIGK.Entity;

namespace NhuThuan_K2023_THIGK.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CourseCreateRequest request)
        {
            var courseExist = await _context.Course.FirstOrDefaultAsync(c => c.Title == request.Title);
            if (courseExist != null)
            {
                throw new Exception("Thông tin khóa học đã tồn tại");
            }
            var entity = new CourseEntity
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                StartDate = DateTime.Now,
            };
            await _context.Course.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;

        }

        public async Task Delete(Guid Id)
        {
            var courseExits = await _context.Course.FirstOrDefaultAsync(c => c.Id == Id);
            if (courseExits == null)
            {
                throw new Exception("Không tìm thấy khóa học");
            }
            _context.Course.Remove(courseExits);
            await _context.SaveChangesAsync();
        }

        public async Task<CourseEntity> Get(Guid Id)
        {
            var courseExits = await _context.Course.FirstOrDefaultAsync(c=> c.Id == Id);
            if (courseExits == null)
            {
                throw new Exception("Không tìm thấy khóa học");
            }
            return courseExits;
        }

        public async Task<List<CourseEntity>> GetAll()
        {
           var result = await _context.Course.ToListAsync();
            return result;
        }

        public async Task<Guid> Update(CourseUpdateRequest request)
        {
            var courseExist = await _context.Course.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (courseExist == null)
            {
                throw new Exception("Không tìm thấy khóa học");
            }
            courseExist.Description = request.Description;
            courseExist.Title = request.Title;

            _context.Course.Update(courseExist);
            await _context.SaveChangesAsync();
            return request.Id;
        }
    }
}
