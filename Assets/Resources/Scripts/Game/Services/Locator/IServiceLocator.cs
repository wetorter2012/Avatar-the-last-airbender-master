namespace Game.Services.Locator
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
