using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hilanh : MonoBehaviour
{
    public float animTime = 54f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", animTime);
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
