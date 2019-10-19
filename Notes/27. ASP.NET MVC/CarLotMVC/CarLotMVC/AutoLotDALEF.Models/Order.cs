namespace AutoLotDALEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using AutoLotDALEF.Models.Base;

    public partial class Order : EntityBase
    {

        public int CustomerId { get; set; }

        public int CardId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("CarId")]
        public virtual Inventory Inventory { get; set; }
    }
}
