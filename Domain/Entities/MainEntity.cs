using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class MainEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
