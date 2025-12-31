using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string M_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return M_ManufacturerName;
            }
            set
            {
                M_ManufacturerName = value;
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
            if(i_AirToAdd <= 0)
            {
                throw new ValueRangeException("Tire Air Pressure to add", 0.1f, r_MaxAirPressure - m_CurrentAirPressure);
            }

            if (m_CurrentAirPressure + i_AirToAdd <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueRangeException("Tire Air Pressure", 0, r_MaxAirPressure);
            }
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

    }
}
