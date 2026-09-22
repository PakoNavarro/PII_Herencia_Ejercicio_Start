public class PoolDriver : Driver
{
    public int MaxCapacity { get; set; }

    public PoolDriver(string name, string lastName, string id, string profilePhoto, double rating, string car, string bio, int maxCapacity)
     : base(name, lastName, id, profilePhoto, rating, car, bio)
    {
        MaxCapacity = maxCapacity;
    }
}
