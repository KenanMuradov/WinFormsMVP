using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMVP.Models;

namespace WinFormsMVP.Repositories;

public interface IStudentRepository : IRepository<Student>
{
    Student? GetById(Guid Id);
}
