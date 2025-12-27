namespace Ex03.GarageLogic
{
    public class ElectricEnergySource : EnergySource
    {
        public float CurrentBatteryLevel
        {
            get
            {
                return CurrentAvailableEnergy;
            }
        }
        public void Recharge(float i_HoursToAdd)
        {
            // TODO: Implement proper exception handling for battery capacity limits
        }

    }
}
