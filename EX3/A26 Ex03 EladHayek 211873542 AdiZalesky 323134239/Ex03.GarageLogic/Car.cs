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
            // TODO: implement set 2 to 5 doors
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
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
    }
}
