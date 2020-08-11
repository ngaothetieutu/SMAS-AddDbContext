using Microsoft.EntityFrameworkCore;
using SMAS.MSStudent.API.Application.DTOs;
using SMAS.MSStudent.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMAS.MSStudent.API.Application.DomainEventHandlers
{
    public class StudentService
    {
        private readonly ModelContext _context;

        public StudentService(ModelContext context)
        {
            this._context = context;
        }

        public virtual Student GetStudentById(int id)
        {
            return _context.Student.Where(c => c.Id == id).FirstOrDefault();
        }
        public IList<Student> GetAllStudent()
        {
            return _context.Student.ToList();
        }

        public string  DeleteStudentById(int id)
        {
            var item = _context.Student.Where(c => c.Id == id).FirstOrDefault();
             _context.Remove(item);
            _context.SaveChanges();
            string mss = "Delete success";
            return mss;
        }
        public void UpdateStudent(Student entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Update(entity);

        }
        public void InsertStudent(Student entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Student.Add(entity);
            _context.SaveChanges();
        }

        public void InsertTeacher(Teacher entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Teacher.Add(entity);
            _context.SaveChanges();
        }

        public IList<Teacher> GetAllTeachers()
        {
            return _context.Teacher.ToList();
        }
        public virtual Teacher GetTeacherById(int id)
        {
            return _context.Teacher.Where(c => c.ID == id).FirstOrDefault();
        }
    }
}
