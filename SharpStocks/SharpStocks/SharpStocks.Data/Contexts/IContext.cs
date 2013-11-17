using System;
using System.Collections.Generic;

namespace SharpStocks.Data
{
    public interface IContext
    {
        void Delete<T>(T entity) where T : IModifiable;
        void Delete<T>(IEnumerable<T> entities) where T : IModifiable;

        void Add<T>(T entity) where T : IModifiable;
        void Add<T>(IEnumerable<T> entities) where T : IModifiable;

        void Attach<T>(T entity) where T : IModifiable;
        IEnumerable<T> All<T>() where T : IEntity;
        IEnumerable<T> Where<T>(object queryDocument) where T : IEntity;

        T Find<T>(long id) where T : IEntity;
        T Find<T>(Guid id) where T : IEntity;

        void Commit();
    }
}