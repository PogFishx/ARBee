using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject beePrefab;
    [SerializeField] private Vector3 prefabOffset;
    [SerializeField] private FixedJoystick fixedJoystick;
    private GameObject bee;
    private ARTrackedImageManager ARTIM;

    private void OnEnable()
    {
        ARTIM = gameObject.GetComponent<ARTrackedImageManager>();
        ARTIM.trackedImagesChanged += OnImageChanged;
        
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            fixedJoystick.gameObject.SetActive(true);
            fixedJoystick.enabled=true;
            bee = Instantiate(beePrefab, image.transform);
            bee.transform.position += prefabOffset;
        }
    }
}
