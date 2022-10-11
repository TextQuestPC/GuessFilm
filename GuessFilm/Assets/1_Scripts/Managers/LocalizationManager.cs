using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    [CreateAssetMenu(fileName = "SCRO_LocalizationManager", menuName = "Architecture/SCRO_SceneManagers/SCRO_LocalizationManager")]

    public class LocalizationManager : BaseManager
    {
        private Language activeLanguage;
        [SerializeField] private Dictionary<TypeLanguage,TextAsset> languageDictionaries;
        public void OnStart(TextKeeper[] textKeepers)
        {
            activeLanguage = new Language(TypeLanguage.Russian);
            SetLanguage(textKeepers);
        }
        public void SetLanguage(TextKeeper[] textKeepers)
        {
            foreach (var textKeeper in textKeepers)
            {
                var translation = activeLanguage.GetWord(textKeeper.IndexWord);
                textKeeper.Text.SetText(translation);
            }
        }
    }
    public enum TypeLanguage
    {
        English,
        Russian
    }
    public enum IndexWord
    {
        StartButton,
        SettingButton,
    }
    public class Language
    {
        private TypeLanguage currentLanguage;
        public Language(TypeLanguage typeLanguage)
        {
            currentLanguage = typeLanguage;
        }

        Dictionary<TypeLanguage, Dictionary<IndexWord, string>> words = new Dictionary<TypeLanguage, Dictionary<IndexWord, string>>()
        {

            { TypeLanguage.Russian,
                new Dictionary<IndexWord, string>(){
                    { IndexWord.StartButton, "Старт" },
                    { IndexWord.SettingButton, "Настройки" }
                }
            },

            {TypeLanguage.English,
                new Dictionary<IndexWord, string>(){
                    { IndexWord.StartButton, "Start" },
                    { IndexWord.SettingButton, "Setting" }
                }
            }
        };


        public string GetWord(IndexWord indexWord)
        {
            var localizationDictionary = words[currentLanguage];
            return localizationDictionary[indexWord];
        }
    }
}
