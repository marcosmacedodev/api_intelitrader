using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Model
{
    public class Usuario
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
