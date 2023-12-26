namespace NextDoor.Graphics
{
    public class AnimatedRotation
    {
        public float Rotation { get => R; }

        float R;
        bool sex;

        public void Update()
        {
            if (R > 6)
            {
                sex = true;
            }
            else if(R < -6)
            {
                sex = false;
            }

            if (!sex) R += 0.1f;
            if (sex) R -= 0.1f;
        }
    }
    public class AnimatedRotation2
    {
        public float Rotation { get => R; }

        float R;
        bool sex;

        public void Update()
        {
            if (R > 30)
            {
                sex = true;
            }
            else if(R < -15)
            {
                sex = false;
            }

            if (!sex) R += 1f;
            if (sex) R -= 1f;
        }
    }
    public class AnimatedRotation3
    {
        public float Rotation { get => R; }
        public int sexx = -1;
        public int sexx2 = -1;

        float R;
        bool sex;

        public void Update()
        {
            if (R > 10)
            {
                sex = true;
            }
            else if(R == 0)
            {
                sex = false;
            }

            if (!sex) R += 1f;
            if (sex) R -= 1f;
        }
    }
}