using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    [SerializeField]
    private GameObject[] flowers;

    [SerializeField]
    private ARRaycastManager raycastManager;

    private static List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    private GameObject spawnedObject;

    bool TryGetTouchPosition(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            
            return true;
        }

        touchPos = default;

        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPos))
        {
            return;
        }

        if (raycastManager.Raycast(touchPos, hitResults, TrackableType.Planes ))
        { 
            Pose hitPose = hitResults[0].pose;

            Instantiate(flowers[Random.Range(0,flowers.Length)], hitPose.position, hitPose.rotation);

            // if (spawnedObject == null)
            // {
            //     spawnedObject = Instantiate(refToPrefab, hitPose.position, hitPose.rotation);
            // }
            // else
            // {
            //     spawnedObject.transform.position = hitPose.position;
            //     spawnedObject.transform.rotation = hitPose.rotation;
            // }
        }
    }
}