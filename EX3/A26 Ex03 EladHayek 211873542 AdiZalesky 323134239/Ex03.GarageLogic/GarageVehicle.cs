using System;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;

        public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
        }

        private string getVehicleStatusString()
        {
            switch (m_VehicleStatus)
            {
                case eVehicleStatus.InRepair:
                    return "In Repair";
                case eVehicleStatus.Repaired:
                    return "Repaired";
                case eVehicleStatus.Paid:
                    return "Paid";
                default:
                    // TODO: proper exception
                    throw new Exception("");
            }
        }

        public override string ToString()
        {
            return string.Format("Owner Name: {0}{3}Vehicle Status: {1}{3}{2}",
                m_OwnerName,
                getVehicleStatusString(),
                m_Vehicle.ToString(),
                Environment.NewLine);
        }
    }
}
