using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCMS.Models.POCOs
{
    [Table("Surveys")]
    public class SurveyModel
    {
        public long Id { get; set; }
        public int userId { get; set; }
        public string Respuesta_1 { get; set; }
        public string Respuesta_2 { get; set; }
        public string Respuesta_3 { get; set; }
        public string Respuesta_4 { get; set; }
        public string Respuesta_5 { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreUsuario { get; set; }
    }
}
