

using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.UI;

public class MyVideoPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject btnPlay;
    [SerializeField]
    private GameObject btnPause;
    [SerializeField]
    private Slider slider;
    private bool videoIsPlaying = false;
    public VideoPlayer videoPlayer;

    
    private void Update()
    {
        if (videoIsPlaying == true)
        {
            slider.value = (float)videoPlayer.time / (float)videoPlayer.length;
        }
    }

    public void NextandBackVideo()
    {
        videoPlayer.Pause();
        videoIsPlaying = false;
        if (videoIsPlaying == false)
        {
            videoPlayer.time = slider.value * videoPlayer.length;
        }
    }
  
    public void VideoStop()
    {
        videoIsPlaying = false;
        videoPlayer.Pause();
        btnPause.SetActive(false);
        btnPlay.SetActive(true);
    }

    public void VideoPlay()
    {
        videoIsPlaying = true;
        videoPlayer.Play();
        btnPause.SetActive(true);
        btnPlay.SetActive(false);
    }
}
