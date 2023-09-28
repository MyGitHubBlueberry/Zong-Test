using Core;
using UnityEngine;

namespace Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        const string SAVE_FILE ="save";
        SavingSystem savingSystem;

        void Awake()
        {
            savingSystem = GetComponent<SavingSystem>();

            var gameSaver = Static.GetInstancesOfImplementingType<IGameSaver>();
            foreach(var saver in gameSaver)
                saver.OnGameSave += Save;

            var gameLoader = Static.GetInstancesOfImplementingType<IGameLoader>();
            foreach(var loader in gameLoader)
                loader.OnGameLoad += Load;
        }

        void Load()
        {
            savingSystem.Load(SAVE_FILE);
        }

        void Save()
        {
            savingSystem.Save(SAVE_FILE);
        }

        void Delete()
        {
            savingSystem.Delete(SAVE_FILE);
        }
        
        void OnDestroy()
        {
            Delete();
        }
    }
}