using Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TruckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaminhaoController
    {
        private readonly DataDBContext context;
        public CaminhaoController(DataDBContext context)
        { 
            this.context = context;
        }

        [HttpGet("{id}")]
        public Response Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var item = this.context.Caminhoes.FirstOrDefault(c => c.Id == id, new Caminhao());

                    if (item == null)
                    {
                        return new Response { status = HttpStatusCode.NotFound.ToString(), message = "Caminhão não encontrado.", data = item };
                    }

                    return new Response { status = HttpStatusCode.OK.ToString(), message = "Caminhão encontrado.", data = item };
                }

                return new Response { status = HttpStatusCode.OK.ToString(), message = "Busca realizada com sucesso.", data = this.context.Caminhoes.ToList().OrderBy(c => c.Placa) };
            }
            catch (Exception ex)
            {
                return new Response { status = HttpStatusCode.InternalServerError.ToString(), message = $"Ocorreu um erro inesperado. Mensagem: {ex.Message}", data = null };
            }
        }
        [HttpGet]
        public Response Get()
        {
            try
            {
               /* if (id > 0)
                {
                    var item = this.context.Caminhoes.FirstOrDefault(c => c.Id == id, new Caminhao());

                    if (item == null)
                    {
                        return new Response { status = HttpStatusCode.NotFound.ToString(), message = "Caminhão não encontrado.", data = item };
                    }

                    return new Response { status = HttpStatusCode.OK.ToString(), message = "Caminhão encontrado.", data = item };
                }*/

                return new Response { status = HttpStatusCode.OK.ToString(), message = "Busca realizada com sucesso.", data = this.context.Caminhoes.ToList().OrderBy(c => c.Placa) };
            }
            catch (Exception ex)
            {
                return new Response { status = HttpStatusCode.InternalServerError.ToString(), message = $"Ocorreu um erro inesperado. Mensagem: {ex.Message}", data = null };
            }
        }

        [HttpPost(Name = "PostCaminhao")]
        public Response Post(Caminhao caminhao)
        {
            try
            {
                if (caminhao.Id <= 0)
                {
                    this.context.Caminhoes.Add(caminhao);
                }
                else
                {
                    this.context.Caminhoes.Update(caminhao);
                }

                this.context.SaveChanges();

                return new Response { status = HttpStatusCode.OK.ToString(), message = "Caminhão salvo com sucesso.", data = this.context.Caminhoes.ToList() };
            }
            catch (Exception ex)
            {
                return new Response { status = HttpStatusCode.InternalServerError.ToString(), message = $"Ocorreu um erro inesperado. Mensagem: {ex.Message}", data = null };
            }
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var item = this.context.Caminhoes.ToList().Where(c => c.Id == id).FirstOrDefault(new Caminhao());

                    if (item == null)
                    {
                        return new Response { status = HttpStatusCode.NotFound.ToString(), message = "Caminhão não encontrado.", data = null };
                    }

                    this.context.Remove(item);
                    this.context.SaveChanges();

                    return new Response { status = HttpStatusCode.OK.ToString(), message = "Caminhão deletado com sucesso.", data = null };
                }

                return new Response { status = HttpStatusCode.NotFound.ToString(), message = "Caminhão não encontrado.", data = null };
            }
            catch (Exception ex)
            {
                return new Response { status = HttpStatusCode.InternalServerError.ToString(), message = $"Ocorreu um erro inesperado. Mensagem: {ex.Message}", data = null };
            }
        }
    }
}
