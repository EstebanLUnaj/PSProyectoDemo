using Aplication.Interfaces;
using Domain.Entities;
using Infraestructura.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Querys
{
    public class StudentQuery : IStudentQuery
    {
        private readonly AppDbContext _context;
        public StudentQuery(AppDbContext context)
        {
            _context = context;
        }
        public List<Student> GetListStudent()
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(int studentId)
        {
            var students = _context.Student.Include(s => s.Address).FirstOrDefault(s => s.StudentId == studentId);

            return students;
        }
    }
}
