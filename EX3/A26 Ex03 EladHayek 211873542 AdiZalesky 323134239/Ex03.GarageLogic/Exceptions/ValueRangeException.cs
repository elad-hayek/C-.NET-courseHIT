using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public ValueRangeException(string i_ParameterName, float i_MinValue, float i_MaxValue)
            : base($"The value for '{i_ParameterName}' is out of range. It should be between {i_MinValue} and {i_MaxValue}.")
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
        }
    }
}
