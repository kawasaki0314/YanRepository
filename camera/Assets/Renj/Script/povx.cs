using UnityEngine;

public class povx : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2.0f; 
    [SerializeField] private float minPov = -90.0f; 
    [SerializeField] private float maxPov = 90.0f; 

    private float rotationX = 0f;

    void Start()
    {
       
        Vector3 firstAngle = transform.localEulerAngles;
        rotationX = (firstAngle.x > 180f) ? firstAngle.x - 360f : firstAngle.x;
    }

    void Update()
    {
        // マウスの縦移動量を取得
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // 縦方向の角度を計算して制限
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minPov, maxPov);

        // このオブジェクト自身を縦方向に回転させる
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
