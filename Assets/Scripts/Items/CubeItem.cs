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

    public override void Start()
    {
        base.Start();
        cubeRenderer = GetComponent<Renderer>();
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
    }

    public override Item GetCurrentFocusableReference()
    {
        return this;
    }
}
