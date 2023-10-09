using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.DinnerAggregate.ValueObjects;

public sealed class Location : ValueObject
{
    private Location(
        string name,
        string address,
        decimal latitude,
        decimal longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }

    public static Location Create(
        string name,
        string address,
        decimal latitude,
        decimal longitude)
    {
        return new Location(name, address, latitude, longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;

    }
}
