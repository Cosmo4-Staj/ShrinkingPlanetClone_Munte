using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crater : PlayerGravityBody
{
    public float shrinkSpeed= 0.05f;
    public ParticleSystem crashEffect;
    bool isVanishing = false;

    void Update()
    {
        if (isVanishing) { return; }

        transform.localScale *= 1f - shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= 0.5f)
        {
            isVanishing = true;

            Destroy(gameObject, 1f);
        }
    }
}
