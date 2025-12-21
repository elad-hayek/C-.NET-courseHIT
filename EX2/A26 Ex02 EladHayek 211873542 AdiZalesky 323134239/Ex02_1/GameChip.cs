namespace Ex02_1
{
    public struct GameChip
    {
        private readonly char m_PlayerSymbol;

        public int PlayerId
        {
            get
            {
                return m_PlayerSymbol;
            }
        }

        public GameChip(char i_PlayerSymbol)
        {
            m_PlayerSymbol = i_PlayerSymbol;
        }
    }
}
