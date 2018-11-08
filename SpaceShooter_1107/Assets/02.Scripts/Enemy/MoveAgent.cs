using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // 네비게이션 기능을 사용하기 위한 네임스페이스

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    public List<Transform> wayPoints;
    public int nextIdx = 0;

    private NavMeshAgent agent;
    private Transform enemyTr;
    private readonly float patrolSpeed = 1.5f;
    private readonly float traceSpeed = 4.0f;
    private float damping = 1.0f; // 회전 속도 조절 계수
    private bool patrolling;
    public bool Patrolling
    {
        get { return patrolling; }
        set
        {
            patrolling = value;
            if (patrolling)
            {
                agent.speed = patrolSpeed;
                damping = 1.0f;
                MoveWayPoint();
            }
        }
    }

    private Vector3 traceTarget;

    public Vector3 TraceTarget
    {
        get { return traceTarget; }
        set
        {
            traceTarget = value;
            agent.speed = traceSpeed;
            damping = 7.0f;
            Trace_Target(traceTarget);
        }
    }

    void Start()
    {
        enemyTr = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.updateRotation = false;
        agent.speed = patrolSpeed;
        var group = GameObject.Find("WayPointGroup");
        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            //Transform[] points = group.
            //    GetComponentsInChildren<Transform>();
            //wayPoints.AddRange(points);
            wayPoints.RemoveAt(0);
            nextIdx = Random.Range(0, wayPoints.Count);
        }
        MoveWayPoint();
    }

    private void MoveWayPoint()
    {
        if (agent.isPathStale) return;
        agent.destination = wayPoints[nextIdx].position;
        agent.isStopped = false;
    }

    private void Trace_Target(Vector3 pos)
    {
        if (agent.isPathStale) return;
        agent.destination = pos;
        agent.isStopped = false;
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        Patrolling = false;
    }

    public float Speed
    {
        get { return agent.velocity.magnitude; }
    }

    void Update()
    {
        if (agent.isStopped == false)
        {
            Quaternion rot = Quaternion.
                LookRotation(agent.desiredVelocity);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation
                , rot, Time.deltaTime * damping);
        }

        if (!Patrolling) return;

        //if (agent.velocity.magnitude >= 0.2f
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f        
            && agent.remainingDistance <= 0.5f)
        {
            //nextIdx = ++nextIdx % wayPoints.Count;
            nextIdx = Random.Range(0, wayPoints.Count);
            MoveWayPoint();
            //Debug.Log(nextIdx);
        }
    }
}
