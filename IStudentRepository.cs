using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.IRepository
{
    public interface IStudentRepository
    {
      Task<string> create(StudentModel model);
      Task<List<StudentModel>>Getstudentlist();
      Task<StudentModel> StudentEditDetails( long id);
      Task<string> DeleteStudentdetails(long id); 
       
    }
}
