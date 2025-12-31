
namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            m_EnergySource = new FuelEnergySource(eFuelType.Octan98, 6.8f);
            m_EnergyKind = eEnergyKind.Fuel;
        }
    }
}
