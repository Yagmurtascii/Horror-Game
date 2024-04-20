using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        text.text = "Prize týklanýldý";
        
    }
}
