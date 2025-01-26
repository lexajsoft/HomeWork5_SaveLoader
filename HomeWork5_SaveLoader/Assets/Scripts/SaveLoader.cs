using System.Collections.Generic;
using System.IO;
using System.Text;
using Services.SaveLoader;
using Services.ServiceLocator;
using TriInspector;
using UnityEngine;
using Views;

namespace Model
{
    public class SaveLoader : ViewBase, ISaveLoad
    {
        [Inject] private GameModel _gameModel;
        private string NameSaves => "Save.dat";
        private string PersistentDataDirectoryPath => System.IO.Path.Combine(Application.persistentDataPath ,"Saves");
        private string LocalDataDirectoryPath => System.IO.Path.Combine(Directory.GetCurrentDirectory() ,"Saves");

        private string FullPathToSave(string dirPath) => Path.Combine(dirPath, NameSaves);
        
        private byte ByteMask => 0b01010101;
        
        
        [SerializeField] private bool _isSaveLocal;
        [SerializeField] private bool _isUseProtection;
        
        [Button]
        public void Save()
        {
            var json = JsonUtility.ToJson(_gameModel,true);
            SaveToFile(json);
        }

        [Button]
        public void Load()
        {
            var jsonData = LoadFromFile();
            _gameModel.SetData(JsonUtility.FromJson<GameModel>(jsonData));
            _gameModel.InitAfterLoad();
        }

        private void SaveToFile(string data)
        {
            string path = "";
            if (_isSaveLocal)
            {
                path = LocalDataDirectoryPath;
            }
            else
            {
                path = PersistentDataDirectoryPath;
            }

            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var pathToFile = FullPathToSave(path);
            
            if (_isUseProtection)
            {
                var bytes = Encode(data);
                File.WriteAllBytes(pathToFile, bytes);
            }
            else
            {
                File.WriteAllText(pathToFile, data);    
            }
        }

        [Button]
        private void TestEcoding()
        {
            var json = JsonUtility.ToJson(_gameModel);
            var bytes = Encode(json);
            var result = Decode(bytes);
            
        }

        private string LoadFromFile()
        {
            string path = "";
            if (_isSaveLocal)
            {
                path = LocalDataDirectoryPath;
            }
            else
            {
                path = PersistentDataDirectoryPath;
            }

            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var pathToFile = FullPathToSave(path);

            if (File.Exists(pathToFile))
            {
                if (_isUseProtection)
                {
                    var bytes = File.ReadAllBytes(pathToFile);
                    var data = Decode(bytes);
                    return data;
                }
                else
                {
                    var data = File.ReadAllText(pathToFile);
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
            var bytes = UTF8Encoding.UTF8.GetBytes(data);
            List<byte> result = new List<byte>();
            foreach (byte c in bytes)
            {
                byte value = (byte)(c ^ ByteMask); // наложение маски
                result.Add(value);
            }

            return result.ToArray();
        }
        
        private string Decode(byte [] data)
        {
            string result = "";
            List<byte> bytes = new List<byte>();
            foreach (byte c in data)
            {
                byte value = (byte)(c ^ ByteMask); // наложение маски
                bytes.Add(value);
                //result += (char)value;
            }

            result = UTF8Encoding.UTF8.GetString(bytes.ToArray());

            return result;
        }
    }
}