using Microsoft.AspNetCore.Mvc; 
using WebApplication5.IRepository;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult>Add()
        {
            return View(new StudentModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(StudentModel model)
        {
            if(ModelState.IsValid)
            {
                var resultmodel = await _studentRepository.create(model);
                return RedirectToAction("List", model);
            }
            return View(model);
        }
        public async Task<IActionResult> List()
        {
            List<StudentModel>list =await _studentRepository.Getstudentlist(); 

            return View(list);
        }
        public async Task<IActionResult>Edit(long id)
        {
            StudentModel student = await _studentRepository.StudentEditDetails(id);
            return View("Add", student);
        }
        
        public async Task<IActionResult>Delete(long id)
        {
            var result = await _studentRepository.DeleteStudentdetails(id);
            return RedirectToAction("List");
        }
    }
}
