using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveCounterDisplay : MonoBehaviour
{
   public TMP_Text WaveDisplay;

  

   public void UpdateDisplay(string num){
    WaveDisplay.text = "Wave: "+ num;
   }



}
