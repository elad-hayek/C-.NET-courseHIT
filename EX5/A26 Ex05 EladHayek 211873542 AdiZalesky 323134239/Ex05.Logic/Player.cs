namespace Ex05.Logic
{
    public class Player
    {
        private readonly char r_PlayerSymbol;
        private int m_Score;
        private readonly string r_PlayerName;

        public char PlayerSymbol
        {
            get 
            { 
                return r_PlayerSymbol;
            }
        }

        public int Score
        {
            get
            { 
                return m_Score;
            }

            set 
            { 
                m_Score = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return r_PlayerName;
            }
        }

        public Player(char i_PlayerSymbol, string i_PlayerName)
        {
            r_PlayerSymbol = i_PlayerSymbol;
            m_Score = 0;
            r_PlayerName = i_PlayerName;
        }
    }
}