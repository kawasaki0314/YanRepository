using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SettingButton : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void settings()
    {
        //if(settingsPanel != null)
        //{
        //    settingsPanel.SetActive(!settingsPanel.activeSelf);
        //}
        if (settingsPanel == null) { return; }
        
            bool isOpening = !settingsPanel.activeSelf;
        settingsPanel.SetActive(isOpening);
        Time.timeScale = isOpening ? 0f : 1f;
        Cursor.visible = isOpening;
        Cursor.lockState = isOpening ? CursorLockMode.None : CursorLockMode.Locked;
    

}
   

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            settings();
        }
    }
}
