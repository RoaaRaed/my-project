namespace my_resturant.Models
{
    public class UserMenulistViewModel
    {
        public User User { get; set; }
        public List<Menulist> Menulist { get; set;}
        public List<Order> Order { get; set; }

    }
}
