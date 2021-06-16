using Infrastructure;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Service
{
    public class StudentService
    {
        public List<Student> Get()
        {
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.ToList();
            }
            return students;
        }

        public Student GetById(int id)
        {
            Student student = null;
            using (var context = new SchoolContext())
            {
                student = context.Students.Find(id);
            }
            return student;
        }

        public List<Student> SearchByNameOrLastName(string nameLastName)
        {
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.ToList()
                    .FindAll(item => item.studentLastName.Contains(nameLastName) || item.studentName.Contains(nameLastName));
            }
            return students;
        }

        public void Insert(Student student)
        {
            using (var context = new SchoolContext())
            {
                student.studentCreatedAt = DateTime.Now.ToString();
                student.studentUpdatedAt = DateTime.Now.ToString();
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void Update(Student student, int id)
        {
            using (var context = new SchoolContext())
            {
                var newStudent = context.Students.Find(id);

                newStudent.studentName = student.studentName;
                newStudent.studentAddress = student.studentAddress;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new SchoolContext())
            {
                var student = context.Students.Find(id);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
