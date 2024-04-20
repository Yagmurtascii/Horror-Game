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
        Vector3 rayOrigin = transform.position; // �rne�in, bu script bir karakter �zerine eklenmi�se, karakterin pozisyonunu ba�lang�� noktas� olarak al�r.

        if (Physics.Raycast(rayOrigin, Vector3.down, out hit, Mathf.Infinity, stairLayerMask))
        {
            // E�er ray belirli bir katmanla temas ederse bu blok �al���r.
            audio.Play();
        }
        else
        {
            // E�er ray hi�bir katmanla temas etmezse bu blok �al���r.
            audio.Stop();
        }
    }
}
