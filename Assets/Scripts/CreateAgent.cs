﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class CreateAgent : MonoBehaviour
{
    [Header("出現させるオブジェクト"), SerializeField] GameObject objectPrefab;
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    bool isSet = false;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // エディタ上
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            // レイと平面が交差時
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults, TrackableType.All))
            {
                SetObject(hitResults[0].pose.position);
            }

        }
        // 端末上での動作
#else
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                // レイと平面が交差時
                if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults, TrackableType.All))
                {
                    SetObject(hitResults[0].pose.position);
                }
            }
        }

#endif
    }

    void SetObject(Vector3 position)
    {
        if (!isSet)
        {
            Instantiate(objectPrefab, position, Quaternion.identity);
            isSet = true;
        }
        else
        {
            Debug.Log("Object is here now");
        }
    }
}
