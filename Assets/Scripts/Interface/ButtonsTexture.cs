
using UnityEngine;
using UnityEngine.UI;

public class ButtonsTexture : MonoBehaviour
{
    public Image Icon;
    public Texture Texture;
    public Button Button;

    private void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(ChangeTexture);
    }

    private void ChangeTexture()
    {
        TouchInput.Instance.OnTexture(Texture);
    }
}
