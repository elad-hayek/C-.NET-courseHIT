using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic
{
    public sealed class FuelEnergySource : EnergySource
    {
        private eFuelType m_FuelType;

        public FuelEnergySource(eFuelType i_FuelType, float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity)
        {
            if (i_FuelType == eFuelType.None)
            {
                throw new ArgumentException("Fuel type cannot be None for a fuel energy source.");
            }

            m_FuelType = i_FuelType;
        }

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

        public override void AddEnergy(float i_AmountToAdd, eFuelType? i_FuelType = null)
        {
            if (i_FuelType == null)
            {
                throw new ArgumentNullException("i_FuelType", "Fuel type must be provided when refueling a vehicle.");
            }

            refuel(i_AmountToAdd, i_FuelType.Value);
        }

        private void refuel(float i_AmountOfLitersToAdd, eFuelType i_FuelType)
        {
            if (i_AmountOfLitersToAdd <= 0)
            {
                throw new ValueRangeException("Amount of fuel to add", 0.1f, MaxEnergyCapacity - CurrentAvailableEnergy);
            }

            if (CurrentAvailableEnergy + i_AmountOfLitersToAdd > MaxEnergyCapacity)
            {
                throw new ValueRangeException("Fuel tank capacity", 0, MaxEnergyCapacity);
            }

            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException($"Incorrect fuel type. Expected: {m_FuelType}, Provided: {i_FuelType}");
            }

            EnergyPercentage = ((CurrentAvailableEnergy + i_AmountOfLitersToAdd) / MaxEnergyCapacity) * 100;
        }

        public override string ToString()
        {
            return string.Format("Fuel Type: {0}{3}Current Fuel Level: {1}L  ({2}%)",
                    m_FuelType,
                    CurrentAvailableEnergy,
                    EnergyPercentage,
                    Environment.NewLine);
        }

        public override string GetEnergyPercentageQuestion()
        {
            return "Please enter the amount of fuel percentage";
        }
    }
}
