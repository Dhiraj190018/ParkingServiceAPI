namespace ParkingServiceAPI.DataContract
{
    public interface IParkingFeesCalculator
    {
        decimal CalculateFees(double hours);
    }
}