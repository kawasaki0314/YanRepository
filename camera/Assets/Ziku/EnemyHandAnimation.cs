using UnityEngine;

public class EnemyHandAnimation : MonoBehaviour
{
    [System.Serializable]
    private class HeadTarget
    {
        public Transform head;

        // オンにすると、反対方向に動く
        public bool reverseDirection;
    }

    [Header("動かす手")]
    [SerializeField] private HeadTarget[] heads;

    [Header("アニメーション設定")]
    [SerializeField] private float angle = 30f;
    [SerializeField] private float frequency = 2f;

    private Quaternion[] initialRotations;

    private void Start()
    {
        initialRotations = new Quaternion[heads.Length];

        for (int i = 0; i < heads.Length; i++)
        {
            if (heads[i].head != null)
            {
                initialRotations[i] = heads[i].head.localRotation;
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < heads.Length; i++)
        {
            Transform head = heads[i].head;

            if (head == null) continue;

            // 左右に往復する角度を計算
            float movement =
                Mathf.Sin(Time.time * frequency) * angle;

            // 左右のオブジェクトで回転方向を反転
            if (heads[i].reverseDirection)
            {
                movement = -movement;
            }

            // 初期回転を基準に、ローカルY軸で回転
            head.localRotation =
                initialRotations[i] *
                Quaternion.Euler(0f, movement, 0f);
        }
    }
}
