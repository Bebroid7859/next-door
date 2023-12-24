using SFML.System;

namespace NextDoor
{
    public class Vector2
    {
        public readonly int X, Y;
        public Vector2(int x, int y) { X = x; Y = y; }
        public Vector2(Vector2f vector) { X = Convert.ToInt32(vector.X); Y = Convert.ToInt32(vector.Y); }
        public Vector2(string x, string y) : this(Convert.ToInt32(x), Convert.ToInt32(y)) { }
        public Vector2(string xy) : this(Convert.ToInt32(xy.Split(",")[0]), Convert.ToInt32(xy.Split(",")[1])) { }
        public static Vector2 Zero = new Vector2(0, 0);

        public static Vector2 operator +(Vector2 a, Vector2 b) { return new Vector2(a.X + b.X, a.Y + b.Y); }
        public static Vector2 operator -(Vector2 a, Vector2 b) { return new Vector2(a.X - b.X, a.Y - b.Y); }
        public static Vector2 operator *(int a, Vector2 b) { return new Vector2(a * b.X, a * b.Y); }
        public static Vector2 operator *(Vector2 b, int a) { return new Vector2(a * b.X, a * b.Y); }
        public static Vector2 operator /(Vector2 a, int b) { return new Vector2(a.X / b, a.Y / b); }
        public static Vector2 operator -(Vector2 a) { return new Vector2(-a.X, -a.Y); }

        public static bool operator ==(Vector2 me, Vector2 other) { return me.X == other.X && me.Y == other.Y; }
        public static bool operator !=(Vector2 me, Vector2 other) { return !(me == other); }

        public override int GetHashCode() { return X.GetHashCode() ^ Y.GetHashCode(); }

        public bool Equals(Vector2 other) { return this == other; }
        public override bool Equals(object? obj) { return obj is Vector2 vec && Equals(vec); }

        public override string ToString() { return X + "," + Y; }

        public Vector2f ToVector2f() { return new Vector2f(X, Y); }
    }
}