using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayerControl : MonoBehaviour {
    public AudioClip[] bgms;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying) {
            AudioClip clip = bgms[Random.Range(0, bgms.Length)];
            audio.clip = clip;
            audio.Play();
        }
    }
}
