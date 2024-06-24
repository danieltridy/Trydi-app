using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface ITextSettings 
{
    public void SetTextValue(string value);
    public void SetFontText(TMP_FontAsset font);

    public string GetTextValue();

    public string GetFontName();
}
