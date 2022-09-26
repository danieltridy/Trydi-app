using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TridyEditor : MonoBehaviour
{
    [Header("General Settings")]
    public Camera Camera;
    public bool EnableMovement;
    public bool EnableScale;
    public bool EnableScaleFace;
    public bool EnableRotation;

    [Header("Pinch Scale Settings")]
    public float MinScaleValue;
    public float MaxScaleValue;
    public float PinchSpeed;
    [HideInInspector]
    public float ScaleValue;
    [Header("Rotation Settings")]
    public float RotationSpeed;
    [Header("Movement Settings")]
    public float MovementTolerance;

    [Header("Apparance Settings (For Debug can Delete if you Want)")] // TODO: Borrar es solo para Pruebas
    [SerializeField]
    private Color colorDebug;
    [SerializeField]
    private Texture textureDebug;
    [SerializeField]
    private string debugValue;
    [SerializeField]
    private List<TMP_FontAsset> fonts;


    private  IFocusable focusable;
    private GameObject currentGameObject;
    
    public GameObject CurrentGameObject { get => currentGameObject; set => currentGameObject = value; }
    public IFocusable Focusable { get => focusable; set => focusable = value; }
    public Color ColorDebug { get => colorDebug; set => colorDebug = value; }
    public Texture TextureDebug { get => textureDebug; set => textureDebug = value; }
    private int i=0;
    public virtual Vector3 GetInputWorldPos()
    {
        return Vector3.zero;
    }

    #region Methods
   
    public abstract void Init();

    public void UpdateFocusableColor(Color color)
    {
        if (!ImpelementColorInterface())
            return;

        currentGameObject.GetComponent<IColorFocusable>().OnColorChanged(color);
    }
    public void UpdateFocusableMaterial(Texture texture)
    {
        if (!ImplementMaterialInterface())
            return; 

        currentGameObject.GetComponent<IMaterialFocusable>().OnTextureChanged(texture);
    }

    public void UpdateTextValue(string Text)
    {
        if (!ImplementTextInterface())
            return;
        currentGameObject.GetComponent<ITextSettings>().SetTextValue(Text);
    }

    public void UpdateTextFont(TMP_FontAsset font)
    {
        if (!ImplementTextInterface())
            return;
        currentGameObject.GetComponent<ITextSettings>().SetFontText(font);
    }
    public bool ImpelementColorInterface()
    {
        if (currentGameObject.GetComponent<IColorFocusable>() != null)
            return true;

        return false;
    }
    public  bool ImplementMaterialInterface()
    {
        if (currentGameObject.GetComponent<IMaterialFocusable>() != null)
            return true;

        return false;
    }

    public bool ImplementTextInterface()
    {
        if (currentGameObject.GetComponent<ITextSettings>() != null)
            return true;

        return false;
    }

    #endregion

    #region Debugs Methods
    ///Can be Deleted if you want
    [EasyButtons.Button]
    public void OnColorDebug()
    {
        UpdateFocusableColor(colorDebug);
    }
    [EasyButtons.Button]
    public void OnTextureDebug()
    {
        UpdateFocusableMaterial(textureDebug);
    }
    [EasyButtons.Button]
    public void OnTextChanged(string text)
    {
        UpdateTextValue(text);
    }
    [EasyButtons.Button]
    public void OnTextFontChanged()
    {

        TMP_FontAsset font = fonts[i];
        UpdateTextFont(font);

        if (i == (fonts.Count - 1))
        {
            i = 0;
        }
        else {
            i++;
        }
    }
    #endregion
}
