using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeClass : MonoBehaviour
{

    //is the node active

    public string DeviceName;
    public int NodeNum;
    public  string IPv4Address;
    public string MACAddress;
    public NodeClass[] AdjacentDevices;
    public float InfectionRisk;
    public float InfectionRiskCalculation;
    public NodeClass[] PathofTransfer;


    

   public void NodeVisibility(bool IsNodeActive)
    {//bool value comes from on_Devices from the traceability matrix

        //public int NodeNum;
       // int Nodebum;

        Renderer rend = gameObject.GetComponent<Renderer>();

        if (IsNodeActive == false)
        {
            rend.enabled = false;

        }
        else
        {
            //add all other active node properties 
        }
    }

    public void Connections(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        //gameObject.transform.SetParent(CurrentNode);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(100, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * .5f;
       // rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }


    //what does the node connect to
    //what edges to activate in this case
}
