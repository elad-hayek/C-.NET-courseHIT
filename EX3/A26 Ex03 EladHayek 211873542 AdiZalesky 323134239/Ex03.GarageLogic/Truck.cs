using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private bool m_IsCarryingHazardousMaterials;
        private float m_CargoVolume;

        protected Truck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            Wheels = new Wheel[12];

            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(26f);
            }
        }

        public bool IsCarryingHazardousMaterials
        {
            get
            {
                return m_IsCarryingHazardousMaterials;
            }
            set
            {
                m_IsCarryingHazardousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cargo volume cannot be negative.");
                }

                m_CargoVolume = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{3}Carrying Hazardous Materials: {1}{3}Cargo Volume: {2} cubic meters",
                base.ToString(),
                m_IsCarryingHazardousMaterials ? "Yes" : "No",
                m_CargoVolume,
                Environment.NewLine);
        }

        public override void SetSpecificVehicleData(string[] i_VehicleSpecificData)
        {
            IsCarryingHazardousMaterials = bool.Parse(i_VehicleSpecificData[0]);
            CargoVolume = float.Parse(i_VehicleSpecificData[1]);
        }

        public override Dictionary<eVehicleQuestion, string> GetVehicleDataQuestions()
        {
            Dictionary<eVehicleQuestion, string> questionsDictionary = base.GetVehicleDataQuestions();
            questionsDictionary.Add(eVehicleQuestion.IsCarryingHazardousMaterials, "Is the truck carrying hazardous materials? (true/false)");
            questionsDictionary.Add(eVehicleQuestion.CargoVolume, "Please enter the cargo volume in cubic meters: ");

            return questionsDictionary;
        }

        public override void SetVehicleDataFromQuestionAnswer(eVehicleQuestion i_QuestionType, string i_Answer)
        {
            base.SetVehicleDataFromQuestionAnswer(i_QuestionType, i_Answer);

            switch (i_QuestionType)
            {
               case eVehicleQuestion.IsCarryingHazardousMaterials:
                    IsCarryingHazardousMaterials = bool.Parse(i_Answer);
                    break;
                case eVehicleQuestion.CargoVolume:
                    CargoVolume = float.Parse(i_Answer);
                    break;
            }
        }
    }
}
