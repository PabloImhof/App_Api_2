using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepositoryBase<Pessoa> _repository { get; set; }
        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }
        public Pessoa BuscaPorId(Guid id)
        {
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Pessoa> listaPessoas(string nome, int pesoMaiorQue, int pesoMenorQue)
        {
            nome = nome ?? "";
            return _repository.Query(x =>
            x.Nome.ToUpper().Contains(nome.ToUpper()) &&
            (pesoMaiorQue == 0 || x.Peso >= pesoMaiorQue) &&
            (pesoMenorQue == 0 || x.Peso <= pesoMenorQue)
            )

            //return _repository.Query(x => 1 == 1)
              .Select(p => new Pessoa
              {
                  Id = p.Id,
                  Nome = p.Nome,
                  Peso = p.Peso,
                  Cidade = new Cidade
                  {
                      Nome = p.Cidade.Nome,
                      Cep = p.Cidade.Cep,
                      Uf = p.Cidade.Uf
                  }
              })
              .OrderByDescending(x => x.Nome).ThenBy(x => x.DataNascimento)
              .ToList();
        }

        public void Salvar(Pessoa obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o nome");
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }

        public Pessoa BuscaPessoa(string nome)
        {

            var obj = _repository.Query(x => x.Nome.ToUpper().Contains(nome.ToUpper())).FirstOrDefault();
            return obj;
        }

        public void RemoverPessoa(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o id a remover");
            }
            _repository.Delete(id);
            _repository.SaveChanges();
        }



    }
}
