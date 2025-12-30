namespace Ex03.GarageLogic
{
    public class ElectricEnergySource : EnergySource
    {
        public override void AddEnergy(float i_AmountToAdd, eFuelType? i_FuelType = null)
        {
            Recharge(i_AmountToAdd);
        }

        public void Recharge(float i_HoursToAdd)
        {
            // TODO: Implement proper exception handling for battery capacity limits
        }

    }
}
