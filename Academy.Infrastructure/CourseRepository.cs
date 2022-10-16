using Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AcademyContext _context;

        public CourseRepository(AcademyContext context)
        {
            _context = context;
        }

        public List<Course> GetAll()
        {
           return _context.Courses.ToList();
        }

        public int Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Course GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public Course GetBy(string name)
        {
            throw new NotImplementedException();
        }
    }
}
