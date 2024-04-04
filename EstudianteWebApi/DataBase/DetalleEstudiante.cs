using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DetalleEstudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetalleId { get; set; }
        public int MateriaId { get; set; }
        public int EstudianteId { get; set; }
        [ForeignKey("MateriaId")]
        public virtual Materia? Materia { get; set; }
        [ForeignKey("EstudianteId")]
        public virtual Estudiante? Estudiante { get; set; }
        
    }
}
