using System;
using UnityEngine;

[Serializable]
public class SavedMeshes

{
    public int Id;
    public ObjectType ObjectType;
    public SerilizedVector Position;
    public SerilizedVector Rotation;
    public SerilizedVector Scale;
    public SerilizedVector Color;
    public string TextureName;
    public string TextValue;
    public string FontName;

    public SavedMeshes(int id, ObjectType objectType, SerilizedVector pos, SerilizedVector rot, SerilizedVector scale,SerilizedVector color,string textureName,string textValue,string fontName)
    {
        Id = id;
        ObjectType = objectType;
        Position = pos;
        Rotation = rot;
        Scale = scale;
        Color = color;
        TextureName = textureName;
        TextValue = textValue;
        FontName = fontName;
    }
}
