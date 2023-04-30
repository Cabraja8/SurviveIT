using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClick : MonoBehaviour
{
   
    public AudioSource audiosource;
    public AudioClip buttonclick;
    

   public void ButtonClick(){
    audiosource.PlayOneShot(buttonclick);
   }
}
