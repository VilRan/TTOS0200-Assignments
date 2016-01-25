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
        public int GetAge(DateTime at)
        {
            return (at - dateOfBirth).Days / 365;
        }

        public static DateTime GenerateDateOfBirth(Random random)
        {
            int dobYear = 1980 + random.Next(15);
            int dobMonth = 1 + random.Next(12);
            int dobDay = 1 + random.Next(DateTime.DaysInMonth(dobYear, dobMonth));
            return new DateTime(dobYear, dobMonth, dobDay);
        }

        public static string GenerateName(Random random)
        {
            string name = "";
            int letters = random.Next(2, 8);
            for (int i = 0; i < letters; i++)
                name += (char)('a' + random.Next(25));
            return name;
        }
    }

    public class Student : Person
    {
        private List<CourseParticipation> Courses = new List<CourseParticipation>();
        private string studentID;

        public string StudentID { get { return studentID; } set { studentID = value; } }
        public IEnumerable<CourseParticipation> PassedCourses
        {
            get
            {
                return Courses.Where(course => course.IsPassed);
            }
        }
        public double AverageGrade
        {
            get
            {
                return (double)PassedCourses.Sum(course => course.Grade) / PassedCourses.Count();
            }
        }
        public double WeightedAverageGrade
        {
            get
            {
                return (double)PassedCourses.Sum(course => course.Grade * course.Course.StudyCredits) / StudyCredits;
            }
        }
        public int StudyCredits
        {
            get
            {
                return PassedCourses.Sum(course => course.Course.StudyCredits );
            }
        }

        public Student(DateTime dateOfBirth, string name, string studentID)
            : base(dateOfBirth, name)
        {
            this.studentID = studentID;
        }

        public void Enroll(Course course)
        {
            if ( ! Courses.Exists(c => c.Course == course))
            {
                CourseParticipation participation = new CourseParticipation(course);
                Courses.Add(participation);
            }
        }

        public void GiveGrade(Course course, int grade)
        {
            CourseParticipation participation = Courses.Find(c => c.Course == course);
            participation.Grade = grade;
            if (grade > 0)
                participation.IsPassed = true;
        }

        public void GiveGrade(Course course, bool isPassed)
        {
            CourseParticipation participation = Courses.Find(c => c.Course == course);
            participation.IsPassed = isPassed;
        }
    }

    public class Course
    {
        private string title;
        private int studyCredits;
        private bool isGradeless;

        public string Title { get { return title; } }
        public int StudyCredits { get { return studyCredits; } }
        public bool IsGradeless { get { return isGradeless; } }

        public Course(string title, int studyCredits, bool isGradeless)
        {
            this.title = title;
            this.studyCredits = studyCredits;
            this.isGradeless = isGradeless;
        }
    }

    public class CourseParticipation
    {
        private Course course;
        private int grade;
        private bool isPassed;

        public Course Course { get { return course; } }
        public int Grade { get { return grade; } set { grade = value; } }
        public bool IsGradeless { get { return course.IsGradeless; } }
        public bool IsPassed { get { return isPassed; } set { isPassed = value; } }

        public CourseParticipation(Course course)
        {
            this.course = course;
        }
    }
}
