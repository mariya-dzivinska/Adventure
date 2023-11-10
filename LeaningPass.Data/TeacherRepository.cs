using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Dapper;
using Microsoft.Data.SqlClient;

namespace LeaningPass.Data
{
    public class TeacherRepository : ITeacherRepository
    {
        private DatabaseContext context;

        public TeacherRepository(DatabaseContext dbContext)
        {
            context = dbContext;
        }
        public Teacher GetTeacherById(int id)
        {
            using (var connection = this.context.CreateConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                Teacher teacher = connection.Query<Teacher>("dbo.uspGetTeacherById",
                    commandType: CommandType.StoredProcedure, param: dynamicParameters).FirstOrDefault();

                return teacher;
            }
        }
    }
}
