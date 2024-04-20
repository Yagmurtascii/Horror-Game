using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ManageGuide : MonoBehaviour
{
    [SerializeField]
    private GameObject[] guide;
    public GameObject arrows;
    [SerializeField] 
    private TMP_Text text;


    private bool isGuide = false;

    public int i = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isGuide)
        {
            foreach(GameObject a in  guide) 
            guide[0].SetActive(true);
            arrows.SetActive(true);
            isGuide = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetKeyDown(KeyCode.Q) && isGuide)
        {
            arrows.SetActive(false);
            guide[0].SetActive(false);
            guide[1].SetActive(false);
            guide[2].SetActive(false);
            isGuide = false; Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void NextDiary()
    {
        if (i<guide.Length) 
        {
            guide[i].SetActive(false);
            i++;
            if (i == guide.Length)
                i = 0;
            guide[i].SetActive(true); 
            
        }
    }

    public void ShowText()
    {
        text.text = "Next";
    }

    public void HideText()
    {
        text.text = "";
    }
}
