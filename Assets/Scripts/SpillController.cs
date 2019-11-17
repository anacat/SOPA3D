using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillController : MonoBehaviour
{
    public Transform parent;
    public Transform spillPool;
    public ParticleSystem psPrefab;
    public int maxSpills;
    List<ParticleSystem> idleSpills;
    Vector3 startPosition;
    bool spilled;
    private void Start()
    {
        startPosition = transform.localPosition;

        idleSpills = new List<ParticleSystem>();
        for (int i = 0; i < maxSpills; i++)
        {
            idleSpills.Add(Instantiate(psPrefab, parent));
        }
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
        if (spilled || idleSpills.Count < 1)
        {
            return;
        }
        Vector3 dir = new Vector3(wobbleAmountX, 0, wobbleAmountZ);
        if (dir.magnitude > 0.25f)
        {
            spilled = true;

            float angle = Vector3.Angle(transform.forward, -dir);

            ParticleSystem ps = idleSpills[0];
            idleSpills.Remove(ps);

            ps.transform.localRotation = Quaternion.Euler(angle, 0, 0);
            ps.transform.SetParent(null);
            ps.transform.position -= dir.normalized;

            StartCoroutine(StartSpilling(ps));
        }
    }

    IEnumerator StartSpilling(ParticleSystem ps)
    {
        ps.Play();

        float time = ps.duration - 0.005f;
        float elapsedTime = 0;
        //coldown before next spill
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        spilled = false;
        elapsedTime = 0;
        time = ps.startLifetime - 0.005f;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        ps.transform.SetParent(parent);
        ps.transform.localPosition = startPosition;
        ps.transform.localRotation = Quaternion.identity;
        idleSpills.Add(ps);
    }

}
