using System;
using System.ComponentModel.DataAnnotations;

namespace AutoLotDALEF.Models.Base {
    public class EntityBase {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
