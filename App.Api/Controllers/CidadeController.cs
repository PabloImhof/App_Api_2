﻿using App.Domain.Entities;
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
            return Json(_service.listaCidade());
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id)
        {
            return Json(_service.BuscaPorId(id));
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
    }
}
    