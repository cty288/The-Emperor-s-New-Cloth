using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BGImageControl : MonoBehaviour {
    private Image bg;

    public bool start = false;
    public bool complete = true;

    // Start is called before the first frame update
    void Start() {
        bg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        if (start) {
            complete=false;;
            bg.DOFade(1, 0.5f);
            if (bg.color.a >= 0.95) {
                start = false;
            }
        }
        else {
            bg.DOFade(128f/255f, 0.5f);
            if (bg.color.a <= 135f / 255f)
            {
                complete = true;
            }
        }
    }
}
