
[System.Serializable]

public class ClassAlert 
{
    public EnumAlert state;
    public string textInformation;

    public ClassAlert(EnumAlert state, string textInformation)
    {
        this.state = state;
        this.textInformation = textInformation;
    }
}
