namespace Pub_Mangement.Models
{
    public class Enums
    {
        public enum MenuCategory
        {
            Food = 1,
            Drink = 2
        }

        public enum OrderStatus
        {
            Pending = 1,
            Preparing = 2,
            Served = 3,
            Closed = 4
        }

        public enum PaymentStatus
        {
            Pending = 1,
            Completed = 2,
            Failed = 3
        }
    }
}
