using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class CrossHairController : MonoBehaviour
{
    [Header("Camera")]
    public Camera playerCamera; // Oyuncu kameranýzý atayýn
    public Camera passwordCamera; // Oyuncu kameranýzý atayýn

    [Header("UI")]
    public Text text;
    public GameObject panel;


    public List<GameObject> objects;


    [Header("Boolean/Float")]
    public bool isActiveDoor = false;
    public bool isOpen = false;
    public bool isLightOpen = false;
    public bool ispassword = false;
    public bool isPanel = false;
    public bool isRemoteController = false;
    public float distance = 0f;

    [Header("Animations")]
    [SerializeField]
    private Animator doorAnimator;
    [SerializeField]
    private Animator switchAnimator;


    [Header("Lights")]
    [SerializeField]
    private KeepLights lights;

    [Header("Sounds")]
    [SerializeField]
    private AudioSource doorOpenSource;
    [SerializeField]
    private AudioSource backDoorSoundSource;
    [SerializeField]
    private AudioSource lightSoundSource;
    [SerializeField]
    private AudioSource slidingDoorSource;
    [SerializeField]
    private AudioSource wardobeSource;
    [SerializeField]
    private AudioSource mainDoor;

    public PasswordManage passwordManage;


    public BoxCollider boxCollider;


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
                passwordCamera.enabled = false;
                Debug.Log("Baktýðýnýz obje: " + obj.name);
                distance = Vector3.Distance(obj.transform.position, gameObject.transform.position);
                if (obj.tag == "Door" && distance < 20f)
                {
                    doorAnimator = obj.GetComponent<Animator>();

                    if (!isOpen)
                    {
                        obj.GetComponent<BoxCollider>().isTrigger = true;
                        doorAnimator.SetTrigger("isTrigger");
                        isOpen = true;
                        doorOpenSource.Play();

                    }
                    else if (isOpen)
                    {

                        obj.GetComponent<BoxCollider>().isTrigger = false;
                        doorAnimator.SetTrigger("isTrigger");
                        isOpen = false;
                        doorOpenSource.Play();

                    }

                }
                else if (obj.tag == "BackDoor")
                {
                    backDoorSoundSource.Play();
                }
                else if (obj.tag == "Switch")
                {

                    lights = obj.GetComponent<KeepLights>();

                    switchAnimator = obj.GetComponent<Animator>();
                    if (!isLightOpen)
                    {
                        lightSoundSource.Play();
                        switchAnimator.SetTrigger("isTrigger");
                        for (int i = 0; i < lights.lights.Length; i++)
                        {
                            lights.lights[i].enabled = true;
                        }

                        isLightOpen = true;
                    }
                    else
                    {
                        lightSoundSource.Play();
                        switchAnimator.SetTrigger("isTrigger");
                        for (int i = 0; i < lights.lights.Length; i++)
                        {
                            lights.lights[i].enabled = false;
                        }
                        isLightOpen = false;
                    }


                }
                else if (obj.tag == "DoorLock")
                {
                    panel.SetActive(true);
                    Time.timeScale = 0f;
                    Cursor.lockState = CursorLockMode.None;
                }
                else if (obj.tag == "PasswordDoor")
                {

                    doorAnimator = obj.GetComponent<Animator>();

                    if (passwordManage.isOpenDoor)
                    {
                        if (!isOpen)
                        {
                            obj.GetComponent<BoxCollider>().isTrigger = true;
                            doorAnimator.SetTrigger("isTrigger");
                            isOpen = true;
                            doorOpenSource.Play();

                        }
                        else if (isOpen)
                        {

                            obj.GetComponent<BoxCollider>().isTrigger = false;
                            doorAnimator.SetTrigger("isTrigger");
                            isOpen = false;
                            doorOpenSource.Play();

                        }
                    }
                    else
                        backDoorSoundSource.Play();

                }
                else if (obj.tag == "BathroomDoor")
                {
                    doorAnimator = obj.GetComponent<Animator>();
                    if (!isOpen)
                    {
                        obj.GetComponent<BoxCollider>().isTrigger = false;
                        doorAnimator.SetTrigger("isTrigger");
                        isOpen = true;
                        slidingDoorSource.Play();

                    }
                    else if (isOpen)
                    {
                        obj.GetComponent<BoxCollider>().isTrigger = true;
                        doorAnimator.SetTrigger("isTrigger");
                        isOpen = false;
                        slidingDoorSource.Play();

                    }
                }
                else if (obj.tag == "cloackroom")
                {
                    doorAnimator = obj.GetComponent<Animator>();
                    if (!isOpen)
                    {

                        doorAnimator.SetTrigger("isTrigger");
                        isOpen = true;
                        wardobeSource.Play();

                    }

                    else if (isOpen)
                    {
                        doorAnimator.SetTrigger("isTrigger");
                        isOpen = false;
                        wardobeSource.Play();

                    }
                }


                else if (obj.tag == "RemoteControl")
                {
                    objects.Add(obj);
                    isRemoteController = true;
                    Destroy(obj);
                }

                else if (obj.tag == "MainDoor")
                {
                    mainDoor.Play();
                }
            }

        }
    }

}

