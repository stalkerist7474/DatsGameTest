using System.Collections;
using UnityEngine;

public class SaveManager : IGameSystem
{
    public static SaveManager Instance;
    private ISaveSystem _saveSystem;
    public SaveData MyData;
    [SerializeField] private SaveData _myDefaultData;

    public SaveData MyDefaultData => _myDefaultData;

    private void Awake()
    {
        if (SaveManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        _saveSystem = new JsonSaveSystem(); //есть еще бинарная система для шифрования файла сохранения
        MyData = _saveSystem.Load();
    }

    public void Save()
    {
        _saveSystem.Save(MyData);
    }

    public void Load()
    {
        MyData = _saveSystem.Load();
        Save();
    }

    public void SetDefaultSaveData()
    {
        _saveSystem.Save(MyDefaultData);
        Load();
    }

    public override void Activate()
    {
        this.gameObject.SetActive(true);
    }
}