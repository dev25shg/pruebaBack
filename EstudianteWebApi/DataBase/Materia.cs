using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Materia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MateriaId { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
        [ForeignKey("ProfesorId")]
        public virtual Profesor Profesor { get; set; }
    }
}
