using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;

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
            m_CarColor = parseCarColor(carColorString);
            NumberOfDoors = int.Parse(i_VehicleSpecificData[1]);
        }

        private eCarColor parseCarColor(string i_CarColorString)
        {
            bool colorParseSuccedded = Enum.TryParse(i_CarColorString, out eCarColor carColor);

            if (colorParseSuccedded)
            {
                return carColor;
            }
            else
            {
                throw new FormatException("Invalid car color option.");
            }
        }

        public override Dictionary<eVehicleQuestion, string> GetVehicleDataQuestions()
        {
            Dictionary<eVehicleQuestion, string> questionsDictionary = base.GetVehicleDataQuestions();
            questionsDictionary.Add(eVehicleQuestion.CarColor, "Please enter the car color (Options: Blue, Green, White, Black): ");
            questionsDictionary.Add(eVehicleQuestion.NumberOfDoors, "Please enter the number of doors (Options: 2, 3, 4, 5): ");
            return questionsDictionary;
        }

        public override void SetVehicleDataFromQuestionAnswer(eVehicleQuestion i_QuestionType, string i_Answer)
        {
            base.SetVehicleDataFromQuestionAnswer(i_QuestionType, i_Answer);

            switch (i_QuestionType)
            {
                case eVehicleQuestion.CarColor:
                    m_CarColor = parseCarColor(i_Answer);
                    break;
                case eVehicleQuestion.NumberOfDoors:
                    NumberOfDoors = int.Parse(i_Answer);
                    break;
            }
        }
    }
}
