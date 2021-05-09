using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionControl : MonoBehaviour {
    private GameObject buttonLeft;
    private GameObject buttonRight;
    
    public List<Button> buttons;
    public Text leftName;
    public Text rightName;
    
    public bool display = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (display) {
            if (buttonLeft) {
                buttonLeft.gameObject.SetActive(true);
                leftName.gameObject.SetActive(true);
            }

            if (buttonRight) {
                buttonRight.gameObject.SetActive(true);
                rightName.gameObject.SetActive(true);
            }
        }
        else {

            if (buttonLeft)
            {
                buttonLeft.gameObject.SetActive(false);
                leftName.gameObject.SetActive(false);
                buttonLeft.GetComponent<Image>().DOFade(0, 1);
                leftName.DOFade(0, 1);
            }

            if (buttonRight)
            {
                buttonRight.gameObject.SetActive(false);
                rightName.gameObject.SetActive(false);
                buttonRight.GetComponent<Image>().DOFade(0, 1);
                rightName.DOFade(0, 1);
            }
        }
    }

    public void OnCharacterClicked() {
       GameObject.Find("ControlCanvas").GetComponent<CharacterSelectionControl>().display = false;
       //print("Dd");
    }
    
    public void SetCharacters(string left,string right) {
        display = true;
        if (left != "") {
            buttonLeft =buttons[GameManager._instance.GetIndexByName(left)].gameObject;
            buttonLeft.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            buttonLeft.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
            buttonLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(362.45f, 324);
            buttonLeft.GetComponent<Image>().DOFade(1, 1);
            leftName.text = left;
            leftName.DOFade(1, 1);
        }

        if (right != "") {

            buttonRight = buttons[GameManager._instance.GetIndexByName(right)].gameObject;
            buttonRight.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0);
            buttonRight.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0);
            buttonRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(-362.3f, 324);
            buttonRight.GetComponent<Image>().DOFade(1, 1);
            rightName.text = right;
            rightName.DOFade(1, 1);
        }
        
    }
}
