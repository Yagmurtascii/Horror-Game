using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class CrossHairController : MonoBehaviour
{
    public Camera playerCamera; // Oyuncu kameranýzý atayýn
    public Text text;
    private List<GameObject> lamps = new List<GameObject>();
    public Light[] lights;
    public bool isActiveDoor = false;
    public bool isOpen = false;
    [SerializeField]
    private Animator doorAnimator;
    public float distance=0f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Fare týklamasý algýlandýðýnda
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // Crosshair'ýn ortasýndan bir ýþýn çiz

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // Eðer ýþýn bir þeye çarparsa
            {
                GameObject obj = hit.collider.gameObject; // Çarpýlan objeyi al
                text.text = obj.tag;

                Debug.Log("Baktýðýnýz obje: " + obj.name);
                 distance = Vector3.Distance(obj.transform.position, gameObject.transform.position);
                if (obj.tag == "Door" && distance<20f)
                {
                    isActiveDoor = true;
                    
                    doorAnimator = obj.GetComponent<Animator>();
                    if (isActiveDoor && !isOpen)
                    {
                        obj.GetComponent<BoxCollider>().isTrigger = true;
                        doorAnimator.SetBool("isOpen", true);
                        isOpen = true;
                    }
                    else if (isActiveDoor && isOpen) {

                        obj.GetComponent<BoxCollider>().isTrigger = false;
                        doorAnimator.SetBool("isOpen", false);
                        isOpen = false;
                    }
                   
                }
            }

        }
    }
 
}

