using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Core;

public class TextKeeper : MonoBehaviour
{
    public TextMeshProUGUI Text { get; set; }
    [SerializeField] private IndexWord indexWord;
    public IndexWord IndexWord => indexWord;



    private void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
}
