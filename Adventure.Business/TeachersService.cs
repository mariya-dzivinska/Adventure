using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaningPass.Data;

namespace Adventure.Business
{
    public class TeachersService : ITeachersService
    {
        public readonly ITeacherRepository teacherRepository;

        public TeachersService(ITeacherRepository _teacherRepository)
        {
            teacherRepository = _teacherRepository;
        }

        public TeacherDto GetTeacherDtos(int id)
        {
            var teacher = teacherRepository.GetTeacherById(id);

            var teacherDto = new TeacherDto()
            {
                TeacherId = teacher.TeacherId,
                DateOfBirth = teacher.DateOfBirth,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
            };
            return teacherDto;
        }
    }

    public interface ITeachersService
    {
        TeacherDto GetTeacherDtos(int id);
    }
}
