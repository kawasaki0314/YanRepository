using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine;

public class reloadanim : MonoBehaviour
{
    public GameObject Gun;
    [SerializeField] float reloadAnim = 360f;
    bool isreloding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame &&isreloding)
        {
            isreloding = true;
        }
        if (isreloding)
            {
               
                    transform.Rotate(Vector3.right, reloadAnim * Time.deltaTime);
                
            }
    }
}
