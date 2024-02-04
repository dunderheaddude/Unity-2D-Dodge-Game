using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void Update()
    {
        DestroyIfBelowThreshold();
    }

    private void DestroyIfBelowThreshold()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
