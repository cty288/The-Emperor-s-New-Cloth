using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
[CommandInfo("TENC",
    "Wait BG",
    "Wait BG")]
public class WaitBG : Command
{
    public override void OnEnter()
    {
        GameObject.Find("BG").GetComponent<BGImageControl>().start = true;
        Continue();
        
    }
}
