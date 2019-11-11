using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillController : MonoBehaviour
{
    public Transform parent;
    ParticleSystem ps;
    Vector3 startPosition;
    bool spilled;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        startPosition = transform.localPosition;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ps.Play();
            //StartCoroutine(StartSpilling());
        }
    }

    public void CheckForSpill(float wobbleAmountX, float wobbleAmountZ)
    {
        if (spilled)
        {
            return;
        }
        Vector3 dir = new Vector3(wobbleAmountX, 0, wobbleAmountZ);
        if (dir.magnitude > 1)
        {
            spilled = true;

            float angle = Vector3.Angle(transform.forward, -dir);

            transform.localRotation = Quaternion.Euler(angle, 0, 0);
            transform.SetParent(null);
            transform.position -= dir.normalized;

            StartCoroutine(StartSpilling());
        }
    }

    IEnumerator StartSpilling()
    {
        ps.Play();
        //can only play again after last particle as faded
        float time = ps.duration + ps.startLifetime - 0.01f;
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.SetParent(parent);
        transform.localPosition = startPosition;
        transform.localRotation = Quaternion.identity;
        spilled = false;
    }

}
