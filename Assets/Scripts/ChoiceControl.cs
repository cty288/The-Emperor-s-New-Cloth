using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceControl : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler {
    private Text text;
    private Color targetColor=new Color(0,0,255);
    public void OnPointerDown(PointerEventData eventData) {
        print("dwawda");
        targetColor = new Color(0, 58f/255f, 154f/255f);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        targetColor = new Color(0, 247f/255f, 255f/255f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        targetColor = new Color(0, 0, 255/255);
    }

    // Start is called before the first frame update
    void Start() {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update() {
       text.DOColor(targetColor, 0.1f);
    }
}
