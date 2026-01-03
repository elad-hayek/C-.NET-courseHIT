using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseID;
        private Wheel[] m_Wheels;
        protected EnergySource m_EnergySource;
        protected eEnergyKind m_EnergyKind;

        protected Vehicle(string i_LicenseID, string i_ModelName)
        {
            r_LicenseID = i_LicenseID;
            r_ModelName = i_ModelName;
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenseID
        {
            get
            {
                return r_LicenseID;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentException("Wheels cannot be null or empty");
                }

                m_Wheels = value;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergySource.EnergyPercentage;
            }
            set
            {
                m_EnergySource.EnergyPercentage = value;
            }
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return m_EnergySource.MaxEnergyCapacity;
            }
        }

        public float CurrentAvailableEnergy
        {
            get
            {
                return m_EnergySource.CurrentAvailableEnergy;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                eFuelType fuelType = eFuelType.None;

                switch (m_EnergyKind)
                {
                    case eEnergyKind.Fuel:
                        fuelType = ((FuelEnergySource)m_EnergySource).FuelType;
                        break;
                    case eEnergyKind.Electric:
                        fuelType = eFuelType.None;
                        break;
                    default:
                        throw new Exception("Unknown energy kind");
                }

                return fuelType;
            }
        }

        public eEnergyKind EnergyKind
        {
            get
            {
                return m_EnergyKind;
            }
        }

        public void AddEnergy(float i_AmountToAdd, eFuelType? i_FuelType = null)
        {
            if (m_EnergySource == null)
            {
                throw new NullReferenceException("Energy source is not initialized");
            }

            m_EnergySource.AddEnergy(i_AmountToAdd, i_FuelType);
        }

        public void InflateTiresToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        private string getWheelsInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < m_Wheels.Length; i++)
            {
                stringBuilder.AppendLine($"Wheel {i + 1}:");
                stringBuilder.AppendLine($"{m_Wheels[i].ToString()}");
            }

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return string.Format("License ID: {1}{0}Model Name: {2}{0}{3}{4}",
                Environment.NewLine,
                r_LicenseID,
                r_ModelName,
                getWheelsInfo(),
                m_EnergySource.ToString());
        }

        public abstract void SetSpecificVehicleData(string[] i_VehicleSpecificData);
        public virtual Dictionary<eVehicleQuestion, string> GetVehicleDataQuestions()
        {
            Dictionary<eVehicleQuestion, string> questionsDictionary = new Dictionary<eVehicleQuestion, string>();
            questionsDictionary.Add(eVehicleQuestion.WheelManufacturer, "Enter the wheels manufacturer: ");
            questionsDictionary.Add(eVehicleQuestion.CurrentWheelAirPressure, "Enter the current air pressure of the wheels: ");
            questionsDictionary.Add(eVehicleQuestion.EnergySourcePercentage, m_EnergySource.GetEnergyPercentageQuestion());

            return questionsDictionary;
        }

        public virtual void SetVehicleDataFromQuestionAnswer(eVehicleQuestion i_QuestionType, string i_Answer)
        {
            switch (i_QuestionType)
            {
                case eVehicleQuestion.WheelManufacturer:
                    setWheelsManufacturer(i_Answer);
                    break;
                case eVehicleQuestion.CurrentWheelAirPressure:
                    setWheelCurrentAirPressure(i_Answer);
                    break;
                case eVehicleQuestion.EnergySourcePercentage:
                    EnergyPercentage = float.Parse(i_Answer);
                    break;
            }
        }

        private void setWheelsManufacturer(string i_ManufacturerName)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        private void setWheelCurrentAirPressure(string i_Answer)
        {
            if (float.TryParse(i_Answer, out float airPressureToSet))
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    wheel.Inflate(airPressureToSet - wheel.CurrentAirPressure);
                }
            }
            else
            {
                throw new FormatException("Invalid format for wheel air pressure");
            }
        }
    }
}
