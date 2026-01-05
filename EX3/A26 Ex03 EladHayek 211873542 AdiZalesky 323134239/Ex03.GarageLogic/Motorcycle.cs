using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        protected Motorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            Wheels = new Wheel[2];

            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(29f);
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Engine capacity must be a positive integer.");
                }

                m_EngineCapacity = value;
            }
        }

        public override string ToString()
        {
            string engineCapacityString = m_EnergyKind == eEnergyKind.Fuel ? $"{m_EngineCapacity.ToString()}cc" : "N/A";

            return string.Format("{0}{3}License Type: {1}{3}Engine Capacity: {2}",
                base.ToString(),
                m_LicenseType,
                engineCapacityString,
                Environment.NewLine);
        }

        public override void SetSpecificVehicleData(string[] i_VehicleSpecificData)
        {
            string licenseTypeString = i_VehicleSpecificData[0];
            LicenseType = parseLicenseType(licenseTypeString);

            if(m_EnergyKind == eEnergyKind.Fuel)
            {
                EngineCapacity = int.Parse(i_VehicleSpecificData[1]);
            }
        }

        private eLicenseType parseLicenseType(string i_LicenseType)
        {
            if (!Enum.TryParse(i_LicenseType, out eLicenseType licenseType))
            {
                throw new FormatException("Invalid license type option.");
            }
            
            return licenseType;
        }

        public override Dictionary<eVehicleQuestion, string> GetVehicleDataQuestions()
        {
            Dictionary<eVehicleQuestion, string> questionsDictionary = base.GetVehicleDataQuestions();
            questionsDictionary.Add(eVehicleQuestion.LicenseType, "Please enter the motorcycle license type (A1, A2, AA, B): ");
            questionsDictionary.Add(eVehicleQuestion.EngineCapacity, "Please enter the engine capacity (in cc): ");

            return questionsDictionary;
        }

        public override void SetVehicleDataFromQuestionAnswer(eVehicleQuestion i_QuestionType, string i_Answer)
        {
            base.SetVehicleDataFromQuestionAnswer(i_QuestionType, i_Answer);

            switch (i_QuestionType)
            {
                case eVehicleQuestion.LicenseType:
                    LicenseType = parseLicenseType(i_Answer);
                    break;
                case eVehicleQuestion.EngineCapacity:
                    EngineCapacity = int.Parse(i_Answer);
                    break;
            }
        }
    }
}
