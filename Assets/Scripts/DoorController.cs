using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // Kap�n�n animasyonunu kontrol etmek i�in Animator bile�eni
    private bool isOpen = false; // Kap�n�n a��k m� kapal� m� oldu�unu takip etmek i�in bir de�i�ken

    // Kap�n�n collider'�na ba�ka bir nesne girdi�inde �a�r�lan fonksiyon
    private void OnTriggerEnter(Collider other)
    {
        // Kap�n�n etiketi Door ise ve kap� kapal�ysa
        if (other.CompareTag("Player") && !isOpen)
        {
            GetComponent<Collider>().isTrigger = true;
            // Kap�y� a�mak i�in animasyonu ba�lat
            doorAnimator.SetBool("Open", true);
            // Kap�y� a��k olarak i�aretle
            isOpen = true;
            // Collider'�n isTrigger �zelli�ini true olarak ayarla
          
        }
        // Kap�n�n etiketi Door ise ve kap� a��ksa
        else if (other.CompareTag("Player") && isOpen)
        {
            // Kap�y� kapatmak i�in animasyonu ba�lat
            doorAnimator.SetBool("Open", false);
            // Kap�y� kapal� olarak i�aretle
            isOpen = false;
            // Collider'�n isTrigger �zelli�ini false olarak ayarla
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
