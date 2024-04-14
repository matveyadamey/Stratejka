using System.Collections;
using UnityEngine;

public class Movement:MonoBehaviour
{
    private float _speed=10f;
    private IEnumerator _moveObject(Vector3 target,Transform chip)
    {
        while (Vector3.Distance(chip.transform.position, target) > 0.1f)
        {
            chip.transform.position = Vector3.Lerp(chip.transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
    public void move(Vector3 target,GameObject chip)
    {
        Vector3 _target = new Vector3(target.x, 1, target.z);
        if (Vector3.Distance(chip.transform.position, _target) <= 1.3f)
        {
            StartCoroutine(_moveObject(_target, chip.transform));
        }
    }
}
