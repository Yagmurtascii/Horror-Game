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
        if(crosshairController.isRemoteControllerTaken==true)
        {
            gameObjects[0].SetActive(true);
        }
        if(crosshairController.isKeyTaken == true)
            gameObjects[1].SetActive(true);


        if (Input.GetKeyUp(KeyCode.Space) && !isPanelOpen)
        {
            ManageOpenInventory();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && isPanelOpen)
        {
            ManageCloseInventory();
        }
    }

    private void ManageOpenInventory()
    {
        panel.SetActive(true);
   

        isPanelOpen = true;
    }

    private void ManageCloseInventory()
    {
        panel.SetActive(false);
        
        isPanelOpen = false;
    }
}
