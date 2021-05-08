using System.Collections;
using System.Collections.Generic;
using Fungus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CommandInfo("TENC",
    "Set text color",
    "Set text color")]
public class SetTextColor : Command {
    public Color targetColor;
    public Text text;
    public TMP_Text TMPText;
    public override void OnEnter() {
        if (text) {
            text.color = targetColor;
        }

        if (TMPText) {
            TMPText.color=targetColor;
        }
        Continue();

    }
}
