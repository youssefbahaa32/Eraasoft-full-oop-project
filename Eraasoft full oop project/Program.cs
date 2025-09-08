using System;
using System.Collections.Generic;

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public Student(int studentId, string name, int age)
    {
        this.StudentId = studentId;
        this.Name = name;
        this.Age = age;
    }

    public bool Enroll(Course course)
    {
        for (int i = 0; i < Courses.Count; i++)
        {
            if (Courses[i].CourseId == course.CourseId)
            {
                return false; 
            }
        }
        Courses.Add(course);
        return true;
    }

    public string PrintDetails()
    {
        return $"The student Name is {this.Name}\nThe student age is {this.Age}\nThe student id is {this.StudentId}";
    }
}

class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public Instructor Instructor { get; set; }

    public Course(string title, int courseId, Instructor instructor)
    {
        this.Title = title;
        this.CourseId = courseId;
        this.Instructor = instructor;
    }

    public string PrintDetails()
    {
        return $"The course title is {this.Title}\nThe course id is {this.CourseId}\nInstructor: {this.Instructor.Name}";
    }
}

class Instructor
{
    public int InstructorId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }

    public Instructor(string name, string specialization, int instructorId)
    {
        this.Name = name;
        this.Specialization = specialization;
        this.InstructorId = instructorId;
    }

    public string PrintDetails()
    {
        return $"The Instructor Name is {this.Name}\nThe Instructor specialization is {this.Specialization}\nThe Instructor id is {this.InstructorId}";
    }
}

class SchoolStudentManager
{
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Course> Courses { get; set; } = new List<Course>();
    public List<Instructor> Instructors { get; set; } = new List<Instructor>();

    public bool AddStudent(Student student)
    {
        Students.Add(student);
        return true;
    }

    public bool AddCourse(Course course)
    {
        Courses.Add(course);
        return true;
    }

    public bool AddInstructor(Instructor instructor)
    {
        Instructors.Add(instructor);
        return true;
    }

    public Student FindStudent(int studentId)
    {
        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].StudentId == studentId)
                return Students[i];
        }
        return null;
    }

    public Course FindCourse(int courseId)
    {
        for (int i = 0; i < Courses.Count; i++)
        {
            if (Courses[i].CourseId == courseId)
                return Courses[i];
        }
        return null;
    }

    public Instructor FindInstructor(int instructorId)
    {
        for (int i = 0; i < Instructors.Count; i++)
        {
            if (Instructors[i].InstructorId == instructorId)
                return Instructors[i];
        }
        return null;
    }

    public bool EnrollStudentInCourse(int studentId, int courseId)
    {
        Student s = FindStudent(studentId);
        Course c = FindCourse(courseId);

        if (s != null && c != null)
        {
            return s.Enroll(c);
        }
        return false;
    }

    public void ShowAllStudents()
    {
        for (int i = 0; i < Students.Count; i++)
        {
            Console.WriteLine(Students[i].PrintDetails());
        }
    }

    public void ShowAllCourses()
    {
        for (int i = 0; i < Courses.Count; i++)
        {
            Console.WriteLine(Courses[i].PrintDetails());
        }
    }

    public void ShowAllInstructors()
    {
        for (int i = 0; i < Instructors.Count; i++)
        {
            Console.WriteLine(Instructors[i].PrintDetails());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SchoolStudentManager manager = new SchoolStudentManager();

        while (true)
        {
            
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Instructor");
            Console.WriteLine("3. Add Course");
            Console.WriteLine("4. Enroll Student in Course");
            Console.WriteLine("5. Show All Students");
            Console.WriteLine("6. Show All Courses");
            Console.WriteLine("7. Show All Instructors");
            Console.WriteLine("8. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter Student Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student Age: ");
                int age = int.Parse(Console.ReadLine());

                Student s = new Student(id, name, age);
                manager.AddStudent(s);
            }
            else if (choice == 2)
            {
                Console.Write("Enter Instructor Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Instructor Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Instructor Specialization: ");
                string spec = Console.ReadLine();

                Instructor ins = new Instructor(name, spec, id);
                manager.AddInstructor(ins);
            }
            else if (choice == 3)
            {
                Console.Write("Enter Course Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Course Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Instructor Id for this Course: ");
                int insId = int.Parse(Console.ReadLine());
                Instructor ins = manager.FindInstructor(insId);

                if (ins != null)
                {
                    Course c = new Course(title, id, ins);
                    manager.AddCourse(c);
                }
                else
                {
                    Console.WriteLine("Instructor not found!");
                }
            }
            else if (choice == 4)
            {
                Console.Write("Enter Student Id: ");
                int sId = int.Parse(Console.ReadLine());
                Console.Write("Enter Course Id: ");
                int cId = int.Parse(Console.ReadLine());

                if (manager.EnrollStudentInCourse(sId, cId))
                    Console.WriteLine("Student enrolled successfully!");
                else
                    Console.WriteLine("Enrollment failed (maybe already enrolled or not found).");
            }
            else if (choice == 5)
            {
                manager.ShowAllStudents();
            }
            else if (choice == 6)
            {
                manager.ShowAllCourses();
            }
            else if (choice == 7)
            {
                manager.ShowAllInstructors();
            }
            else if (choice == 8)
            {
                Console.WriteLine("Thank you ");
                break; 
            }
        }
    }
}
