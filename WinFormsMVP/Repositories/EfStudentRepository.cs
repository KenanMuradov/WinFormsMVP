using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMVP.Models;
using WinFormsMVP.Repositories.Contexts;

namespace WinFormsMVP.Repositories;

public class EfStudentRepository : IStudentRepository
{
    private readonly MyDbContext _context;

    public EfStudentRepository() => _context = new();

    public void Add(Student entity)
    {
        _context.Students?.Add(entity);
        _context.SaveChanges();
    }

    public Student? Get(Func<Student, bool> predicate) => _context.Students?.FirstOrDefault(predicate);

    public Student? GetById(Guid Id)=>_context.Students?.Find(Id);

    public List<Student>? GetList(Func<Student, bool>? predicate = null)
        => (predicate is null) switch
        {
            true => _context.Students?.ToList(),
            false =>_context.Students?.Where(predicate).ToList()
        };

    public void Remove(Student entity)
    {
        _context.Students?.Remove(entity);
        _context.SaveChanges();
    }

    public void Update(Student entity)
    {
        _context.Students?.Update(entity);
        _context.SaveChanges();
    }
}
