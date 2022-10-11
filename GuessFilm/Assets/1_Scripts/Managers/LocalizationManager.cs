using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    [CreateAssetMenu(fileName = "SCRO_LocalizationManager", menuName = "Architecture/SCRO_SceneManagers/SCRO_LocalizationManager")]

    public class LocalizationManager : BaseManager
    {

        private Language language = new Language(TypeLanguage.Russian);

        public void OnStart(GameObject gameObject)
        {
            SetLanguage(gameObject);
        }
        public void SetLanguage(GameObject gameObject)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = language.GetWord(IndexWord.StartButton);
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
        Films,
        Serials,
        Cartoons
    }
    //доставка перевода в тексты 
    //Удобный метод получения текстов
    //Переменовать a0, a1, a2....
    // **если получится** вынести словари в файлы;
    // GameObject.FindObjectsOfType<> ПРИГОДИТСЯ
    public class Language
    {
        private TypeLanguage currentLanguage;
        public Language(TypeLanguage typeLanguage)
        {
            currentLanguage = typeLanguage;
        }

        Dictionary<TypeLanguage, Dictionary<IndexWord, string>> words = new Dictionary<TypeLanguage, Dictionary<IndexWord, string>>()
        {
            [TypeLanguage.English] =
            {
                [IndexWord.StartButton] = "Start",
                [IndexWord.SettingButton] = "Setting",
            },

            [TypeLanguage.Russian] =
            {
                [IndexWord.StartButton] = "Старт",
                [IndexWord.SettingButton] = "Настройки",
            }
        };

        public string GetWord(IndexWord indexWord)
        {
            var localizationDictionary = words[currentLanguage];
            return localizationDictionary[indexWord];
        }
    }
}
