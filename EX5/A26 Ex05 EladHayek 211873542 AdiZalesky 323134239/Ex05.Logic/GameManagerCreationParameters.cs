namespace Ex05.Logic
{
    public class GameManagerCreationParameters
    {
        private int m_BoardHeight;
        private int m_BoardWidth;
        private eGameMode m_GameMode;
        private string m_Player1Name;
        private string m_Player2Name;

        public int BoardHeight 
        { 
            get
            {
                return m_BoardHeight;
            }

            set
            {
                m_BoardHeight = value;
            }
        }

        public int BoardWidth
        {
            get
            {
                return m_BoardWidth;
            }

            set
            {
                m_BoardWidth = value;
            }
        }

        public eGameMode GameMode
        {
            get
            {
                return m_GameMode;
            }

            set
            {
                m_GameMode = value;
            }
        }

        public string Player1Name
        {
            get
            {
                return m_Player1Name;
            }

            set
            {
                m_Player1Name = value;
            }
        }

        public string Player2Name
        {
            get
            {
                return m_Player2Name;
            }

            set
            {
                m_Player2Name = value;
            }
        }
    }
}