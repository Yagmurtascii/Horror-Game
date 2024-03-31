using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class CrossHairController : MonoBehaviour
{
    public Camera playerCamera; // Oyuncu kameran�z� atay�n
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
        if (Input.GetMouseButtonDown(0)) // Fare t�klamas� alg�land���nda
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // Crosshair'�n ortas�ndan bir ���n �iz

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // E�er ���n bir �eye �arparsa
            {
                GameObject obj = hit.collider.gameObject; // �arp�lan objeyi al
                text.text = obj.tag;

                Debug.Log("Bakt���n�z obje: " + obj.name);
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

