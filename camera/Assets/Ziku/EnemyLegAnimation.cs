using UnityEngine;

public class EnemyLegAnimation : MonoBehaviour
{
    [Header("6本の足を設定")]
    [SerializeField] private Transform[] legs = new Transform[6];

    [Header("アニメーション設定")]
    [SerializeField] private float angle = 25f;
    [SerializeField] private float frequency = 4f;

    private Quaternion[] initialRotations;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialRotations = new Quaternion[legs.Length];

        for (int i = 0; i < legs.Length; i++)
        {
            if (legs[i] != null)
            {
                initialRotations[i] = legs[i].localRotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < legs.Length; i++)
        {
            if (legs[i] == null) continue;

            // 奇数番目と偶数番目で動くタイミングをずらす
            float phase = (i % 2 == 0) ? 0f : Mathf.PI;

            float movement =
                Mathf.Sin(Time.time * frequency + phase) * angle;

            // 足のローカルX軸を中心に回転
            legs[i].localRotation =
                initialRotations[i] *
                Quaternion.Euler(movement, 0f, 0f);
        }
    }
}
