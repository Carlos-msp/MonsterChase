using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform followTarget;
    private const string FOLLOW_TARGET_TAG = "Player";
    private float CAMERA_LERP_FACTOR = 0.005f;


    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindWithTag(FOLLOW_TARGET_TAG).transform;
    }

    private void LateUpdate() {
        float currentX = transform.position.x;
        float targetX = followTarget.position.x;
        float newX = Mathf.Lerp(currentX, targetX, CAMERA_LERP_FACTOR);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
