using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextItem : Item,IColorFocusable,ITextSettings
{
    [SerializeField]
    private TextMeshPro textMesh;

    public override void Start()
    {
        base.Start();
    }

    [EasyButtons.Button]
  
    public override GameObject GetCurrentFocusableObject()
    {
        return gameObject;
    }

    public override Transform GetCurrentFocusedTransform()
    {
        return transform;
    }

    public override Vector3 GetCurrentRGBFocusable()
    {
        return new Vector3(textMesh.color.r, textMesh.color.g, textMesh.color.b);
    }

    public override string GetfocusableTextureName()
    {
        return "";
    }

    public override ObjectType GetFocusableType()
    {
        return ObjectType;
    }

    public override void Init()
    {
        ObjectType = ObjectType.Text;
    }

    public void OnColorChanged(Color color)
    {
        textMesh.color=color;
    }

    public void SetTextValue(string value)
    {
        textMesh.text = value;
    }

    public void SetFontText(TMP_FontAsset font)
    {
       textMesh.font=font;
    }

    public string GetTextValue()
    {
        return textMesh.text;
    }
    [EasyButtons.Button]
    public string GetFontName()
    {
        print(textMesh.font.name);
       return textMesh.font.name;
    }

    public override string GetFocusableTextValue()
    {
        return GetTextValue();
    }

    public override string GetFocusableFontName()
    {
        return GetFontName();
    }
}
