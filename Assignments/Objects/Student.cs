using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Person
    {
        private readonly DateTime dateOfBirth;
        private string name;

        public DateTime DateOfBirth { get { return dateOfBirth; } }
        public string Name { get { return name; } set { name = value; } }

        public Person(DateTime dateOfBirth, string name)
        {
            this.dateOfBirth = dateOfBirth;
            this.name = name;
        }
        public int GetAge(DateTime date)
        {
            return (date - dateOfBirth).Days / 365;
        }
    }

    public class Student : Person
    {
        private List<CourseParticipation> Courses = new List<CourseParticipation>();
        private string id;

        public string ID { get { return id; } set { id = value; } }
        public double AverageGrade { get { return (double)Courses.Sum(c => c.Grade) / Courses.Count; } }
        public int StudyCredits { get { return Courses.Sum(course => course.IsPassed ? course.Course.StudyCredits : 0); } }

        public Student(DateTime dateOfBirth, string name, string id)
            : base(dateOfBirth, name)
        {
            this.id = id;
        }

    }

    public class Course
    {
        private int studyCredits;
        
        public int StudyCredits { get { return studyCredits; } }
    }

    public class CourseParticipation
    {
        private Course course;
        private int grade;

        public int Grade { get { return grade; } }
        public Course Course { get { return course; } }
        public bool IsPassed { get { return Grade > 0; } }
    }
}
