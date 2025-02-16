namespace Source.Core.Random
{
    public interface IRandomProvider
    {
        public float NextNormal { get; }
        public int NextInt { get; }
        public float NextFloat { get; }
        
        public int Range(in int a, in int b);
        public float Range(in float a, in float b);
    }
}