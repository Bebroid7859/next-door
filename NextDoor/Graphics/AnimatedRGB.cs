namespace NextDoor.Graphics
{
    public class AnimatedRGB
    {
        public byte R { get => R1; }
        public byte G { get => G1; }
        public byte B { get => B1; }
        public byte DarkG { get => (G1 / 7 > 15) ? Convert.ToByte(G / 7) : Convert.ToByte(15); }

        byte R1;
        byte R2;

        byte G1 = 255;
        byte G2;

        byte B1 = 50;
        byte B2;

        public void Update()
        {
            if (R2 > 0)
            {
                R1 -= 1;
                R2 -= 1;
            }
            else
            {
                R1 += 1;
            }

            if (R1 == 255) R2 = 255;


            if (G2 > 0)
            {
                G1 += 1;
                G2 -= 1;
            }
            else
            {
                G1 -= 1;
            }

            if (G1 == 0) G2 = 255;


            if (B2 > 0)
            {
                B1 -= 2;
                B2 -= 2;
            }
            else
            {
                B1 += 2;
            }

            if (B1 > 200) B2 = 150;
        }
    }
}