using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.DapperInfrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITaskRepository TaskRepo)
        {
            Task = TaskRepo;
        }
        public ITaskRepository Task { get; }
    }
}
