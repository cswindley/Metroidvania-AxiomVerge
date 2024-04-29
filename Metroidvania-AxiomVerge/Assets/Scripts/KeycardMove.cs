using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardMove : MonoBehaviour
{
    public float amp;
    public float freq;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(startPos.x, Mathf.Sin(Time.time * freq) * amp + startPos.y, startPos.z);
        transform.Rotate(0, 0.15f, 0.1f);
    }
}
