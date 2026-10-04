using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject FirstCamera;
    public GameObject SecondCamera;

    public GameObject movieObject;
    public VideoPlayer videoPlayer;
    bool isfvid;

    bool isPush = false;

    bool isVideoPlaying = false;

    bool isSkipPush = false;
    int holdTime = 0;
    public void OnClicked()
    {

        if (movieObject != null)
        {
            movieObject.SetActive(true);
            videoPlayer.loopPointReached += OnVideoFinished;

        }

        if (videoPlayer != null)
        {
            videoPlayer.Play();
            isVideoPlaying = true;

        }
        isPush = !isPush;

        FirstCamera.SetActive(isPush);
        SecondCamera.SetActive(!isPush);


        if (isfvid)
        {

        }
        void OnVideoFinished(VideoPlayer vp)
        {
            SceneManager.LoadScene("HiraScene");

        }

    }
    void Update()
    {
        if (isVideoPlaying && Input.GetKey(KeyCode.Space))
        {
            holdTime++;
            if (holdTime >= 60) // Adjust the hold time as needed
            {
                videoPlayer.Stop();
                SceneManager.LoadScene("HiraScene");
            }
        }
    }

    public void PlayVideo()
    {
        
        
    }





}
