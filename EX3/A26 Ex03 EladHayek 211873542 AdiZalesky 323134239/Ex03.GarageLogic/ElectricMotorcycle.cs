namespace Ex03.GarageLogic
{
    public sealed class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            m_EnergySource = new ElectricEnergySource(2.6f);
            m_EnergyKind = eEnergyKind.Electric;
        }
    }
}
