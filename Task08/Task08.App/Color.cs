namespace Task08.App
{
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return $"RGB({R}, {G}, {B})";
        }
    }

    public class ColorClass
    {
        public byte R;
        public byte G;
        public byte B;

        public ColorClass(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}