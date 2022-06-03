using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTexture : MonoBehaviour
{
    [SerializeField]
    private Material material;


    public void SetTextureMaterialBasic(Texture texture) {
        material.mainTexture = texture;
    }

}
