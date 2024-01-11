using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Migrations
{
    [Migration(202311090001)]
    public class InitialTables_202311090001:Migration
    {
        public override void Up()
        {

            var sql =
                @"
                            CREATE TABLE Teacher
                (
	                TeacherId int not null IDENTITY(1,1),
	                FirstName nvarchar(30) not null,
	                LastName nvarchar(30) not null,
	                DateOfBirth datetime null,
	                Skills nvarchar(30),
	                IsActive bit,
	                PRIMARY KEY (TeacherId)
                ); 


                ---------------
                --------------- Drop table COURSE

                CREATE TABLE Course
                (
	                CourseId int not null IDENTITY(1,1),
	                Name nvarchar(30) not null,
	                CreatedDate datetime not null,
	                Skills nvarchar(30),
	                FinishedDate datetime null,
	                IsActive bit,
	                PRIMARY KEY(CourseId)
                )

                ---------------
                --------------- drop table Lesson
                CREATE TABLE Lesson
                (
	                LessonId int not null IDENTITY(1,1),
	                Number int not null,
	                Title nvarchar(30) null,
	                Date datetime not null,
	                Status bit,
	                PRIMARY KEY(LessonId)
                );

                ---------------
                --------------- drop table Homework

                CREATE TABLE Homework
                (
	                HomeworkId int not null IDENTITY(1,1),
	                Title nvarchar(30) not null,
	                CreatedDate datetime not null,
	                Description nvarchar(300),
	                FinishedDate datetime null,
	                UpdatedDate datetime null,
	                PRIMARY KEY (HomeworkId)
                );
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            var filename = "20231109_DropTables";
            var path = Path.Combine(Environment.CurrentDirectory, @"Scripts\", filename);
            Execute.Script(path);
        }
    }
}
