using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Z.Dapper.Plus;

namespace Adventure
{
    internal class Helper
    {
        private string connectionString =
            @"Data Source=BYOD-LT-MDZI\SQLEXPRESS;Initial Catalog=LearningPass;Integrated Security=True;";

        public int InsertLesson()
        {
            var insertLessonCommand = "INSERT INTO Lesson (Number, Title, Date, Status, CourseId)" +
                                      " VALUES (@Number, @Title, @Date, @Status, @CourseId);";
            object[] parameters =
            {
                new
                {
                    Number = 15, Title = "ORM.Dapper", Date = DateTime.Now.Date,
                    Status = Status.InProgress, CourseId = 1
                }
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(insertLessonCommand, parameters);
                return affectedRows;
            }
        }


        //------Dapper--------


        //var select = "select* from Course";




        public List<TeacherCoursesDto> GetTeacherWithCourses()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var teacherCoursesDtoList = connection.Query<TeacherCoursesDto, Course, TeacherCoursesDto>(
                        "GetTeacherCourses",

                        commandType: CommandType.StoredProcedure,
                        map: CreateTeacherCoursesDto,
                        splitOn: "CourseId")
                    .ToList();

                return teacherCoursesDtoList;
            }
        }

        public TeacherCoursesDto CreateTeacherCoursesDto(TeacherCoursesDto dto, Course c)
        {
            dto.Course = c;
            return dto;
        }

        public void CreateTeachers()
        {
            //var result = connection.Query<TeacherDto>("uspGetStudentsByTeacherId", parameters, commandType:CommandType.StoredProcedure);
            //var result = connection.Execute(select, parameters);

            using (var connection = new SqlConnection(connectionString))
            {
                bool isActive = false;
                for (int i = 1; i < 2000; i++)
                {
                    DynamicParameters dynParameters = new DynamicParameters();
                    dynParameters.Add("FirstName", $"FirstName{i}");
                    dynParameters.Add("LastName", $"LastName{i}");
                    dynParameters.Add("Skills", "C#");
                    dynParameters.Add("DateOfBirth", new DateTime(1970, 5, 10));
                    dynParameters.Add("IsActive", isActive);
                    isActive = !isActive;

                    var insertRes =
                        connection.Query("uspCreateTeacher", dynParameters, commandType: CommandType.StoredProcedure);

                }
            }
        }

        public void BulkInsertTeachers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var teachers = new List<Teacher>()
                {
                    new()
                    {
                        TeacherId = 8000, FirstName = "Olga", LastName = "Kusto", Skills = "C#",
                        DateOfBirth = DateTime.Now.AddYears(-45).Date
                    },
                    new()
                    {
                        TeacherId = 8001, FirstName = "Oleksiy", LastName = "Tykhop", Skills = "Java",
                        DateOfBirth = DateTime.Now.AddYears(-36).Date
                    },
                    new()
                    {
                        TeacherId = 8002, FirstName = "Andrew", LastName = "Mikdso", Skills = "JS",
                        DateOfBirth = DateTime.Now.AddYears(-60).Date
                    },
                };

                var a = connection.BulkInsert(teachers);
            }
        }

        public List<Teacher> GetTeacherStudents()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var teacherStudents = connection.Query<Teacher, StudentDto, Teacher>("GetTeacherStudents",

                    commandType: CommandType.StoredProcedure,
                    map: (teacher, student) =>
                    {
                        teacher.Students.Add(student);
                        return teacher;
                    },
                    splitOn: "Id");


                var result = teacherStudents.GroupBy(t => t.TeacherId).Select(g =>
                    {
                        var teacher = g.First();
                        teacher.Students = g.Select(p => p.Students.Single()).ToList();
                        return teacher;
                    })
                    .ToList();

                return result;
            }
        }

    }
}
