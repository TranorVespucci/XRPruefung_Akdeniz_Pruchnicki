using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtAndFollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera m_cam;
    private Vector3 targetPos; //helps with smoothing out movement
    public float targetingAccuracy = 0.05f;
    public float travelSpeed = 10;
    public float defaultDistance = 1.5f;
    public float maxDistance = 2.5f;
    public float minDistance = 0.1f;

    void Start()
    {
        m_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 myViewportPos = m_cam.WorldToViewportPoint(transform.position);
        if (myViewportPos.x < -0.2 || myViewportPos.x > 1.2) //is Keyboard out of sight?
        {
            UpdateTargetPos();
        }
        float cameraDistance = (transform.position - m_cam.transform.position).magnitude;
        if (cameraDistance > maxDistance || cameraDistance < minDistance) //verify distance settings
        {
            UpdateTargetPos();
        } 


        //moving the keyboard towards the targetPos
        if ((transform.position - targetPos).sqrMagnitude > targetingAccuracy * targetingAccuracy)
        {
            transform.position += Time.deltaTime * travelSpeed * (targetPos - transform.position);
        }
        transform.LookAt(m_cam.transform.position); //Always look at cam
        transform.Rotate(0, 180, 0);
    }

    private void UpdateTargetPos()
    {
        targetPos = m_cam.transform.position + m_cam.transform.forward * defaultDistance;
    }
}
