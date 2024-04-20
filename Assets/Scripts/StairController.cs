using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{
    public AudioSource audio;
    public LayerMask stairLayerMask;

    private void Update()
    {
        RaycastHit hit;
        Vector3 rayOrigin = transform.position; // Örneðin, bu script bir karakter üzerine eklenmiþse, karakterin pozisyonunu baþlangýç noktasý olarak alýr.

        if (Physics.Raycast(rayOrigin, Vector3.down, out hit, Mathf.Infinity, stairLayerMask))
        {
            // Eðer ray belirli bir katmanla temas ederse bu blok çalýþýr.
            audio.Play();
        }
        else
        {
            // Eðer ray hiçbir katmanla temas etmezse bu blok çalýþýr.
            audio.Stop();
        }
    }
}
