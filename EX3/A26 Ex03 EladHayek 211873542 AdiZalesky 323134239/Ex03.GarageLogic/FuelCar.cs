namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        public FuelCar(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            m_EnergySource = new FuelEnergySource();
            m_EnergyKind = eEnergyKind.Fuel;
        }
    }
}
