using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class reloadanim : MonoBehaviour
{
    public GameObject Gun;
    [Tooltip("回転速度（度/秒）※360なら1秒で1回転、720なら0.5秒")]
    [SerializeField] float reloadSpeed = 360f;

    [Header("キャッチ時の揺れ設定")]
    [Tooltip("揺れる時間（秒）")]
    [SerializeField] private float shakeR = 0.12f;
    [Tooltip("位置の揺れの強さ（")]
    [SerializeField] private float shakePosM = 0.15f;
    [Tooltip("角度（手首の反動）の強さ（度）")]
    [SerializeField] private float shakeRotM = 6.0f;
    //  [SerializeField]  ;

    private Recoil recoil;
    private bool isReloading;
    float rAngle = 0f;

    private Vector3 initialLocalPos;
    private Quaternion initialLocalRot;
    private Coroutine shakeCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    if (Gun != null)
    //    {
    //        recoil = Gun.GetComponent<Recoil>();
    //    }
    //    else
    //    {
    //        recoil = GetComponent<Recoil>();

    //    }
    //}
    void Awake()
    {
        // 基準となる初期位置を記録
        initialLocalPos = transform.localPosition;
        initialLocalRot = transform.localRotation;
    }
    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.rKey.wasPressedThisFrame && !isReloading)
        //{
        //    StartReload();
        //}
        if (isReloading)
            {
            float spin = reloadSpeed * Time.deltaTime;
           // rAngle += spin;
            if (rAngle + spin >= 360)
            {

                transform.Rotate(Vector3.left, 360f - rAngle, Space.Self);
                rAngle = 0f;

                isReloading = false;
                TriggerCatchShake();
            }
            else
            {

                transform.Rotate(Vector3.left, spin, Space.Self);
                rAngle += spin;
            }
            //if (rAngle >= 360f)
            //{
            //    rAngle = 0f;
            //    isReloading = false;
            //}

            //// Recoil側に現在の回転角度（X軸の縦回転）を渡す
            //if (recoil != null)
            //{
            //    recoil.reloadRotation = Quaternion.Euler(rAngle, 0f, 0f);
            //}


        }
    }

    public void StartReload()
    {
        if (!isReloading)
        {
            isReloading = true;
            rAngle = 0f;

        }
    }
    private void TriggerCatchShake()
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }
        shakeCoroutine = StartCoroutine(DoCatchShake());
    }

    private IEnumerator DoCatchShake()
    {
        float elapsed = 0f;

        while (elapsed < shakeR)
        {
            float damper = 1.0f - (elapsed / shakeR);

            // 1. 位置のブレ（下・手前方向にグッと引っ張る）
            Vector3 posOffset = new Vector3(
                Random.Range(-0.5f, 0.5f) * shakePosM * 0.3f,
                -Mathf.Abs(Random.Range(0.2f, 1f)) * shakePosM, // 確実に下へ沈める
                -Mathf.Abs(Random.Range(0.2f, 1f)) * shakePosM * 0.5f // 手前へ
            ) * damper;

            // 2. 角度のブレ（銃口が一瞬クイッと跳ね上がる・手首が起きる）
            float pitchOffset = Random.Range(-1f, 1f) * shakeRotM * damper;
            float rollOffset = Random.Range(-0.5f, 0.5f) * (shakeRotM * 0.5f) * damper;

            transform.localPosition = initialLocalPos + posOffset;
            transform.localRotation = initialLocalRot * Quaternion.Euler(pitchOffset, 0f, rollOffset);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = initialLocalPos;
        transform.localRotation = initialLocalRot;
        shakeCoroutine = null;
    }
}
