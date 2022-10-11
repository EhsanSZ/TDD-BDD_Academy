using Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> Courses = new List<Course>
        {
            new Course(1, "tdd & bdd", true, 600, "Ehsan")
        };

        public void Create(Course course)
        {
            Courses.Add(course);
        }

        public List<Course> GetAll()
        {
            return Courses;
        }

        public Course GetBy(int id)
        {
            return Courses.FirstOrDefault(x=> x.Id == id);
        }

        public void Delete(int id)
        {
            var course = GetBy(id);

            Courses.Remove(course);
        }

        public Course GetBy(string name)
        {
            return Courses.FirstOrDefault(x=> x.Name == name);
        }
    }
}
