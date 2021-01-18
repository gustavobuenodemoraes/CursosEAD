using CursosEAD.Application.Services.Interface;
using CursosEAD.Domain.Entities;
using CursosEAD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CursosEAD.Application.Services
{
    public class CursoService : ICursoService
    {
        readonly IUnitOfWork _uow;
        public CursoService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IEnumerable<Curso> BuscarCursos()
        {
            return _uow.CursoRepository.Get();
        }
        public Curso BuscarCurso(int id)
        {
            return _uow.CursoRepository.GetById(id);
        }
        public Curso AtualizarCurso(Curso curso)
        {
            ValidarCurso(curso);
            _uow.CursoRepository.Update(curso);
            _uow.Commit();
            return curso;
        }
        public bool DeletarCurso(int id)
        {
            var curso = _uow.CursoRepository.GetById(id);
            _uow.CursoRepository.Delete(curso);
            _uow.Commit();
            return _uow.CursoRepository.Get(x => x.Id == curso.Id).Any();
        }
        public Curso InserirCursos(Curso curso)
        {
            ValidarCurso(curso);

            _uow.CursoRepository.Add(curso);
            _uow.Commit();
            return curso;
        }
        private void ValidarCurso(Curso curso)
        {
            var cursos = _uow.CursoRepository.Get(x => x.Id != curso.Id);

            curso.Validar(cursos);

        }
    }
}
