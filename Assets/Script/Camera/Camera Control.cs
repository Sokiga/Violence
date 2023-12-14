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
    public Rigidbody2D body;

  
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x=lookat.transform.position.x;
        pos.y=lookat.transform.position.y;
        pos.z = 15;
        transform.position = pos;
        Vector3 cameraPos = SetCameraPos();
        transform.position=cameraPos;
     
    }
    public Vector3 GetVectorOffset()
    {
        Vector3 screenCenterPos=new Vector3(Screen.width*0.5f, Screen.height * 0.5f, 0);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);   
        return mousePos - screenCenterPos;
    }
    public Vector3 SetCameraPos()
    {
        Vector3 offsetPos= GetVectorOffset();

        Vector3 cameraPos=new Vector3(lookat.transform.position.x,lookat.transform.position.y,15f);


        cameraPos=cameraPos+offsetPos*0.001f;
        return cameraPos;
    } 
}
