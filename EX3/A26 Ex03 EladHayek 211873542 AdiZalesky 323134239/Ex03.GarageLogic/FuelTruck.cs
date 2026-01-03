
namespace Ex03.GarageLogic
{
    public sealed class FuelTruck : Truck
    {
        public FuelTruck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            m_EnergySource = new FuelEnergySource(eFuelType.Soler, 140f);
            m_EnergyKind = eEnergyKind.Fuel;
        }
    }
}
