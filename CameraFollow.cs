using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraMoveSpeed = 120f;
    public GameObject cameraFollowObj;
    Vector3 followPos;
    public float clampAngle = 80f;
    public float inputSensitivity = 150f;
    public GameObject cameraObj;
    public GameObject playerObj;
    public float camDistanaceXToPlayer;
    public float camDistanaceYToPlayer;
    public float camDistanaceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputY;
    public float smoothX;
    public float smoothY;
    private float rotX = 0f;
    private float rotY = 0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = mouseX;
        finalInputY = mouseY;

        rotY = mouseY + inputSensitivity * Time.deltaTime;
        rotX = mouseX + inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        
    }

    void FixedUpdate()
    {
        CameraUpdater();
    }

    public void CameraUpdater()
    {
        Transform target = cameraFollowObj.transform;
        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}