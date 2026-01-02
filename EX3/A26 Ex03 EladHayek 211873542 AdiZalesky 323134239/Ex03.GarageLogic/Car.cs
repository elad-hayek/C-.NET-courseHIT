using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private int m_NumberOfDoors;

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public int NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                if(value < 2 || value > 5)
                {
                    throw new ValueRangeException("Car number of doors", 2, 5);
                }

                m_NumberOfDoors = value;
            }
        }

        protected Car(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            Wheels = new Wheel[5];

            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(33f);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{3}Car Color: {1}{3}Number of Doors: {2}",
                base.ToString(),
                m_CarColor,
                m_NumberOfDoors,
                Environment.NewLine);
        }

        public override void SetSpecificVehicleData(string[] i_VehicleSpecificData)
        {
            string carColorString = i_VehicleSpecificData[0];
            bool colorParseSuccedded = Enum.TryParse(carColorString, out eCarColor carColor);

            if (colorParseSuccedded)
            {
                m_CarColor = carColor;
            }
            else
            {
                throw new FormatException("Invalid car color option.");
            }

            NumberOfDoors = int.Parse(i_VehicleSpecificData[1]);
        }
    }
}
