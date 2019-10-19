using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Runtime.CompilerServices;

namespace WpfFinalCompilation.Models {
    partial class Inventory : IDataErrorInfo { 

        private string error;
        // STRING DEFINTION OF ERROR
        public string Error => error;

        // INDEXER CALLED WHEN PROPERTYCHANGED EVENT IS RAISED
        public string this[string columnName] {
            get {
                switch(columnName) {
                    case nameof(Id):
                        AddErrors(GetErrorsFromAnnotations(Id, nameof(Id)), nameof(Id));
                        break;
                    case nameof(Make):
                        if (Make == "ModelT") {
                            AddError("Too Old", nameof(Make));
                            AddErrors(GetErrorsFromAnnotations(Make, nameof(Make)), nameof(Make));
                            break;
                        } else {
                            ClearErrors(nameof(Make));
                            AddErrors(GetErrorsFromAnnotations(Make, nameof(Make)), nameof(Make));
                            goto case nameof(Color);
                        }
                    case nameof(Color):
                        if (Make == "Chevy" && Color == "Pink") {
                            AddError($"{Make}'s doesn't come in {Color}", nameof(Color));
                            AddError($"{Make}'s doesn't come in {Color}", nameof(Make));
                        } else {
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
