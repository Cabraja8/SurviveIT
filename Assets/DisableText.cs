using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisableText : MonoBehaviour
{
    public TMP_Text AlreadyEquiped;
    public TMP_Text already3;
    public TMP_Text already100;

    void Start()
    {
        AlreadyEquiped.enabled = false;
        already3.enabled = false;
        already100.enabled = false;

    }

   
}
