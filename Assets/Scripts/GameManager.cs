using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Fungus;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager _instance;

    public TMP_Text affinityText;
    public TMP_Text mentalText;
    public GameObject valuePanel;

    public GameObject affinityInfo;
    public GameObject mentalInfo;
    public GameObject hoverButton;

    public bool panelDown = false;
    public float panelUpTimer = 0;
    public List<string> characters;
    public Flowchart flowchart;

    public AudioClip addValueSound;
    public AudioClip clickSound;
    private int mentalDisplay;
    private int affinityDisplay;

    // Start is called before the first frame update
    void Start() {
        DOTween.SetTweensCapacity(20000,50);
        _instance = this;
        mentalDisplay = flowchart.GetIntegerVariable("mental");
        affinityDisplay = flowchart.GetIntegerVariable("affinity");
        
    }

    public string GetACharacter() {
        int index = Random.Range(0, characters.Count-1); //except little kid
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
        if (Input.GetMouseButtonDown(0)) {
            GetComponentInChildren<AudioSource>().Stop();
            GetComponentInChildren<AudioSource>().clip = clickSound;
            GetComponentInChildren<AudioSource>().Play();
        }
        if (flowchart.GetBooleanVariable("info")) {
            InfoPanelDown();
            affinityInfo.SetActive(true);
            mentalInfo.SetActive(true);
        }
        else {
            affinityInfo.SetActive(false);
            mentalInfo.SetActive(false);
            bool hover = RectTransformUtility.RectangleContainsScreenPoint(
                valuePanel.GetComponent<RectTransform>(), Input.mousePosition, null);
            bool value_button=  RectTransformUtility.RectangleContainsScreenPoint(
                hoverButton.GetComponent<RectTransform>(), Input.mousePosition, null);
            
            if (panelDown) {
                if (!hover && !value_button) {
                    panelUpTimer += Time.deltaTime;
                    if (panelUpTimer >= 5)
                    {
                        panelUpTimer = 0;
                        panelDown = false;
                        InfoPanelUp();
                    }
                }
                else {
                    panelUpTimer = 0;
                }
            }
            else {
                if (value_button) {
                    InfoPanelDown();
                }
            }
        }


        affinityText.text = affinityDisplay.ToString();
        mentalText.text = mentalDisplay.ToString();
      
        if (affinityDisplay < 0) {
            affinityText.DOColor(new Color(1, 203f/255f, 0), 1f);
        }
        else {
            affinityText.DOColor(new Color(0, 1, 0), 1f);
        }

        if (mentalDisplay < 0) {
            mentalText.DOColor(new Color(1, 203f/255f, 0), 1f);
        }
        else {
            mentalText.DOColor(new Color(0, 1, 0), 1f);
        }
        

    }

    public void AddAffinityandMentalState(int aff, int ment) {
        flowchart.SetIntegerVariable("affinity",flowchart.GetIntegerVariable("affinity")+aff);
        flowchart.SetIntegerVariable("mental", flowchart.GetIntegerVariable("mental") + ment);
        DOTween.To(() => affinityDisplay, x => affinityDisplay = x, flowchart.GetIntegerVariable("affinity"),
            1f);
        DOTween.To(() => mentalDisplay, x => mentalDisplay = x, flowchart.GetIntegerVariable("mental"),
            1f);
    }

    public void DeleteACharacterFromList(string name) {
        int index = GetIndexByName(name);
        GameObject.Find("ControlCanvas").GetComponent<CharacterSelectionControl>().buttons.RemoveAt(index);
        characters.Remove(name);
    }

    public void Restart() {
        print("xxx");
        SceneManager.LoadScene(0);
    }

    public int GetIndexByName(string name) {
        return characters.IndexOf(name);
    }

    public void InfoPanelDown() {
        valuePanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-268, -40), 1);
        panelDown = true;
    }

    public void InfoPanelUp() {
        valuePanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-268, 45), 1);
        panelDown = false;
    }

    public void PlayASoundOnce(AudioClip clip) {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }

    public void PlayAddValueSound() {
        PlayASoundOnce(addValueSound);
    }
}
