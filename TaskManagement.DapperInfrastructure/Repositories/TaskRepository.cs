using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.DapperInfrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public IConfiguration Configuration { get; }
        public TaskRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> Add(Core.Entities.Task entity)
        {
            entity.CreatedDate = DateTime.Now;
            //Order should be same as columns
            var sql = "Insert into Task(TaskName,TaskDescription,TaskStatus,CreatedDate,ModifiedDate) values (@TaskName,@TaskDescription,@TaskStatus,@CreatedDate,@ModifiedDate)";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedrows = await connection.ExecuteAsync(sql, entity);
                return affectedrows;
            }
        }

        public async Task<int> Delete(int Id)
        {
            var sql = "Delete from Task where TaskId=@TaskId";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedrows = await connection.ExecuteAsync(sql, new { TaskId = Id });
                return affectedrows;
            }
        }

        public async Task<Core.Entities.Task> Get(int Id)
        {
            var sql = "Select * from Task where TaskId=@TaskId";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Core.Entities.Task>(sql, new { TaskId = Id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Core.Entities.Task>> GetAll()
        {
            var sql = "Select * from Task";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Core.Entities.Task>(sql);
                return result;
            }
        }

        public async Task<int> Update(Core.Entities.Task entity)
        {
            entity.ModifiedDate = DateTime.Now;
            //Order should be same as columns
            var sql = "Update Task Set TaskName = @TaskName, TaskDescription = @TaskDescription, TaskStatus = @TaskStatus, ModifiedDate = @ModifiedDate Where TaskId=@TaskId";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedrows = await connection.ExecuteAsync(sql, entity);
                return affectedrows;
            }
        }
    }
}
