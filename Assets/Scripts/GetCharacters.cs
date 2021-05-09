using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
[CommandInfo("TENC",
    "Get Characters",
    "Get Two Characters")]
public class GetCharacters : Command
{
    public override void OnEnter() {
        GetFlowchart().SetIntegerVariable("round", GetFlowchart().GetIntegerVariable("round") + 1);
        GetFlowchart().SetBooleanVariable("showValues",true);
        if (GameManager._instance.GetListSize() > 0) {
            GetFlowchart().SetStringVariable("char1", "");
            GetFlowchart().SetStringVariable("char2", "");

            string str1 = GameManager._instance.GetACharacter();
            string str2 = "";
            if (GameManager._instance.GetListSize() > 1) {
                str2 = GameManager._instance.GetACharacter();
                while (str2 == str1) {
                    str2 = GameManager._instance.GetACharacter();
                }
            }
            GetFlowchart().SetStringVariable("char1", str1);
            GetFlowchart().SetStringVariable("char2", str2);
            GameObject.Find("ControlCanvas").GetComponent<CharacterSelectionControl>().SetCharacters(str1,str2);
        }
        Continue();
 
    }
    
}
