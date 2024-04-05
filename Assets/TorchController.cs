using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    [SerializeField] private Light torch;
    private bool isTorch=false;

    public void Update()
    {
        if(!isTorch && Input.GetKeyDown(KeyCode.Mouse1))
        {
            torch.enabled = true;
            isTorch = true;
        }
        else if(isTorch && Input.GetKeyDown(KeyCode.Mouse1))
        {
            torch.enabled=false;
            isTorch = false;
        }

    }
}
