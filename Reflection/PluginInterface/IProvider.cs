namespace PluginInterface
{
    public interface IProvider
    {
        public ProviderType ProviderType { get; }

        public object Read(string key);

        public void Write(string key, object value);
    }
}
