﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Modelo;

namespace Api.Controllers
{
    
    public class ClienteController : ApiController
    {
        
        [HttpGet]
        [Route("Cliente")]
        public IHttpActionResult GetCliente()
        {
            string cadena = ConfigurationManager.ConnectionStrings["DbClientes"].ConnectionString;
            Service service = new Service(cadena);
            return Ok(service.GetClientes());
        }

        [HttpPut]
        [Route("Cliente/Put")]
        public IHttpActionResult Put([FromBody] Cliente _cliente)
        {
            string cadena = ConfigurationManager.ConnectionStrings["DbClientes"].ConnectionString;
            Service service = new Service(cadena);
            return Ok(service.PutClientes(_cliente));
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
