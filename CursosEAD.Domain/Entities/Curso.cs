using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CursosEAD.Domain.Entities
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DescricaoAssunto { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
        [Required]
        public int QuantidadeAlunos { get; set; }
        public Categoria Categoria { get; set; }

        private void PeriodoValido(IEnumerable<Curso> cursos)
        {
            var cursoExistente = cursos.Any(x => x.DataInicio == DataInicio
                                               || x.DataTermino == DataTermino);

            if (cursoExistente)
                throw new Exception("Existe(m) curso(s) planejados(s) dentro do período informado.");
        }

        private void ValidarDataInicio()
        {
            if (DataInicio < DateTime.Today)
                throw new Exception("Não é permitido a inclusão de cursos com a data de início menor que a data atual");
        }

        public void Validar(IEnumerable<Curso> cursos)
        {
            PeriodoValido(cursos);
            ValidarDataInicio();
        }
    }
}
