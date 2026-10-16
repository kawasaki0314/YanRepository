//using UnityEngine;
//using UnityEngine.UI;
//using TMPro; // TextMeshProを使う場合

//public class ReloadUI : MonoBehaviour
//{
//    [Header("参照")]
//    [Tooltip("PlayerShootスクリプトがアタッチされたオブジェクト")]
//    public PlayerShoot playerShoot;

//    [Header("UIパーツ")]
//    [Tooltip("リロード中に表示する親パネルやオブジェクト")]
//    public GameObject reloadUIRoot;

//    [Tooltip("Filled設定にしたゲージ用Image")]
//    public Image reloadGauge;

//    [Tooltip("リロードテキスト（省略可）")]
//    public TextMeshProUGUI reloadText;

//    private float timer = 0f;

//    void Start()
//    {
//        // 開始時は非表示にしておく
//        if (reloadUIRoot != null)
//        {
//            reloadUIRoot.SetActive(false);
//        }
//    }

//    void Update()
//    {
//        if (playerShoot == null) return;

//        // PlayerShoot側のリロード状態を確認
//        if (playerShoot.IsReloadingNow)
//        {
//            // 非表示なら表示する
//            if (reloadUIRoot != null && !reloadUIRoot.activeSelf)
//            {
//                reloadUIRoot.SetActive(true);
//                timer = 0f;
//            }

//            // タイマーを進めてゲージを満たす (0.0 ～ 1.0)
//            timer += Time.deltaTime;
//            float progress = Mathf.Clamp01(timer / playerShoot.reloadTime);

//            if (reloadGauge != null)
//            {
//                reloadGauge.fillAmount = progress;
//            }
//        }
//        else
//        {
//            // リロードが終わったらUIを非表示に戻す
//            if (reloadUIRoot != null && reloadUIRoot.activeSelf)
//            {
//                reloadUIRoot.SetActive(false);
//                timer = 0f;
//            }
//        }
//    }
//}
using UnityEngine;
using UnityEngine.UI;

public class ReloadUI : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public Image reloadGauge;

    private float timer = 0f;

    void Update()
    {
        if (playerShoot == null) return;

        // リロード中だけゲージを増やす
        if (playerShoot.IsReloadingNow)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / playerShoot.reloadTime);

            if (reloadGauge != null)
            {
                reloadGauge.fillAmount = progress;
            }
        }
        else
        {
            // リロードしていないときはゲージを0にして待機（UI自体は消さない）
            timer = 0f;
            if (reloadGauge != null)
            {
                reloadGauge.fillAmount = 0f;
            }
        }
    }
}