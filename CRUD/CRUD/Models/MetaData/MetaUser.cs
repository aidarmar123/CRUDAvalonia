using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.MetaData
{
    public partial class MetaUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is null")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage ="Role is null")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
