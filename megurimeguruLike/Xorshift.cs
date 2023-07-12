namespace CreateMap
{
    public class Xorshift
    {
        // 内部メモリ
        private UInt32 x;
        private UInt32 y;
        private UInt32 z;
        private UInt32 w;

        public Xorshift() : this((UInt32)DateTime.Now.Ticks) { }

        public Xorshift(UInt32 seed)
        {
            x = 123456789U;
            y = 362436069U;
            z = 521288629U;
            w = seed;
        }

        public UInt32 Next()
        {
            UInt32 t = x ^ (x << 11);
            x = y;
            y = z;
            z = w;
            w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));
            return w;
        }
    }
}