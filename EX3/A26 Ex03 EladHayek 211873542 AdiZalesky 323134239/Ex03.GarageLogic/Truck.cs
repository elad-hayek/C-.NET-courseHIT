
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
                m_CargoVolume = value;
            }
        }
    }
}
