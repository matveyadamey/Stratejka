using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollectingVisualisation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(888888);
        if (other.gameObject.tag == "coins")
        {
            print(99999999);
            Destroy(other.gameObject);
        }
    }
}
