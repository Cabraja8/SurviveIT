using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControler : MonoBehaviour
{
    [SerializeField] VideoPlayer myvideo;

    public GameObject video;
    bool hasPlayed = false;
    public GameObject[] objectsToEnable;

    private void Awake() {
        
        myvideo.loopPointReached += EndVideo;
         if (hasPlayed)
        {
            myvideo.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myvideo = GetComponent<VideoPlayer>();
    }

    public void EndVideo(VideoPlayer vp){
        video.SetActive(false);
        hasPlayed = true;
        EnableAllObjects();
        FindObjectOfType<PauseMenu>().Resume();
    }

    public void EnableAllObjects()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }
   

}
