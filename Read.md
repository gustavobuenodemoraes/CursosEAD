# Teste da Cast Group

![Swagger Api](/image/localhost_44364_Swagger_index.html.png)

## Desafio
Criar uma API Rest que permita realizar as operações CRUD (criar, recuperar/consultar, editar e
excluir) de Cursos para turmas de formação do Cast group.

### Critérios de Aceite Obrigatórios 
1. Banco de Dados
    Pode-se utilizar qualquer gerenciador de banco de dados, desde que contenha as informações abaixo.
* Curso
    * Descrição do assunto (obrigatório)
    * Data de início (obrigatório)
    * Data de término (obrigatório)
    * Quantidade de alunos por turma (opcional)
    * Categoria (obrigatório)

* Categoria
    * Código
    * Descrição

<b> Observações:</b>
* Apesar de estar estruturada de forma relacional, pode-se utilizar bancos não
relacionais.
* As categorias são: Comportamental, Programação, Qualidade e Processos.

2. Regras de Negócio
* Não será permitida a inclusão de cursos dentro do mesmo período. O sistema
deve identificar tal situação e retornar um código de erro e a mensagem:
<b>"Existe(m) curso(s) planejados(s) dentro do período informado."</b>
* Não será permitida a inclusão de cursos com a data de início menor que a data
atual.
3. API Rest
Deve-se disponibilizar um endpoint com a interface do Swagger para fácil visualização das
operações disponíveis.

## Especificações do projeto
Nesse projeto foi utilizando arquitetura DDD:

* Application
    * Services
        * Interface
* Infrastructure
    * Context
    * Repositories
* Domain
    * Entities
    * Interfaces
        * Repositories
* CrossCutting

Foi Criado dois testes para validar a regra da mensagem

```c#
 public class ValidarRegraData
    {
        ...
        public ValidarRegraData()
        {
            ...
        }

        [Fact]
        public void ValidarExceptionDataIguais()
        {
            ...

            cursoService.InserirCursos(curso);

            var exception = Assert.Throws<Exception>(() => cursoService.InserirCursos(curso2));
            Assert.Equal("Existe(m) curso(s) planejados(s) dentro do período informado.", exception.Message);
        }

        [Fact]
        public void ValidarExceptionDataMenor()
        {
            ...

            var exception = Assert.Throws<Exception>(() => cursoService.InserirCursos(curso));
            Assert.Equal("Não é permitido a inclusão de cursos com a data de início menor que a data atual", exception.Message);
        }
    }
```