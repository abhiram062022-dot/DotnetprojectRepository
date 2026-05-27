using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Entities;
using WebApplication5.IRepository;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly Admincontext _context;
        public StudentRepository(Admincontext context)
        {
            _context = context;
        }
        public async Task<string>create(StudentModel model)
        {
            Student student = new Student()
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                Salary = model.Salary,
                PhoneNumber = model.PhoneNumber,
            };
            if(student.Id == 0)
            {
                await _context.Student.AddAsync(student);
            }
            else
            {
                _context.Student.Update(student);
            }
            await _context.SaveChangesAsync();
            return "success";
        }
        public async Task<List<StudentModel>> Getstudentlist()
        {
            var list = await _context.Student.ToListAsync();
            var result = list.Select(a => new StudentModel
            {
                Id=a.Id,
                Name=a.Name,
                Code=a.Code,
                Salary=a.Salary,
                PhoneNumber=a.PhoneNumber,
            }).ToList();
            return result;
        }
        public async Task<StudentModel>StudentEditDetails(long id)
        {
            var result = await _context.Student.Where(a=>a.Id==id).Select(a=> new StudentModel
            {
                Id=a.Id,
                Name=a.Name,
                Code=a.Code,
                Salary=a.Salary,
                PhoneNumber=a.PhoneNumber,
            }).SingleAsync();
            return result;
        }
        public async Task<string> DeleteStudentdetails(long id)
         {
            var result = await _context.Student.Where(a=>a.Id==id).SingleOrDefaultAsync();
            _context.Student.Remove(result);
            await _context.SaveChangesAsync();
            return "success";
        }
    }
}
 