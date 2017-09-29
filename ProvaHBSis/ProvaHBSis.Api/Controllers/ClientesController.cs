using ProvaHBSis.Application.Interface;
using ProvaHBSis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProvaHBSis.Api.Controllers
{
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        /// <summary>
        /// Listar todos os clientes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = "User")]
        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                return _clienteApp.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception("erro consultar :" + e.Message);
            }
        }

        /// <summary>
        /// Buscar cliente por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = "User")]
        public Cliente Get(int id)
        {
            try
            {
                return _clienteApp.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception("erro consultar :" + e.Message);
            }
        }

        /// <summary>
        /// Salvar cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "User")]
        public HttpResponseMessage Insert(Cliente entity)
        {
            try
            {
                _clienteApp.Add(entity); 
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }          
        }

        /// <summary>
        /// Atualizar cliente
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        //[Authorize(Roles = "User")]
        public HttpResponseMessage Update(Cliente entity)
        {
            try
            {
                _clienteApp.Update(entity);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }          
        }

        /// <summary>
        /// Excluir cliente
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        //[Authorize(Roles = "User")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _clienteApp.DeleteCliente(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }         
        }

    }
}