using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CasaDoCodigo
{
    //TAREFA 05: INJETAR UserManager PARA OBTER clienteId
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly UserManager<AppIdentityContext> userManager;

        public IConfiguration Configuration { get; }

        public HttpHelper(IHttpContextAccessor contextAccessor, IConfiguration configuration, UserManager<AppIdentityContext> userManager)
        {
            this.contextAccessor = contextAccessor;
            Configuration = configuration;
            this.userManager = userManager;
        }

        public int? GetPedidoId()
        {
            
            return contextAccessor.HttpContext.Session.GetInt32($"pedidoId_{GetClienteId()}");
        }

        private string GetClienteId()
        {
            var clamsPrincipal = contextAccessor.HttpContext.User;
            var clienteId = userManager.GetUserId(clamsPrincipal);
            return clienteId ;

        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32($"pedidoId_{GetClienteId()}", pedidoId);
        }

        public void ResetPedidoId()
        {
            contextAccessor.HttpContext.Session.Remove($"pedidoId_{GetClienteId()}");
        }
    }
}
