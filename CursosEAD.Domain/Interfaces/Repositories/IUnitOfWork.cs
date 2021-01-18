using CursosEAD.Domain.Entities;

namespace CursosEAD.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Curso> CursoRepository { get; }
        IRepository<Categoria> CategoriaRepository { get; }
        void Commit();
    }
}
