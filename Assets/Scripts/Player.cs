using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    private IEnumerator MoveObject(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            float speed = Speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target, speed);
            yield return null;
        }
    }
    public void move(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) <= 1.3)
        {
            StartCoroutine(MoveObject(target));
        }
    }
}
