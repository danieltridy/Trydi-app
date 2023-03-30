using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UbicationButtosTexture : MonoBehaviour
{
    [SerializeField]
    ButtonsTexture buttonsTexture;

    [SerializeField]
    private int num;


    [ContextMenu("Fill Content")]
    private void Reset()
    {
        foreach (Transform button in transform)
        {
            DestroyImmediate(button.gameObject);
        }
        for (int i = 1; i <= num; i++)
        {
            ButtonsTexture buttonsTextureNew = Instantiate(buttonsTexture, Vector3.zero, Quaternion.identity, transform);
            buttonsTextureNew.Icon.sprite = Resources.Load<Sprite>($"Textures/{i}");
            buttonsTextureNew.Texture = Resources.Load<Texture>($"Textures/{i}T");
        }
    }
}
