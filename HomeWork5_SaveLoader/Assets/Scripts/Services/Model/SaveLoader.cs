using System.Collections.Generic;
using System.IO;
using Services.SaveLoader;
using TriInspector;
using UnityEngine;

namespace Services.Model
{
    public class SaveLoader : MonoBehaviour, ISaveLoad
    {
        private string NameSaves => "Save.dat";
        
        private string PersistentDataPath => System.IO.Path.Combine(Application.persistentDataPath ,"Saves", NameSaves);
        private string LocalDataPath => System.IO.Path.Combine(Directory.GetCurrentDirectory() ,"Saves", NameSaves);
        private byte ByteMask => 0b01010101;
        
        
        [SerializeField] private bool _isSaveLocal;
        [SerializeField] private bool _isUseProtection;
        
        [Button]
        public void Save()
        {
            var gameModel = ServiceLocator.ServiceLocator.Get<GameModel>();
            var json = JsonUtility.ToJson(gameModel);
            SaveToFile(json);
        }

        [Button]
        public void Load()
        {
            var jsonData = LoadFromFile();
            var gameModel = ServiceLocator.ServiceLocator.Get<GameModel>();
            gameModel.SetData(JsonUtility.FromJson<GameModel>(jsonData));
            gameModel.Init();
        }

        private void SaveToFile(string data)
        {
            string path = "";
            if (_isSaveLocal)
            {
                path = LocalDataPath;
            }
            else
            {
                path = PersistentDataPath;
            }

            if (_isUseProtection)
            {
                var bytes =Encode(data);
                File.WriteAllBytes(path, bytes);
            }
            else
            {
                File.WriteAllText(path, data);    
            }
        }

        private string LoadFromFile()
        {
            string path = "";
            if (_isSaveLocal)
            {
                path = LocalDataPath;
            }
            else
            {
                path = PersistentDataPath;
            }

            if (File.Exists(path))
            {
                if (_isUseProtection)
                {
                    var data = File.ReadAllBytes(path);
                    var bytes = Decode(data);
                    
                }
                else
                {
                    var data = File.ReadAllText(path);
                    return data;
                }
            }
            else
            {
                Debug.LogError("Сохранение не найдено");
            }

            return null;
        }

        private byte [] Encode(string data)
        {
            List<byte> result = new List<byte>();
            foreach (char c in data)
            {
                byte value = (byte)(c ^ ByteMask); // наложение маски
                result.Add(value);
            }

            return result.ToArray();
        }
        
        private string Decode(byte [] data)
        {
            string result = "";
            foreach (char c in data)
            {
                byte value = (byte)(c ^ ByteMask); // наложение маски
                result += value;
            }

            return result;
        }
    }
}