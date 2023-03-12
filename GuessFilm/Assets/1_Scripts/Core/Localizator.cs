using Data;
using System.Collections.Generic;
using UnityEngine;

public class Localizator : Singleton<Localizator>
{
    [SerializeField] private TypeLanguage language;

    private bool isLoad;

    private Dictionary<string, string[]> dataUI = new Dictionary<string, string[]>();
    private const string FILE_NAME_UI = "UI";

    public TypeLanguage SetLanguage { set => language = value; }

    protected override void AfterAwaik()
    {
        LoadData();
    }

#region GET_TEXT

    public string GetTextUI(string idText)
    {
        return GetText(dataUI, idText);
    }    

    private string GetText(Dictionary<string, string[]> dictionary, string idText)
    {
        string[] textsById = null;
        string needText = "";

        dictionary.TryGetValue(idText, out textsById);

        if (textsById == null)
        {
            Debug.Log($"<color=red>Не найден текст в {dictionary} с id '{idText}' !</color>");
        }
        else
        {
            needText = textsById[(int)language];
        }

        if (needText == "")
        {
            Debug.Log($"<color=yellow>Текст в {dictionary} с id '{idText}', с языком {0} пустой!</color>");
        }

        return needText;
    }

#endregion GET_TEXT

#region LOAD_DATA_TEXTS

    private void LoadData()
    {
        if (isLoad)
        {
            return;
        }
        LoadData(FILE_NAME_UI, dataUI);

        isLoad = true;
    }

    private void LoadData(string fileName, Dictionary<string, string[]> dataDictionary)
    {
        TextAsset textAsset = Resources.Load("Localization/" + fileName.ToString()) as TextAsset;

        if (textAsset == null)
        {
            Debug.Log($"<color=red>Не удалось найти txt {fileName} в папке Resources!</color>");
        }

        List<string> splitText = new List<string>(textAsset.text.Split('\n'));

        for (int i = 0; i < splitText.Count; i++)
        {
            List<string> addTexts = new List<string>(splitText[i].Split(';'));
            string[] textLanguages = new string[2] { addTexts[1], addTexts[2] };

            dataDictionary.Add(addTexts[0], textLanguages);
        }
    }

#endregion LOAD_DATA_TEXTS
}