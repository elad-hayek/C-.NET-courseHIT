namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get 
            {
                return r_ManufacturerName;
            }
        }

        public float MaxAirPressure
        {
            get 
            { 
                return r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get 
            { 
                return m_CurrentAirPressure; 
            }
        }

        public void Inflate(float i_AirToAdd)
        {
            // TODO: Implement proper exception handling for air pressure limits

            //if(m_CurrentAirPressure + i_AirToAdd <= r_MaxAirPressure)
            //{
            //    m_CurrentAirPressure += i_AirToAdd;
            //}
            //else
            //{
            //    throw new ValueOutOfRangeException(0, r_MaxAirPressure - m_CurrentAirPressure, "Air pressure to add exceeds maximum limit.");
            //}
        }

    }
}
