public class Driver : User
{
    public string Car { get; set; }
    public string Bio { get; set; }

    public Driver(string name, string lastName, string id, string profilePhoto, double rating, string car, string bio)
     : base(name, lastName, id, profilePhoto, rating)
    {
        Car = car;
        Bio = bio;
    }
}