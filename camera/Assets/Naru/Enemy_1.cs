using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    // 追加: 爆発エフェクトのPrefab(InspectorでFX_Fire系のPrefabを設定する)
    [SerializeField] private GameObject _explosionEffectPrefab;

    // 追加: エフェクトを自動削除するまでの時間(秒)。炎はループするので必ず消す
    [SerializeField] private float _effectLifetime = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);

        // 追加: Bulletに当たったときだけ、敵の位置に爆発エフェクトを生成する
        if (collision.gameObject.tag == "Bullet" && _explosionEffectPrefab != null)
        {
            GameObject effect = Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);

            // 追加: 一定時間後にエフェクトを削除する
            Destroy(effect, _effectLifetime);
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}