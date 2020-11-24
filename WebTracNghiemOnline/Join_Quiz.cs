namespace WebTracNghiemOnline
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Join_Quiz
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_User { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Quiz { get; set; }

        public int? Number_of_Times { get; set; }

        public double? Score { get; set; }

        public virtual Quiz Quiz { get; set; }

        public virtual User User { get; set; }
    }
}
