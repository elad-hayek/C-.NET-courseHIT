
namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            m_EnergySource = new ElectricEnergySource();
        }

        public float CurrentBatteryLevel
        {
            get
            {
                // TODO: consider casting safety
                return ((ElectricEnergySource)m_EnergySource).CurrentBatteryLevel;
            }
        }

        public void Recharge(float i_AmountToAdd, eFuelType i_FuelType)
        {
            // TODO: consider casting safety
            ((ElectricEnergySource)m_EnergySource).Recharge(i_AmountToAdd);
        }
    }
}
