using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDALEF.Models.Base {
    public class EntityBase : INotifyDataErrorInfo, INotifyPropertyChanged {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [NotMapped]
        public bool IsChanged { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #region INOTIFYDATADERRORINFO

        public bool HasErrors => errors.Count != 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName) {
            if (string.IsNullOrEmpty(propertyName)) return errors.Values;
            return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        }
        #endregion

        private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        protected void OnErrorsChanged([CallerMemberName] string propertyName = "") {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

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

        protected void ClearErrors([CallerMemberName] string propertyName = "") {
            if (string.IsNullOrEmpty(propertyName)) errors.Clear();
            else errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

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
