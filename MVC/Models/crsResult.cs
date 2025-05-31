using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class crsResult
    {
        public int Id { get; set; }

        public int degree { set; get; }

        [ForeignKey("course")]
        public int CrsId { get; set; }

        public virtual Course? course { get; set; }

        [ForeignKey("trainee")]
        public int traineeId { get; set; }

        public virtual Trainee? trainee { get; set; }
    }
}

