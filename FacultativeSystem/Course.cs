using System;
using System.Collections.Generic;

namespace FacultativeSystem
{
    public interface IArchiveVisiter
    {
        void AddToArchive(Mark mark);
        void RemoveFromArchive(Mark mark);
    }

    public interface ICourseVisiter
    {
        void AddToCourse(Student student);
        void RemoveFromCourses(Student student);
    }

    public class Course : ICourseVisiter
    {
        private List<Student> students = new List<Student>();

        public string CourseName { get; private set; }

        public Course(string courseName)
        {
            CourseName = courseName;
        }

        public void AddToCourse(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (students.Contains(student))
            {
                if (student.Equals(students[0]))
                {
                    throw new Exception("This element is at the course already");
                }
            }

            students.Add(student);
        }

        public void RemoveFromCourses(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            students.Remove(student);
        }
    }

    public class Mark
    {
        public int MarkValue { get; private set; }
        public Student MarkedStudent { get; private set; }
        public Course StudentCourse { get; private set; }

        public Mark(int markValue, Student student, Course course)
        {
            if (markValue > 0 && markValue < 11)
            {
                MarkValue = markValue;
            }
            else
            {
                throw new Exception("Mark's value is out of range");
            }

            if (student != null)
            {
                MarkedStudent = student;
            }
            else
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (course != null)
            {
                StudentCourse = course;
            }
            else
            {
                throw new ArgumentNullException(nameof(course));
            }
        }
    }

    public class Instructor
    {
        private string instructorName;

        public string InstructorName { get { return instructorName; } }

        public Instructor(string instructorName)
        {
            this.instructorName = instructorName;
        }

        public void AddMark(IArchiveVisiter archiveVisiter, Mark mark)
        {
            archiveVisiter.AddToArchive(mark);
        }

        public void RemoveMark(IArchiveVisiter archiveVisiter, Mark mark)
        {
            archiveVisiter.RemoveFromArchive(mark);
        }
    }

    public class Student
    {
        private string studentName;

        public string StudentName { get { return studentName; } }

        public Student(string studentName)
        {
            this.studentName = studentName;
        }

        public void GoToCourse(ICourseVisiter courseVisiter)
        {
            courseVisiter.AddToCourse(this);
        }

        public void GoOutCourse(ICourseVisiter courseVisiter)
        {
            courseVisiter.RemoveFromCourses(this);
        }
    }

    public class Archive : IArchiveVisiter
    {
        private Mark[] marks;
        private int capacityGrower = 10;
        
        public int RealCount { get; private set; }

        public Mark this[int index]
        {
            get
            {
                if ((index >= 0) && (index < RealCount))
                {
                    return marks[index];
                }
                throw new Exception("Elements doesn't exist");
            }
        }

        public Archive()
        {
            RealCount = 0;
            marks = new Mark[0];
        }

        public void AddToArchive(Mark mark)
        {
            if (mark == null)
            {
                throw new ArgumentNullException(nameof(mark));
            }

            if (RealCount == marks.Length)
            {
                Mark[] temp = new Mark[RealCount + capacityGrower];
                marks.CopyTo(temp, 0);
                marks = temp;
            }

            marks[RealCount] = mark;
            RealCount++;
        }

        public void RemoveFromArchive(Mark mark)
        {
            if (mark == null)
            {
                throw new ArgumentNullException(nameof(mark));
            }

            if (RealCount != 0)
            {
                for (int i = 0; i < marks.Length - 1; i++)
                {
                    if (Equals(mark, marks[i]))
                    {
                        for (int j = i; j < marks.Length - 1; j++)
                        {
                            marks[j] = marks[j + 1];
                        }
                        break;
                    }
                }

                RealCount--;
            }
            else
            {
                throw new ArgumentException("There is no elements");
            }
        }
    }
}
