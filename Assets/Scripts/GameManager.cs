using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Fungus;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager _instance;

    public TMP_Text affinityText;
    public TMP_Text mentalText;
    public List<string> characters;
    public Flowchart flowchart;

    private int mentalDisplay;
    private int affinityDisplay;
    // Start is called before the first frame update
    void Start() {
        _instance = this;
        mentalDisplay = flowchart.GetIntegerVariable("mental");
        affinityDisplay = flowchart.GetIntegerVariable("affinity");
    }

    public string GetACharacter() {
        int index = Random.Range(0, characters.Count);
        string character = characters[index];
        //characters.RemoveAt(index);
        return character;
    }

    public int GetListSize() {
        return characters.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("showValues")) {
            affinityText.gameObject.SetActive(true);
            mentalText.gameObject.SetActive(true);

            affinityText.text = "Affinity: " + affinityDisplay;
            mentalText.text = "Mental State: " + mentalDisplay;

            if (affinityDisplay < 0) {
                affinityText.DOColor(new Color(1, 0, 0), 0.2f);
            }
            else {
                affinityText.DOColor(new Color(0, 0.6037736f, 0.147598f), 0.2f);
            }

            if (mentalDisplay < 0) {
                mentalText.DOColor(new Color(1, 0, 0), 0.2f);
            }
            else {
                mentalText.DOColor(new Color(0, 0.6037736f, 0.147598f), 0.2f);
            }
        }
        else {
            affinityText.gameObject.SetActive(false);
            mentalText.gameObject.SetActive(false);
        }
    }

    public void AddAffinityandMentalState(int aff, int ment) {
        flowchart.SetIntegerVariable("affinity",flowchart.GetIntegerVariable("affinity")+aff);
        flowchart.SetIntegerVariable("mental", flowchart.GetIntegerVariable("mental") + ment);
        DOTween.To(() => affinityDisplay, x => affinityDisplay = x, flowchart.GetIntegerVariable("affinity"),
            0.2f);
        DOTween.To(() => mentalDisplay, x => mentalDisplay = x, flowchart.GetIntegerVariable("mental"),
            0.2f);
    }

    public void DeleteACharacterFromList(string name) {
        characters.Remove(name);
    }
}
