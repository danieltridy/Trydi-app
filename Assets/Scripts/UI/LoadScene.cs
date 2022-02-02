using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static LoadScene Instance = null;
    [SerializeField]
    private DevicePermissions devicePermissions;
    [SerializeField]
    private Image progresBar;
    private bool autorization;
    private int idScene =1;

    public int IdScene { get => idScene; set => idScene = value; }

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronosly(idScene));

    }
    public void LoadLevel(int id)
    {
        StartCoroutine(LoadAsynchronosly(id));
    }

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
     
    private bool CanOpen()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        print("devicePermissions.isGPSLocationServiceEnabled(): " + devicePermissions.isGPSLocationServiceEnabled());
        return devicePermissions.isGPSLocationServiceEnabled();
#endif
#if UNITY_IOS || UNITY_EDITOR
        return false;
#endif
    }

    [EasyButtons.Button]
    private void Debugload()
    {
        StartCoroutine(LoadAsynchronosly(1));
    }
    IEnumerator LoadAsynchronosly(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone && !CanOpen())
        {
            float progres = Mathf.Clamp01(operation.progress / .9f);
            progresBar.fillAmount = progres;
            yield return null;
        }
    }
}
