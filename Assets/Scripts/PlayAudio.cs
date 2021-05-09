using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
[CommandInfo("TENC",
    "Set text color",
    "Set text color")]

public class PlayAudio : Command {
    public AudioClip sound;
    // Start is called before the first frame update
    public override void OnEnter() {
        AudioSource audio = GameObject.Find("SoundEffects").GetComponent<AudioSource>();
        audio.clip = sound;
        audio.Play();
        Continue();

    }
}
