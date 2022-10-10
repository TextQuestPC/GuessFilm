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
            gameObject.GetComponent<TextMeshProUGUI>().text = language.GetWord(IndexWord.a0);
        }
    }
    public enum TypeLanguage
    {
        English,
        Russian
    }
    public enum IndexWord
    {
        a0,
        a1,
        a2,
        a3,
        a4,
        a5,
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
                [IndexWord.a0] = "Start",
                [IndexWord.a1] = "Report",
            },

            [TypeLanguage.Russian] =
            {
                [IndexWord.a0] = "Старт",
                [IndexWord.a1] = "Сообщить",
            }
        };

        public string GetWord(IndexWord indexWord)
        {
            var localizationDictionary = words[currentLanguage];
            return localizationDictionary[indexWord];
        }
    }
}
