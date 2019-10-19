namespace AutoLotDALEF.Models {

    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
    public partial class Inventory : IDataErrorInfo {

        // don't populate or materialize
        [NotMapped]
        public string MakeColor { get { return String.Format("{0}({1})", this.Make, this.Color); } }

        public override string ToString() {
            return String.Format("{0} is a {1} {2} with ID {3}", this.PetName ?? "*** No Name ***", 
                this.Color, this.Make, this.Id);
        }

        private string error;

        public string Error => error;

        public string this[string columnName] {
            get {
                switch (columnName) {
                    case nameof(Id):
                        AddErrors(GetErrorsFromAnnotations(Id, nameof(Id)), nameof(Id));
                        break;
                    case nameof(Make):
                        if (Make == "ModelT") {
                            AddError("Too Old", nameof(Make));
                            AddErrors(GetErrorsFromAnnotations(Make, nameof(Make)), nameof(Make));
                            break;
                        }
                        else {
                            ClearErrors(nameof(Make));
                            AddErrors(GetErrorsFromAnnotations(Make, nameof(Make)), nameof(Make));
                            goto case nameof(Color);
                        }
                    case nameof(Color):
                        if (Make == "Chevy" && Color == "Pink") {
                            AddError($"{Make}'s doesn't come in {Color}", nameof(Color));
                            AddError($"{Make}'s doesn't come in {Color}", nameof(Make));
                        }
                        else {
                            ClearErrors(nameof(Color));
                            AddErrors(GetErrorsFromAnnotations(Color, nameof(Color)), nameof(Color));
                        }
                        break;
                    case nameof(PetName):
                        AddErrors(GetErrorsFromAnnotations(PetName, nameof(PetName)), nameof(Color));
                        break;
                }
                return string.Empty;
            }
        }
    }
}