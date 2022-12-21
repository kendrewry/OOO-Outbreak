using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class videoPlayerBtns : MonoBehaviour
{
    private VideoPlayer vid;

    private void Awake() {

        vid = GetComponent<VideoPlayer>();
    }

    public void play() {
        vid.Play();
    }

    public void pause() {
        vid.Pause();
    }

}
