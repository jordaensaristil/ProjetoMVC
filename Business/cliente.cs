using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class cliente
    {
        public class Cliente
        {
            public string Nome { get; set; }
            public List<Cliente> Clientes(string cliente)
            {
                // new Database.cliente().clientes();
                var clientes = new List<Cliente>();
                clientes.Add(new Cliente() { Nome = "Jordaens" });
                return clientes;
            }
        }
    }
}
