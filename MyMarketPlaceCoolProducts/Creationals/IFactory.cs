using System;
using System.Collections.Generic;

namespace MyMarketPlaceCoolProducts.Creationals
{
    public interface IFactory<T, I>
    {

        T Create(I _);

        IList<T> Create(IList<I> _);

        I Create(T _);

        IList<I> Create(IList<T> _);
    }

}
