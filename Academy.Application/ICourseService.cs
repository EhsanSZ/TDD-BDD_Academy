using Academy.Domain;
using System.Collections.Generic;

namespace Academy.Application
{
    public interface ICourseService
    {
        int Create(CreateCourse command);
        void Edit(EditCourse command);

        void Delete(int id);
        List<Course> GetAll();
    }
}
