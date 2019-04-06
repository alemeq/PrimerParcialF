using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIparcial1.Models
{
    public enum ListaType
    {
        Conocido,
        CompañeroDeEstudio,
        ColegaDeTrabajo,
        Amigo,
        AmigoDeInfancia,
        Pariente
    }
    public class AleMenachoFriends
    {
        [Key]
        public int FriendId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Nickname { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        public ListaType Type { get; set; }
    }
}