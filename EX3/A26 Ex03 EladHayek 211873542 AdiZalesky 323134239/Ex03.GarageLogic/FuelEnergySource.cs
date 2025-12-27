namespace Ex03.GarageLogic
{
    public class FuelEnergySource : EnergySource
    {
        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }

        public float CurrentFuelLevel
        {
            get
            {
                return CurrentAvailableEnergy;
            }
        }

        public void Refuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            // TODO: Implement proper exception handling for fuel type and capacity limits
        }
    }
}
