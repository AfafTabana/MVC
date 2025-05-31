using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        public string Name { set; get; }

        public string imag { set; get; }

        public string? address { set; get; }

        public int? grade { set; get; }

        [ForeignKey("department")]
        public int DeptId { get; set; }

        public Department? department { get; set; }

        public List<crsResult> _courseresult { get; set; }
    }
}
