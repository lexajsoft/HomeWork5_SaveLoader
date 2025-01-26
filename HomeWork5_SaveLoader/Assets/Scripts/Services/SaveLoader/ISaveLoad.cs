namespace Services.SaveLoader
{
    public interface ISaveLoad
    {
        public void Save();
        public void Load();
    }

    public interface IJsonSaveLoad
    {
        string Save();
        void Load(string json);
    }
}