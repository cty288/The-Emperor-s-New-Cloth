using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUpSound : MonoBehaviour {
    private AudioSource audio;

    public GameObject menu1;
    private bool prevIsActive1 = false;

    public GameObject menu2;
    private bool prevIsActive2 = false;
    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (prevIsActive1 != menu1.activeInHierarchy) {
            if (menu1.activeInHierarchy) {
                audio.Play();
            }
            prevIsActive1 = menu1.activeInHierarchy;
        }

        if (prevIsActive2 != menu2.activeInHierarchy)
        {
            if (menu2.activeInHierarchy)
            {
                audio.Play();
            }
            prevIsActive2 = menu2.activeInHierarchy;
        }
    }
}
