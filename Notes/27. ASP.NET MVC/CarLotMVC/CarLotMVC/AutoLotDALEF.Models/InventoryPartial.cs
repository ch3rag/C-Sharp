namespace AutoLotDALEF.Models {

    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using CarLotMVC.AutoLotDALEF.Models.Metadata;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(InventoryMetadata))]
    public partial class Inventory {
        // don't populate or materialize
        [NotMapped]
        public string MakeColor { get { return String.Format("{0}({1})", this.Make, this.Color); } }

        public override string ToString() {
            return String.Format("{0} is a {1} {2} with ID {3}", this.PetName ?? "*** No Name ***", 
                this.Color, this.Make, this.Id);
        }
    }
}