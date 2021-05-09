using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {
    public BGImageControl bgImage;
    private Sprite prevSprite;
    private Image image;
    // Start is called before the first frame update
    void Start() {
        image = GetComponent<Image>();
        prevSprite = image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevSprite != image.sprite) {
            prevSprite=image.sprite;;
            bgImage.start = true;
        }
    }
}
