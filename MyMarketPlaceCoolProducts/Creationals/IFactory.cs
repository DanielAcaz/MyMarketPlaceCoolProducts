using System;
using System.Collections.Generic;

namespace MyMarketPlaceCoolProducts.Creationals
{
    public interface IFactory<T, I>
    {

        T CreateBy(I _);

        IList<T> CreateBy(IList<I> _);

        I CreateBy(T _);

        IList<I> CreateBy(IList<T> _);
    }

}
