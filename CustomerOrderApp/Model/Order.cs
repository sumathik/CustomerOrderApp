namespace CustomerOrderApp.Model
{
    public class Order
    {
        public int orderNumber { get; set; }
        public string orderDate  { get; set; }
        public string deliveryAddress { get; set; }

        public string orderItems { get; set; }
        public string deliveryExpected { get; set; }

    }
}
