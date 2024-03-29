using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollect : MonoBehaviour
{
    [SerializeField] private int coins;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            coins++; Destroy(collision.gameObject);
        }
    }
}
