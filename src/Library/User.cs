using System;

public class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Id { get; set; }
    public string ProfilePhoto { get; set; }
    public double Rating { get; set; }

    public User(string name, string lastName, string id, string profilePhoto, double rating)
    {
        Name = name;
        LastName = lastName;
        Id = id;
        ProfilePhoto = profilePhoto;
        Rating = rating;
    }

    public void Welcome()
    {
        Console.WriteLine("Bienvenido a nuestra aplicación");
    }
}