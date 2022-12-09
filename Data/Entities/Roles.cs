using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
