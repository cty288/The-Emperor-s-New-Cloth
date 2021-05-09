using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
[CommandInfo("TENC",
    "On Character Visited",
    "On Character Visited")]
public class OnCharacterVisited : Command
{
    public override void OnEnter() {
        GameObject.Find("BG").GetComponent<BGImageControl>().start = true;
        Flowchart flowchart = GetFlowchart();
        GameManager._instance.DeleteACharacterFromList(ParentBlock.BlockName);
        Continue();

    }
}
