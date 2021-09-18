using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CidadeController : Controller
    {
        private ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet("ListaCidade")]
        public JsonResult ListaCidade()
        {
            try
            {
                var obj = _service.listaCidade();
                return Json(RetornoApi.Sucesso(obj));

            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
            //  return Json(_service.listaCidade());
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id)
        {
            try
            {
                var obj = _service.BuscaPorId(id);
                return Json(RetornoApi.Sucesso(obj));

            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, string Uf, string Cep)
        {
            var obj = new Cidade
            {
                Nome = nome,
                Uf = Uf,
                Cep = Cep,
            };
            _service.Salvar(obj);
            return Json(true);
        }

        [HttpGet("RemoveCidade")]
        public JsonResult RemoveCidade(Guid id)
        {
            _service.RemoverCidade(id);
            return Json(true);
        }

    }
}

