using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.DAL;
using Projeto.Entidades;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{

    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Cadastrar(ClienteCadastroViewModel model)
        {
            try
            {
                Cliente c = new Cliente();
                c.Nome = model.Nome;
                c.Email = model.Email;
                c.DataCadastro = DateTime.Now;

                ClienteRepositorio rep = new ClienteRepositorio();
                rep.Insert(c);


                return Request.CreateResponse(HttpStatusCode.OK, "Cliente cadastrado com sucesso");


            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Atualizar(ClienteEdicaoViewModel model)
        {

            try
            {
                Cliente c = new Cliente();
                c.IdCliente = model.IdCliente;
                c.Nome = model.Nome;
                c.Email = model.Email;

                ClienteRepositorio rep = new ClienteRepositorio();
                rep.Update(c);

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente atualizado com sucesso");

            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Excluir (int id)
        {
            try
            {

                ClienteRepositorio rep = new ClienteRepositorio();
                rep.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente excluido com sucesso");
                

            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet]
        [Route("consultar")]
        public HttpResponseMessage Consultar()
        {

            try
            {

                List<ClienteConsultaViewModel> lista = new List<ClienteConsultaViewModel>();

                ClienteRepositorio rep = new ClienteRepositorio();

                foreach (Cliente c in rep.FindAll())
                {
                    ClienteConsultaViewModel model = new ClienteConsultaViewModel();

                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataCadastro = c.DataCadastro;

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);

            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
            
        }


        [HttpGet]
        [Route("obterporid")]
        public HttpResponseMessage ObterPorId (int id)
        {

            try
            {

                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = rep.FindById(id);

                if(c != null)
                {
                    ClienteConsultaViewModel model = new ClienteConsultaViewModel();

                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataCadastro = c.DataCadastro;


                    return Request.CreateResponse(HttpStatusCode.OK, model);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Cliente não foi encontrado");
                }





            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message); ;
            }





        }




    }
}
