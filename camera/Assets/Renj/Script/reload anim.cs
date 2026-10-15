using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine;

public class reloadanim : MonoBehaviour
{
    public GameObject Gun;
    [SerializeField] float reloadAnim = 360f;
    bool isreloding;
    float rAngle = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame && !isreloding)
        {
            isreloding = true;
            rAngle = 0f;
        }
        if (isreloding)
            {
            float spin = reloadAnim * Time.deltaTime;
            if(rAngle + spin>=360)
            {

                Gun.transform.Rotate(Vector3.right, 360f-rAngle,Space.Self );

                isreloding = false;
            }
            else
            {
               
                Gun.transform.Rotate(Vector3.right, spin, Space.Self);
                rAngle += spin;
            }
                    
                
            }
    }
}
