using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public static void HighlightOn(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    public static void HighlightOff(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
}
