using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private Transform tr;
    private LineRenderer line;
    private RaycastHit hit;
    private float fireRate;
    private float nextFire = 0.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
        line = GetComponent<LineRenderer>();
        //line.useWorldSpace = false;
        line.enabled = false;
        line.startWidth = 0.1f;
        line.endWidth = 0.05f;
        fireRate = GetComponentInParent<FireCtrl>().fireRate;
    }

    void Update()
    {
        Ray ray = new Ray(tr.position, tr.forward);
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextFire)
            {
                //line.SetPosition(0
                //    , tr.InverseTransformPoint(ray.origin));
                line.SetPosition(0, tr.position);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    //line.SetPosition(1
                    //    , tr.InverseTransformPoint(hit.point));
                    line.SetPosition(1, hit.point);
                }
                //else line.SetPosition(1
                //, tr.InverseTransformPoint(ray.GetPoint(100.0f)));
                else line.SetPosition(1, ray.GetPoint(100.0f));
                StartCoroutine(this.ShowLaserBeam());
                nextFire = Time.time + fireRate;
            }
        }
    }

    IEnumerator ShowLaserBeam()
    {
        line.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.01f, 0.2f));
        line.enabled = false;
    }
}
