[System.Serializable]
public class ClassnNotification
{
    public EnumNotification state; 
    public string textInformation;
    public string title;

    public ClassnNotification(EnumNotification state, string textInformation)
    {
        this.state = state;
        this.textInformation = textInformation;
    }
}
