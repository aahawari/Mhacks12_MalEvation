using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRenderer : MonoBehaviour 
{

    // Use this for initialization
    void Start(bool IsNodeActive)
    {//bool value comes from on_Devices from the traceability matrix

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

}
