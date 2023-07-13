namespace CreateMap
{
    public class Xorshift
    {
        public int Next(int x,int y,int z,int seed)
        {
            int t = x ^ (x << 11);
            x = y;
            y = z;
            z = seed;
            seed = (seed ^ (seed >> 19)) ^ (t ^ (t >> 8));

            return seed;
        }
    }
}