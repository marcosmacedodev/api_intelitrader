using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Model
{
    public class Usuario
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Campo de primeiro nome é obrigatório", AllowEmptyStrings = false), StringLength(16)]
        public string FirstName { get; set; }
        [StringLength(16)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Campo de idade é obrigatório")]
        public int? Age { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
    }
}
