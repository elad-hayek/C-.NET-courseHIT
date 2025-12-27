
namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            m_EnergySource = new FuelEnergySource();
        }

        public float CurrentFuelLevel
        {
            get
            {
                // TODO: consider casting safety
                return ((FuelEnergySource)m_EnergySource).CurrentFuelLevel;
            }
        }

        public void Refuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            // TODO: consider casting safety
            ((FuelEnergySource)m_EnergySource).Refuel(i_AmountToAdd, i_FuelType);
        }

    }
}
