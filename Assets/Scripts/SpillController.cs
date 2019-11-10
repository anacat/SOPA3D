using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillController : MonoBehaviour
{
    ParticleSystem ps;
    Vector3 psStartPosition;
    public Transform bowl;
    bool spilled;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        psStartPosition = ps.transform.localPosition;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ps.Play();
            StartCoroutine(StartSpilling());
        }
    }

    public void CheckForSpill(Vector3 velocity, Vector3 rot)
    {
        if (spilled)
        {
            return;
        }
        Vector3 dir = velocity;// new Vector3(dirX, 0, dirZ);
        if (dir.magnitude > 1)
        {
            //print($"dir.normalized = {dir.normalized}");
            //print($"bowl.position = {bowl.}");
            
           // print($"ps.transform.localPosition = {ps.transform.localPosition}");
            spilled = true;
            ps.transform.SetParent(null);
            print($"ps.transform.forward = {ps.transform.forward}");
            ps.transform.rotation.SetFromToRotation(ps.transform.forward, dir.normalized);
            ps.transform.position -= dir.normalized;
          //  print($"ps.transform.localPosition = {ps.transform.localPosition}");
            StartCoroutine(StartSpilling());
        }
    }

    IEnumerator StartSpilling()
    {
        ps.Play();
        float time = ps.duration + ps.startLifetime - 0.01f;
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        ps.transform.SetParent(bowl);
        ps.transform.localPosition = psStartPosition;
        ps.transform.localRotation = Quaternion.identity;
        spilled = false;
    }

}
