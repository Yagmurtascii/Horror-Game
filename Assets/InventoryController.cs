using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects; // 0 panel içerir
    [SerializeField] private GameObject panel; // 0 panel içerir
    [SerializeField] private bool isPanelOpen = false;
    [SerializeField] private CrossHairController crosshairController;
    public float count = 0;


    void Update()
    {
        if(crosshairController.objects!=null)
        {
         
            for(int i = 0;i<crosshairController.objects.Count;i++)
            {
                gameObjects[i].SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.E) && !isPanelOpen)
        {
            ManageOpenInventory();
        }
        else if (Input.GetKeyUp(KeyCode.E) && isPanelOpen)
        {
            ManageCloseInventory();
        }
    }

    private void ManageOpenInventory()
    {
        panel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPanelOpen = true;
    }

    private void ManageCloseInventory()
    {
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPanelOpen = false;
    }
}
