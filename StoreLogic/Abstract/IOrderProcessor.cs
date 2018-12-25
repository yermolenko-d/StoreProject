using StoreLogic.Entities;
namespace StoreLogic.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Basket basket, ShippingDetails shippingDetails);
    }
}
