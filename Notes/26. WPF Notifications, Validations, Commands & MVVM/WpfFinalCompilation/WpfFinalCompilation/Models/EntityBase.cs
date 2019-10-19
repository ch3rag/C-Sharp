using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace WpfFinalCompilation.Models {

    public class EntityBase : INotifyDataErrorInfo {

        #region INOTIFYDATADERRORINFO
        // THREE MEMBER NEEDED TO BE IMPLEMENTED FOR INOTIFYDATAERROR INFO

        // IS THERE ARE ANY ERROR RELATED TO ANY PROPERTY IN THE MODEL
        public bool HasErrors => errors.Count != 0;

        // EVENT RAISED WHEN ERRORS ARE CHANGED (HAPPEND OR CLEARED BOTH)
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        // GETTING A LIST OF ERRORS BY PROPERTY NAME
        public IEnumerable GetErrors(string propertyName) {
            if (string.IsNullOrEmpty(propertyName)) return errors.Values;
            return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        }
        #endregion


        // MAPPING FROM CONTROLS TO LIST OF ERROR THEY CONTAIN
        private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();


        // HELPER FOR RAISING EVENTS PROGRAMATICALLY
        protected void OnErrorsChanged([CallerMemberName] string propertyName = "") {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        // ADD ERROR AND ERRORS TO COLLECTION 
        protected void AddError(string error, [CallerMemberName] string propertyName = "") {
            AddErrors(new List<string> { error }, propertyName);
        }

        protected void AddErrors(IList<string> errorList, [CallerMemberName] string propertyName = "") {
            if (errorList == null) return;
            bool isChanged = false;
            if (!errors.ContainsKey(propertyName)) {
                errors.Add(propertyName, new List<string>());
                isChanged = true;
            }

            foreach (string error in errorList) {
                if (errors[propertyName].Contains(error)) continue;
                errors[propertyName].Add(error);
                isChanged = true;
            }

            if (isChanged) OnErrorsChanged(propertyName);
        }

        // CLEAR EXISTSING ERRORS
        protected void ClearErrors([CallerMemberName] string propertyName = "") {
            if (string.IsNullOrEmpty(propertyName)) errors.Clear();
            else errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }


        // GET ERROR INFORMATION BASED ON DATA ANNOTATIONS
        protected string[] GetErrorsFromAnnotations<T>(T value, [CallerMemberName] string propertyName = "") {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(this, null, null) {
                MemberName = propertyName
            };
            bool isValid = Validator.TryValidateProperty(value, validationContext, results);
            return (isValid) ? null : Array.ConvertAll(results.ToArray(), x => x.ErrorMessage);
        }
    }
}
