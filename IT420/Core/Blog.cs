using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT420.Core
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int blogId { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        [Required]
        [MinLength(20)]        
        [DataType(DataType.MultilineText)]
        public string body { get; set; }
        [Required]
        [ForeignKey("blogTypeId")]
        public int blogTypeId { get; set; }        
        public string blogImageURL { get; set; }
        public bool approved { get; set; }
        public DateTime CreatedDate { get; set; }
        
        [ForeignKey("blogUserId")]
        public string userId { get; set; }        

        public BlogType type { get; set; }

    }
}
