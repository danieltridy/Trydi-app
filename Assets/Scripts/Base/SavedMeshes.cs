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

    public SavedMeshes(int id, ObjectType objectType, SerilizedVector pos, SerilizedVector rot, SerilizedVector scale,SerilizedVector color,string textureName)
    {
        Id = id;
        ObjectType = objectType;
        Position = pos;
        Rotation = rot;
        Scale = scale;
        Color = color;
        TextureName = textureName;
    }
}
