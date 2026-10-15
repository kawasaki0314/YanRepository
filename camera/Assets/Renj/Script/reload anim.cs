using UnityEngine;
using UnityEngine.InputSystem;

public class reloadanim : MonoBehaviour
{
    public GameObject Gun;
    [Tooltip("回転速度（度/秒）※360なら1秒で1回転、720なら0.5秒")]
    [SerializeField] float reloadSpeed = 360f;

    private Recoil recoil;
    private bool isReloading;
    float rAngle = 0f;
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

                transform.Rotate(Vector3.right, 360f - rAngle, Space.Self);
                rAngle = 0f;

                isReloading = false;
            }
            else
            {

                transform.Rotate(Vector3.right, spin, Space.Self);
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
    public bool IsReloading => isReloading;
}
