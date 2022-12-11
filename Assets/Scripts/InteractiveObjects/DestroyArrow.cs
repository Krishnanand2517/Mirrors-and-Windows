using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    float destroyTimer = 0f;

    void Update()
    {
        destroyTimer += Time.deltaTime;

        if (destroyTimer >= 3f)
        {
            Destroy(gameObject);
        }
    }
}
