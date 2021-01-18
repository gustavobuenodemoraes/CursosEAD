using CursosEAD.Domain.Entities;
using System.Collections.Generic;

namespace CursosEAD.Application.Services.Interface
{
    public interface ICursoService
    {
        Curso InserirCursos(Curso curso);
        IEnumerable<Curso> BuscarCursos();
        Curso BuscarCurso(int id);
        Curso AtualizarCurso(Curso curso);
        bool DeletarCurso(int id);
    }
}
