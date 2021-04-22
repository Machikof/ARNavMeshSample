﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    [Header("ARカメラ"), SerializeField] GameObject camera;
    NavMeshAgent agent;
    Vector3 targetPos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetPos = new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z);
    }

    void Update()
    {
        ApproachToCamera();
    }

    void ApproachToCamera()
    {
        if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            Debug.Log("NavMesh is ready");
            agent.destination = targetPos;
        }
        else Debug.Log("NavMesh is not ready");
    }
}
