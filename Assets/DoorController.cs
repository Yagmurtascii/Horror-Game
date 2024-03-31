using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // Kapýnýn animasyonunu kontrol etmek için Animator bileþeni
    private bool isOpen = false; // Kapýnýn açýk mý kapalý mý olduðunu takip etmek için bir deðiþken

    // Kapýnýn collider'ýna baþka bir nesne girdiðinde çaðrýlan fonksiyon
    private void OnTriggerEnter(Collider other)
    {
        // Kapýnýn etiketi Door ise ve kapý kapalýysa
        if (other.CompareTag("Player") && !isOpen)
        {
            GetComponent<Collider>().isTrigger = true;
            // Kapýyý açmak için animasyonu baþlat
            doorAnimator.SetBool("Open", true);
            // Kapýyý açýk olarak iþaretle
            isOpen = true;
            // Collider'ýn isTrigger özelliðini true olarak ayarla
          
        }
        // Kapýnýn etiketi Door ise ve kapý açýksa
        else if (other.CompareTag("Player") && isOpen)
        {
            // Kapýyý kapatmak için animasyonu baþlat
            doorAnimator.SetBool("Open", false);
            // Kapýyý kapalý olarak iþaretle
            isOpen = false;
            // Collider'ýn isTrigger özelliðini false olarak ayarla
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
