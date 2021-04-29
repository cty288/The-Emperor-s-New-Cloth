using System.Collections;
using System.Collections.Generic;
using Fungus;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMPLinks : MonoBehaviour,IPointerClickHandler
{
    public TextMeshProUGUI text;
    public Flowchart flowChart;
    private List<string> links=new List<string>();

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 pos = new Vector3(eventData.position.x, eventData.position.y, 0);
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, pos, null); //--UI camera
        if (linkIndex > -1)
        { 
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
            bool find = false;
            foreach (string link in links)
            {
                if (link == linkInfo.GetLinkText()) {
                    find = true;
                }
            }

            if (!find) {
                links.Add(linkInfo.GetLinkText());
                print("linkTextLength"+linkInfo.linkTextLength);
                print("linkTextfirstCharacterIndex"+linkInfo.linkTextfirstCharacterIndex);
                print(linkInfo.linkIdFirstCharacterIndex);
                //text.text = text.text.Insert(linkInfo.linkIdFirstCharacterIndex+linkInfo.linkIdLength+1+linkInfo.linkTextLength+15, "(dddd)");
                flowChart.SetStringVariable("ddd","Wadwadadwa");
            }
            Debug.Log(linkInfo.GetLinkText());
            //Application.OpenURL(linkInfo.GetLinkID());
        }
    }

}
