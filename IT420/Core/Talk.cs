using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Core
{
    public class Talk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TalkId { get; set; }
        [Required]
        [ForeignKey("TypeId")]
        public int TypeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(20)]
        [Column(TypeName ="text")]
        public string Body { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }
        [ForeignKey("UserId")]
        public string userId { get; set; }        

        public TalkType TalkType { get; set; }
        public IEnumerable<TalkComment> TalkComments { get; set; }

    }
}
