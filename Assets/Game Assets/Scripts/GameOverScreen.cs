using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{   
    
 public void Setup(){
    gameObject.SetActive(true);
    Time.timeScale=0;
    FindObjectOfType<CurrentWeapons>().gameObject.SetActive(false);
 }

 public void RestartLevel(){
    Time.timeScale=1;
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
 }

 public void ReturnToMenu(){
    Time.timeScale=1;
    SceneManager.LoadScene(1);
 }



}
