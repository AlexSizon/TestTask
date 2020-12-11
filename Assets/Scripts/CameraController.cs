using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camSpeed = 15f;
    public float camBorderThickness = 10f;
    public Vector2 camLimit;
    public float camLimitMaxY;
    public float scrollSpeed = 20f;
    public float maxCamSize = 15;
    public float camSize = 6f;
    public Camera cam;
    private void Start()
    {
        if (GridGenerator.gridWidth==30)
        {
            camLimit.x *= 2;
            camLimit.y *= 2;
        }
        else if (GridGenerator.gridWidth==50)
        {
            camLimit.x *= 3.66f;
            camLimit.y *= 3.66f;
        }
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - camBorderThickness)
        {
            pos.y += camSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= camBorderThickness)
        {
            pos.y -= camSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - camBorderThickness)
        {
            pos.x += camSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= camBorderThickness)
        {
            pos.x -= camSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        camSize -= scroll * scrollSpeed * 100f * Time.deltaTime;
        camSize = Mathf.Clamp(camSize,6,maxCamSize);
        pos.x = Mathf.Clamp(pos.x,-camLimit.x,camLimit.x);
        pos.y = Mathf.Clamp(pos.y, -camLimit.y, camLimitMaxY);
        cam.orthographicSize = camSize;
        transform.position = pos;
    }
}
