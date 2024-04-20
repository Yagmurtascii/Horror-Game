using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordManage : MonoBehaviour
{
    public TMP_Text Password;
    public AudioSource PasswordAudioSource;
    public AudioClip WrongPassword;
    public AudioClip CorrectPassword;
    public AudioClip OpenDoor;
    public GameObject panel;
    

    public bool isOpenDoor=false;


    public void enterButton(Button button)
    {

        string buttonText = button.GetComponentInChildren<TMP_Text>().text; // Düðme metnini al
        Password.text += buttonText; // Metin alanýna at
        PasswordAudioSource.Play();
    }

    public void clickEnter(Button button)
    {
        if (Password.text == "1234")
        {
      
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            isOpenDoor = true;
            panel.SetActive(false);
            Password.text = "";
            PasswordAudioSource.PlayOneShot(OpenDoor);
        }
        else
        {
            PasswordAudioSource.PlayOneShot(WrongPassword);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            panel.SetActive(false);
            Password.text = "";
        }

    }
    public void del(Button button)
    {
        Password.text = "";
    }

    public void exit()
    {
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }


}
