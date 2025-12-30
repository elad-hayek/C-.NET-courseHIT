
namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public ElectricCar(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            m_EnergySource = new ElectricEnergySource();
            m_EnergyKind = eEnergyKind.Electric;
        }
    }
}
