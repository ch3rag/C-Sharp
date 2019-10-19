namespace AutoLotDALEF.Models {
    
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Customer {
        [NotMapped]
        public string FullName {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}