using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

// For Bulk Operations Do:

// Read             [X]     Increase Current Record Pointer If More Records Available
// FieldCount       [X]     Return Number Of Fields In The Type
// GetValue         [X]     Return Value At Oridinal In Current Record
// GetOridinal      [X]     Return Ordinal Of Particular Property
// GetName          []

namespace AutoLot.BulkOperations {
    public interface IGenericDataReader<T> : IDataReader {
        List<T> Records { get; set; }
    }

    class GenericDataReader<T> : IGenericDataReader<T> {
        public List<T> Records { get; set; }

        private PropertyInfo[] properties;
        private Dictionary<string, int> nameToOridinalMappings;
        private int currentRecord = -1;

        public GenericDataReader(List <T> records) {

            this.Records = records;
            properties = typeof(T).GetProperties();
            nameToOridinalMappings = properties.Select((x, i) => new { Name = x.Name, Index = i }).ToDictionary(x => x.Name, x => x.Index);

        }

        public void Close() {
            throw new NotImplementedException();
        }

        public int Depth {
            get { throw new NotImplementedException(); }
        }

        public DataTable GetSchemaTable() {
            throw new NotImplementedException();
        }

        public bool IsClosed {
            get { throw new NotImplementedException(); }
        }

        public bool NextResult() {
            throw new NotImplementedException();
        }

        public bool Read() {
            if ((currentRecord + 1) >= Records.Count) return false;
            currentRecord++;
            return true;
        }

        public int RecordsAffected {
            get { throw new NotImplementedException(); }
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public int FieldCount {
            get { return properties.Length; }
        }

        public bool GetBoolean(int i) {
            throw new NotImplementedException();
        }

        public byte GetByte(int i) {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) {
            throw new NotImplementedException();
        }

        public char GetChar(int i) {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i) {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i) {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i) {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i) {
            throw new NotImplementedException();
        }

        public double GetDouble(int i) {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i) {
            throw new NotImplementedException();
        }

        public float GetFloat(int i) {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i) {
            throw new NotImplementedException();
        }

        public short GetInt16(int i) {
            throw new NotImplementedException();
        }

        public int GetInt32(int i) {
            throw new NotImplementedException();
        }

        public long GetInt64(int i) {
            throw new NotImplementedException();
        }

        public string GetName(int i) {
            if (nameToOridinalMappings.ContainsValue(i)) {
                return properties[i].Name;
            }
            return string.Empty;
        }

        public int GetOrdinal(string name) {
            if (nameToOridinalMappings.ContainsKey(name)) {
                return nameToOridinalMappings[name];
            }
            return -1;
        }

        public string GetString(int i) {
            throw new NotImplementedException();
        }

        public object GetValue(int i) {
            return properties[i].GetValue(Records[currentRecord]);
        }

        public int GetValues(object[] values) {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i) {   
            throw new NotImplementedException();
        }

        public object this[string name] {
            get { throw new NotImplementedException(); }
        }

        public object this[int i] {
            get { throw new NotImplementedException(); }
        }
    }
}
