using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBreath : MonoBehaviour
{
    public AudioSource audio;
    public bool isKeep = false;
    public Camera camera;
    // Update is called once per frame

    public void Start()
    {

    }
    void Update()
    {
        if (!isKeep && Input.GetKeyDown(KeyCode.Q))
        {
            audio.enabled = false;
            isKeep = true;
            gameObject.SetActive(true);

            StartCoroutine(MyCoroutine());

        }
        else if (isKeep && Input.GetKeyDown(KeyCode.Q))
        {
            audio.enabled = true;
            isKeep = false;


        }
    }

    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(10f);
        camera.GetComponent<Camera>().backgroundColor = Color.red;
    }
}
