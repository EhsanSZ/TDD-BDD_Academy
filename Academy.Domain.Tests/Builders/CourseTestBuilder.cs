﻿namespace Academy.Domain.Tests.Builders
{
    public class CourseTestBuilder
    {
        private string _name = "ASP";
        private const bool IsOnline = true;
        private double _tuition = 600;
        private string _Instructor = "Ehsan";


        public CourseTestBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CourseTestBuilder WithTuition(double tuition)
        {
            _tuition = tuition;
            return this;
        }

        public CourseTestBuilder WithInstructor(string instructor)
        {
            _Instructor = instructor;
            return this;
        }

        public Course Build()
        {
            return new Course(_name, IsOnline, _tuition, _Instructor);
        }
    }
}