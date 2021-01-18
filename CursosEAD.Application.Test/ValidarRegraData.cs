using CursosEAD.Application.Services;
using CursosEAD.Application.Services.Interface;
using CursosEAD.Domain.Entities;
using CursosEAD.Domain.Interfaces.Repositories;
using CursosEAD.Infrastructure.Context;
using CursosEAD.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace CursosEAD.Application.Test
{
    public class ValidarRegraData
    {
        readonly ICursoService cursoService;
        readonly IUnitOfWork uow;
        public ValidarRegraData()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseInMemoryDatabase("DbCursos")
                            .Options;
            var contexto = new AppDbContext(options);

            uow = new UnitOfWork(contexto);
            cursoService = new CursoService(uow);

        }

        [Fact]
        public void ValidarExceptionDataIguais()
        {
            var curso = new Curso
            {
                DescricaoAssunto = "Teste",
                DataInicio = DateTime.Today.AddDays(1),
                DataTermino = DateTime.Today.AddDays(5),
                QuantidadeAlunos = 15
            };

            var curso2 = new Curso
            {
                DescricaoAssunto = "Teste2",
                DataInicio = DateTime.Today.AddDays(1),
                DataTermino = DateTime.Today.AddDays(5),
                QuantidadeAlunos = 15
            };

            cursoService.InserirCursos(curso);

            var exception = Assert.Throws<Exception>(() => cursoService.InserirCursos(curso2));
            Assert.Equal("Existe(m) curso(s) planejados(s) dentro do período informado.", exception.Message);
        }

        [Fact]
        public void ValidarExceptionDataMenor()
        {
            var curso = new Curso
            {
                DescricaoAssunto = "Teste",
                DataInicio = DateTime.Today.AddDays(-1),
                DataTermino = DateTime.Today.AddDays(5),
                QuantidadeAlunos = 15
            };

            var exception = Assert.Throws<Exception>(() => cursoService.InserirCursos(curso));
            Assert.Equal("Não é permitido a inclusão de cursos com a data de início menor que a data atual", exception.Message);
        }
    }
}
