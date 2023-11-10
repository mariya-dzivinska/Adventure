          IF (OBJECT_ID('dbo.FK_Lesson_Homework_HomeworkId', 'F') IS NOT NULL)
                    BEGIN
                        ALTER TABLE dbo.TableName DROP CONSTRAINT FK_ConstraintName
                    END
                    -----
                    IF (OBJECT_ID('dbo.UQ__Homework__FDE46A733FB416F4', 'C') IS NOT NULL)
                    BEGIN
                        ALTER TABLE dbo.Homework DROP CONSTRAINT UQ__Homework__FDE46A733FB416F4
                    END

                    ----
                    drop table if exists Teacher;

                    drop table if exists Homework;

                    drop table if exists Lesson;

                    drop table if exists Course;