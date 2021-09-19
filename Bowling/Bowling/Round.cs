namespace Bowling
{
    class Round
    {
        //Objet round, il nous permet de savoir si le round est fini, le nombre de quille tombée par lancé, le type de round, son numéro et le score du round.
        public bool isRoundOver = false;
        public int quillePremierLancer = -1;
        public int quilleDeuxiemeLancer = -1;
        public int quilleTroisiemeLancer = 0;
        public EnumTypeRound typeDeRound = EnumTypeRound.Normal;
        public int numeroDuRound = 0;
        public int scoreDuRound
        {
            get
            {
                return quillePremierLancer + quilleDeuxiemeLancer + quilleTroisiemeLancer;
            }
        }
    }
}
