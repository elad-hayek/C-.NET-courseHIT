using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class ElectricEnergySource : EnergySource
    {
        public ElectricEnergySource(float i_MaxCapacity) : base(i_MaxCapacity)
        {
        }

        public override void AddEnergy(float i_AmountToAdd, eFuelType? i_FuelType = null)
        {
            recharge(i_AmountToAdd);
        }

        public void recharge(float i_MinutesToAdd)
        {
            if (i_MinutesToAdd <= 0)
            {
                throw new ValueRangeException("Amount of minutes to add", 0.1f, MaxEnergyCapacity - CurrentAvailableEnergy);
            }

            if (CurrentAvailableEnergy + i_MinutesToAdd > MaxEnergyCapacity)
            {
                throw new ValueRangeException("Battery capacity", 0, MaxEnergyCapacity);
            }

            EnergyPercentage = ((CurrentAvailableEnergy + i_MinutesToAdd) / MaxEnergyCapacity) * 100;
        }

        public override string ToString()
        {
            return string.Format("Minutes remaining in battery: {0}  ({1}%)",
                CurrentAvailableEnergy,
                EnergyPercentage);
        }

        public override string GetEnergyPercentageQuestion()
        {
            return "Please enter the battery charge percentage";
        }
    }
}
