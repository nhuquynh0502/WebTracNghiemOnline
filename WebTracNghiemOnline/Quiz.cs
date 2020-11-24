namespace WebTracNghiemOnline
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quiz")]
    public partial class Quiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quiz()
        {
            Join_Quiz = new HashSet<Join_Quiz>();
            Questions = new HashSet<Question>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Quiz { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public DateTime? Time_Start { get; set; }

        public DateTime? Time_Finish { get; set; }

        public TimeSpan? Time { get; set; }

        public int? Allow_Attemp { get; set; }

        [StringLength(10)]
        public string Keys { get; set; }

        public int? Creator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Join_Quiz> Join_Quiz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }

        public virtual User_Ask User_Ask { get; set; }
    }
}
