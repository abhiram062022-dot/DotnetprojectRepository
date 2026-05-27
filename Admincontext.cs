using Microsoft.EntityFrameworkCore;
using WebApplication5.Entities;

namespace WebApplication5.Data
{
    public class Admincontext:DbContext
    {
        public Admincontext(DbContextOptions<Admincontext> options) : base(options) { }
         public virtual DbSet<Student> Student { get; set; }
    }
}
