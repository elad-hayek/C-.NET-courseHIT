using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class ElectricEnergySource : EnergySource
    {
        public override void AddEnergy(float i_AmountToAdd, eFuelType? i_FuelType = null)
        {
            recharge(i_AmountToAdd);
        }

        public void recharge(float i_MinutesToAdd)
        {
            if (CurrentAvailableEnergy + i_MinutesToAdd > MaxEnergyCapacity)
            {
                throw new ValueRangeException("Battery capacity", 0, MaxEnergyCapacity);
            }

            EnergyPercentage = ((CurrentAvailableEnergy + i_MinutesToAdd) / MaxEnergyCapacity) * 100;
        }

    }
}
