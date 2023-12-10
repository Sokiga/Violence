using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmeraControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject lookat;
    [SerializeField] float smooth;
    [SerializeField] Camera mainCamera;
    public Rigidbody body;

  
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x=lookat.transform.position.x;
        pos.z=lookat.transform.position.z;
        pos.y = 15;
        transform.position = pos;
        Vector3 cameraPos = SetCameraPos();
        transform.position=cameraPos;
     
    }
    public Vector3 GetVectorOffset()
    {
        Vector3 screenCenterPos=new Vector3(Screen.width*0.5f,0, Screen.height * 0.5f);
        Vector3 mousePos=new Vector3(Input.mousePosition.x,0, Input.mousePosition.y);   
        return mousePos - screenCenterPos;
    }
    public Vector3 SetCameraPos()
    {
        Vector3 offsetPos= GetVectorOffset();
        Vector3 cameraPos=new Vector3(lookat.transform.position.x,15,lookat.transform.position.z);
        cameraPos=cameraPos+offsetPos*0.001f;
        return cameraPos;
    } 
}
