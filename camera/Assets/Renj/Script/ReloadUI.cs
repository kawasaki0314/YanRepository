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

    [Header("最後の1発（爆弾弾）演出")]
    [Tooltip("通常時のテキスト色")]
    public Color normalAmmoColor = Color.white;

    [Tooltip("爆弾（残り1発）時のテキスト色（例: 赤やオレンジ）")]
    public Color bombAmmoColor = Color.red;

    [Tooltip("（任意）爆弾アイコンの画像パーツ（使う場合はセット）")]
    public GameObject bombIcon;

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
        // バー自体をリロード中だけ出したい場合の設定
        if (barRoot != null)
        {
            barRoot.SetActive(false);
        }

        if (bombIcon != null)
        {
            bombIcon.SetActive(false);
        }
    }

    void Update()
    {
        if (playerShoot == null) return;

        // ==========================================
        // 1. 残弾数を常時更新 & 最後の1発チェック
        // ==========================================
        if (ammoText != null)
        {
            // 残り1発（爆弾）かどうか
            bool isLastBomb = (playerShoot.currentAmmo == 1);

            if (isLastBomb)
            {
                // ★最後の一発：爆弾表記（絵文字の💣や [BOMB] に変更）
                ammoText.text = $"💣 / {playerShoot.magazineSize}";
                ammoText.color = bombAmmoColor;
            }
            else
            {
                // 通常時：通常の数字表示
                ammoText.text = $"{playerShoot.currentAmmo} / {playerShoot.magazineSize}";
                ammoText.color = normalAmmoColor;
            }

            // 爆弾アイコンのGameObjectがある場合はON/OFFを連動
            if (bombIcon != null)
            {
                bombIcon.SetActive(isLastBomb);
            }
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