namespace Project
{
    public interface IPowerUp
    {
        bool HasLifetime { get; }
        float Lifetime { get; }
        float PrestopTime { get; }
        ColorGammaData ColorGammaData { get; }

        void OnActive();
        void OnDisactive();
    }
}
