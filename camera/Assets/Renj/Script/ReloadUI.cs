using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReloadUI : MonoBehaviour
{
    [Header("参照")]
    [Tooltip("PlayerShootスクリプトを持つオブジェクト")]
    public PlayerShoot playerShoot;

    [Header("UIパーツ（常時表示）")]
    [Tooltip("残弾数を表示するTextMeshPro (例: 30 / 30)")]
    public TextMeshProUGUI ammoText;

    [Header("リロードバー")]
    [Tooltip("棒状ゲージの親オブジェクト（リロード中だけ表示させたい場合。常時表示なら空でOK）")]
    public GameObject barRoot;

    [Tooltip("Filled (Horizontal) に設定したImage")]
    public Image reloadBarFill;

    [Tooltip("「RELOADING...」などのテキスト（省略可）")]
    public TextMeshProUGUI statusText;

    private float timer = 0f;

    void Start()
    {
        // バー自体をリロード中だけ出したい場合の設定（不要ならコメントアウト）
        if (barRoot != null)
        {
            barRoot.SetActive(false);
        }
    }

    void Update()
    {
        if (playerShoot == null) return;

        // ==========================================
        // 1. 残弾数を常時更新
        // ==========================================
        if (ammoText != null)
        {
            ammoText.text = $"{playerShoot.currentAmmo} / {playerShoot.magazineSize}";
        }

        // ==========================================
        // 2. リロード時の棒ゲージ更新
        // ==========================================
        if (playerShoot.IsReloadingNow)
        {
            // リロード中：バーを表示
            if (barRoot != null && !barRoot.activeSelf)
            {
                barRoot.SetActive(true);
            }

            if (statusText != null)
            {
                statusText.text = "RELOADING...";
            }

            // 0.0 ～ 1.0 に向かってゲージを伸ばす
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / playerShoot.reloadTime);

            if (reloadBarFill != null)
            {
                reloadBarFill.fillAmount = progress;
            }
        }
        else
        {
            // 通常時：ゲージをリセット
            timer = 0f;

            if (reloadBarFill != null)
            {
                reloadBarFill.fillAmount = 0f;
            }

            if (statusText != null)
            {
                statusText.text = "";
            }

            // リロード完了時にバーを隠す場合
            if (barRoot != null && barRoot.activeSelf)
            {
                barRoot.SetActive(false);
            }
        }
    }
}