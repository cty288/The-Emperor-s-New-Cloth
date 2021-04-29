using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Fungus;
using TMPro;
using UnityEngine;

public class MoralTextControl : MonoBehaviour {
    public Flowchart flowchart;
    

    public TMP_Text moralText;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("showMoral"))
        {
            moralText.gameObject.SetActive(true);
            moralText.text ="Ending "+flowchart.GetIntegerVariable("ending")+":\n"+flowchart.GetStringVariable("moral");
            moralText.DOFade(1, 8f);
        }
        else
        {
            moralText.gameObject.SetActive(false);
            moralText.alpha = 0;
        }

    }
}
