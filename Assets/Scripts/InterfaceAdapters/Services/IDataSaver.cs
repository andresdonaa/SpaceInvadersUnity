public interface IDataSaver
{
    int GetInt(string key, int defaultValue = default);

    void SetInt(string key, int value);
}