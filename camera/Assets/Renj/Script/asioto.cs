using UnityEngine;

public class asioto : MonoBehaviour
{
   
    [SerializeField] private AudioClip footstepClip;
    [SerializeField] private float stepInterval = 0.5f;
    [SerializeField] private float movementThreshold = 0.05f;
    private AudioSource audioSource;
    private Vector3 lastPosition;
    private float stepTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;
    }
    public void PlayStep()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);
        float currentSpeed = distanceMoved / Time.deltaTime;

        // 一定以上の速度で移動している場合のみタイマーを進める
        if (currentSpeed > movementThreshold)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                PlaySound();
                stepTimer = 0f;
            }
        }
        else
        {
            // 立ち止まったらタイマーをリセット（歩き出しですぐ鳴らしたい場合はそのまま残しても可）
            stepTimer = 0f;
        }

        lastPosition = transform.position;
    }
    void PlaySound()
    {
        if (footstepClip == null) return;

        // ピッチをわずかに揺らして機械的な連打感をなくす
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(footstepClip);
    }
}
