using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed = 1000.0f;
    public float damage = 20.0f;

    private Transform tr;
    private Rigidbody rb;
    private TrailRenderer trail;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        rb.AddForce(transform.forward * speed);
        StartCoroutine(BulletTimer());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        trail.Clear();
        tr.position = Vector3.zero;
        tr.rotation = Quaternion.identity;
        rb.Sleep();
    }

    IEnumerator BulletTimer()
    {
        yield return new WaitForSeconds(3.0f);
        this.gameObject.SetActive(false);
    }
}
