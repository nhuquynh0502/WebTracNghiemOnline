namespace WebTracNghiemOnline
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Quiz { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Question { get; set; }

        [Key]
        [Column("Answer", Order = 2)]
        [StringLength(200)]
        public string Answer1 { get; set; }

        public bool? Correct_Answer { get; set; }

        public virtual Question Question { get; set; }
    }
}
