using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyObject : MonoBehaviour
{
    public float timeToDestroy;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(TimeToDestroy());
    }

    private IEnumerator TimeToDestroy()
    {
        bool destroyed = false;

        while (true)
        {
            if (!destroyed)
            {
                destroyed = true;
                yield return new WaitForSeconds(timeToDestroy);
            }
            else
            {
                Destroy(gameObject);
                yield break;
            }
        }
    }
}
