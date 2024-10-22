﻿using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        string filePath = string.Empty;

        public StudentService(FilePathHelper helper)
        {
            this.filePath = helper.GetFilePath();
        }

        static List<Student> students;

        static StudentService()
        {
            // filePath

            students = Enumerable.Range(1, 5).Select(index => new Student
            {
                Id = index + 1,
                Name = $"Student - {index + 1}"
            })
            .ToList();
        }

        public List<Student> GetStudents(FilePathHelper helper)
        {
            filePath = helper.GetFilePath();

            return students;
        }

        public List<Student> GetStudents()
        {
            return GetStudents(new FilePathHelper());
        }
    }
}
