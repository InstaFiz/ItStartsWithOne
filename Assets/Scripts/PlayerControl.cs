using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private Camera MainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = !Application.isFocused;
        Cursor.lockState = CursorLockMode.None;
        
        MoveWithMouse();
    }
    
    void MoveWithMouse()
    {
        if (!Application.isFocused) return;
        
        Vector3 mousePosition = Input.mousePosition;
        
        Vector3 targetPosition = MainCamera.ScreenToWorldPoint(mousePosition);
        
        targetPosition.z = transform.position.z;
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
