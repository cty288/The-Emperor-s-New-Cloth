using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BGMPlayerControl : MonoBehaviour {
    public static BGMPlayerControl _instance;
    public AudioClip[] bgms;

    public AudioClip menuBgm;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying && GameManager._instance.gameState==GameState.inGame) {
            audio.volume = 0;
            audio.loop = false;
            AudioClip clip = bgms[Random.Range(0, bgms.Length)];
            audio.clip = clip;
            audio.Play();
            audio.DOFade(1, 2f);
        }

        if (GameManager._instance.gameState == GameState.end && audio.volume>=0.1f) {
            audio.DOFade(0, 2);
        }

        if (GameManager._instance.gameState == GameState.menu && !audio.isPlaying) {
            audio.volume = 0;
            audio.loop = true;
            audio.clip = menuBgm;
            audio.Play();
            audio.DOFade(1, 2f);
        }
    }

    public void StopSound() {
        audio.DOFade(0, 1.5f);
        StartCoroutine(StopAfter(1.5f));
    }

    IEnumerator StopAfter(float time) {
        yield return new WaitForSeconds(time);
        audio.Stop();
    }
}
