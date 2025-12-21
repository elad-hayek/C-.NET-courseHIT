using System;

namespace Ex02_1
{
    public class Player
    {
        private readonly char r_PlayerSymbol;
        private int m_Score;

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

        public Player(char i_PlayerSymbol)
        {
            r_PlayerSymbol = i_PlayerSymbol;
            m_Score = 0;
        }
    }
}
