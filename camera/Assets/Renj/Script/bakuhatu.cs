using UnityEngine;
using System.Collections;

public class bakuhatu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shotSE;
    public float stop = 0.2f; // 再生してから止めるまでの秒数

    public void PlayShortSound()
    {
        StartCoroutine(PlayAndStopRoutine());
    }

    private IEnumerator PlayAndStopRoutine()
    {
        audioSource.clip = shotSE;
        audioSource.Play();

        // 指定した秒数だけ待つ
        yield return new WaitForSeconds(stop);

        // 音を停止
        audioSource.Stop();
    }
}
