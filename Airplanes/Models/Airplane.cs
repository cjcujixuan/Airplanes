using System.ComponentModel.DataAnnotations;
namespace Airplanes.Models
{
    public class Airplane
    {
        [Key] public int Pid { get; set; }
        [Required] public String Pname { get; set; }
        [Required] public int Pseats { get; set; }
        [Required] public int Pspeed { get; set; }
        public int Pweight { get; set; }
    }
}