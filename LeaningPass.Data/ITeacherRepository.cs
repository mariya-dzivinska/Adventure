using Adventure;

namespace LeaningPass.Data
{
    public interface ITeacherRepository
    {
        Teacher GetTeacherById(int id);
    }
}