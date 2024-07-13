using SoreBiblioteca.Domain.Entities;
using System.Collections.Generic;

namespace SoreBiblioteca.Web.ViewModels
{
    public class ClienteViewModel
    {
        public IEnumerable<Cliente> Clientes { get; set; }
        public Cliente NuevoCliente { get; set; }
    }
}
