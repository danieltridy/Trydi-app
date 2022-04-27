using UnityEngine;

public class CubeItem : Item,IColorFocusable,IMaterialFocusable
{
    [SerializeField]
    private string colorParametter ="_Color";
    [SerializeField]
    private string textureParametter = "Albedo";

    private Renderer cubeRenderer ;
    
    public override Transform GetCurrentFocusedTransform()
    {
        return transform;
    }
    private void Awake()
    {
        cubeRenderer = GetComponent<Renderer>();
    }
    public override void Start()
    {
        base.Start();
       
    }

    public override double GetCurrentDistance()
    {
        return base.GetCurrentDistance();
    }

    public void OnColorChanged(Color color)
    {
        // cambiamos el color del material
        cubeRenderer.material.SetColor(colorParametter, color);

    }

    public void OnTextureChanged(Texture newTexture)
    {
        //cambiamos la textura
        cubeRenderer.material.mainTexture=newTexture;
        print(newTexture.name);
    }

    public override GameObject GetCurrentFocusableObject()
    {
        return gameObject;
    }

    public override Vector3 GetCurrentRGBFocusable()
    {
        Color currentColor = cubeRenderer.material.GetColor(colorParametter);
       return new Vector3(currentColor.r,currentColor.g,currentColor.b);
    }

    public override string GetfocusableTextureName()
    {
        Texture currentTexture = cubeRenderer.material.mainTexture;
        if (currentTexture)
            return currentTexture.name;
        else
            return "";
    }

    public override void Init()
    {
        ObjectType = ObjectType.Cube;
    }

    public override ObjectType GetFocusableType()
    {
       return ObjectType;
    }

    public override string GetFocusableTextValue()
    {
        return "";
    }

    public override string GetFocusableFontName()
    {
        return "";
    }
}
