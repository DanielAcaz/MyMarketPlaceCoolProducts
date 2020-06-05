using System;
namespace MyMarketPlaceCoolProducts.Error
{
    public class InvalidProductException : Exception
    {
        public InvalidProductException()
        {
        }

        public InvalidProductException(string Message):base(Message)
        {

        }
    }
}
 