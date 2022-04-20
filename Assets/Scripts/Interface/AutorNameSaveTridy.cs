using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutorNameSaveTridy : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;




    public void TextAutor() {
        text.text = $"Autor: {UserData.Instance.PlayerData.data.name}";
    }
}
