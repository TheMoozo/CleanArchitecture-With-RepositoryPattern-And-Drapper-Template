using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository Task { get; }
    }
}
