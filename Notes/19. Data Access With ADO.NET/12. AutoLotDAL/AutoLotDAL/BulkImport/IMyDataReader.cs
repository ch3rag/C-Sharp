using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Linq;

namespace AutoLotDAL.BulkImport {
    public interface IMyDataReader<T> : IDataReader {
       List<T> Records { get; set; }
    }

    public class MyDataReader<T> : IMyDataReader<T> {

        public List<T> Records { get; set; }

        private readonly PropertyInfo[] properties;
        private readonly Dictionary<string, int> nameToIndexMappings;
        private int currentIndex = -1;

        public MyDataReader() : this (null) { }

        public MyDataReader(List<T> records) {
            properties = typeof(T).GetProperties();
            nameToIndexMappings = properties.Select((x, i) => new { Name = x.Name, Index = i }).ToDictionary(pair => pair.Name, pair => pair.Index);
            this.Records = records;
        }

        public bool Read() {
            if ((currentIndex + 1) >= Records.Count) return false;
            currentIndex++;
            return true;
        }

        public int FieldCount() {
            return this.properties.Length;
        }


        int IDataRecord.FieldCount {
            get { return this.properties.Length; }
        }

        public int GetOrdinal(string name) {
            return  nameToIndexMappings.ContainsKey(name) ? nameToIndexMappings[name] : -1;
        }

        public string GetName(int i) {
            return (i >= 0 && i < FieldCount()) ? properties[i].Name : String.Empty;
        }

        public object GetValue(int i) {
            return properties[i].GetValue(Records[currentIndex]);
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

        public int RecordsAffected {
            get { throw new NotImplementedException(); }
        }

        public void Dispose() {
            
            throw new NotImplementedException();
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

        public string GetString(int i) {
            throw new NotImplementedException();
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
