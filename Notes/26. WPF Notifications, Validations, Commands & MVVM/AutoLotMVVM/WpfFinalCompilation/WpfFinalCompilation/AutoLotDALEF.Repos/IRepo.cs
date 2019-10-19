﻿namespace AutoLotDALEF.Repos {
    using System.Collections.Generic;
    public interface IRepo <T> {
        int Add(T entity);
        int AddRange(IList<T> entities);
        int Save(T entity);
        int Delete(int id, byte[] timeStamp);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetAll();

        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);

    }
}