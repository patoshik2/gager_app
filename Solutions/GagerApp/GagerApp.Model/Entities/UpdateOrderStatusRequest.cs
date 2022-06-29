namespace GagerApp.Model.Entities
{
    public class UpdateOrderStatusRequest
    {
        #region Constructors/Finalizers

        public UpdateOrderStatusRequest(int orderID, OrderStatus status)
        {
            OrderID = orderID;
            Status = status;
        }

        private UpdateOrderStatusRequest()
        {
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public int OrderID
        {
            get;
            set;
        }

        public OrderStatus Status
        {
            get;
            set;
        }

        #endregion Properties/Indexers
    }
}
