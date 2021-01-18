using CursosEAD.Domain.Entities;
using CursosEAD.Domain.Interfaces.Repositories;
using CursosEAD.Infrastructure.Context;
using System;

namespace CursosEAD.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public AppDbContext _context;
        private Repository<Curso> _cursoaRepository;
        private Repository<Categoria> _categoriaRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public UnitOfWork()
        {
            _context = new AppDbContext();
        }
        public IRepository<Curso> CursoRepository
        {
            get
            {
                return _cursoaRepository = _cursoaRepository ?? new Repository<Curso>(_context);
            }
        }
        public IRepository<Categoria> CategoriaRepository
        {
            get
            {
                return _categoriaRepository = _categoriaRepository ?? new Repository<Categoria>(_context);
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
