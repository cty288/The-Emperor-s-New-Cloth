using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Fungus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoralTextControl : MonoBehaviour {
    public Flowchart flowchart;

    public Image  moralBG;
    public TMP_Text moralText;
    public GameObject restartButton;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("showMoral")) {
            moralBG.DOFade(1, 5f);

            if (moralBG.color.a >= 0.9) {
                moralText.gameObject.SetActive(true);
                moralText.text = "Ending " + flowchart.GetIntegerVariable("ending") + ":\n" + flowchart.GetStringVariable("moral");
                moralText.DOFade(1, 8f);
                restartButton.SetActive(true);
            }
            
        }
        else {
            moralBG.DOFade(0,2) ;
            moralText.gameObject.SetActive(false);
            moralText.alpha = 0;
            restartButton.SetActive(false);
        }

    }
}
