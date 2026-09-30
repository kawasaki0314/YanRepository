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

   private bool isPush = false;
    public void OnClicked()
    {

        if (movieObject != null)
        {
            movieObject.SetActive(true);
        }

        if (videoPlayer != null)
        {
            videoPlayer.Play();

        }
        isPush = !isPush;

        FirstCamera.SetActive(isPush);
        SecondCamera.SetActive(!isPush);

        if (isfvid)
        {

        }

        SceneManager.LoadScene("HiraScene");

    }

    public void PlayVideo()
    {
        
        
    }





}
