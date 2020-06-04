using System;
using System.Collections.Generic;

namespace MyMarketPlaceCoolProducts.Repositories
{
    public interface IRepository<T, Id>
    {

        IList<T> FindAll();

        T FindById(Id _);

        T InsertOne(T t);

        bool RemoveOne(T t);

        T UpdateOne(T t, Id _);

    }
}
