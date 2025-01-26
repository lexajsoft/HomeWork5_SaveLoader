namespace Services.ServiceLocator
{
    public interface IConfig<T>
    {
        T Clone();
        void Init();
    }
}