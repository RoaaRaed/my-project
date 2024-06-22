namespace my_resturant.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int MenulistId { get; set; }
        public Menulist Menulist { get; set; }
    }
}
