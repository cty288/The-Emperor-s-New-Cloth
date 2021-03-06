using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
[CommandInfo("TENC",
    "Add affinity and mental state",
    "Add affinity and mental state")]
public class AddAffinityMental : Command {
    public int affinityAdded;
    public int mentalAdded;
    public override void OnEnter()
    {
        GameManager._instance.InfoPanelDown();
        GameManager._instance.PlayAddValueSound();
        StartCoroutine(WaitASecond());
       
        Continue();

    }

    IEnumerator WaitASecond() {
        yield return new WaitForSeconds(1);
        GameManager._instance.AddAffinityandMentalState(affinityAdded, mentalAdded);
    }
}
