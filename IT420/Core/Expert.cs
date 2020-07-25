using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Core
{
    public class Expert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string lastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string specialty { get; set; }
        [Required]
        [Column(TypeName ="text")]
        public string bio { get; set; }
        public byte[] image { get; set; }
        [Required]
        [ForeignKey("FK_userId")]
        public string userId { get; set; }
        public ICollection<ExpertQuestionAnswer> Answers { get; set; }
        public UserProfile userProfile { get; set; }
    }
}
