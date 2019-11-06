using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillController : MonoBehaviour
{
    ParticleSystem ps;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ps.Play();
        }
    }
}
