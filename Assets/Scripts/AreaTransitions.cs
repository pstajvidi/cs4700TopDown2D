using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    private CameraController cam; 

    public Vector2 newMinPosition;
    public Vector2 newMaxPosition;
    public Vector3 movePlater; 
    // Start is called before the first frame update
    void Start()
    {
        cam= Camera.main.GetComponent<CameraController>();
        if (cam == null)
        {
            Debug.LogError("CameraController not found on the main camera.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition = newMinPosition;
            cam.maxPosition = newMaxPosition;
            other.transform.position += movePlater;
        }
    }
}
