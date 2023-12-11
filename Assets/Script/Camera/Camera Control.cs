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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

        pos.y = lookat.transform.position.y;

=======
        pos.y=lookat.transform.position.y;
>>>>>>> parent of f80107e (Text1)
        pos.z = 15;
=======
        pos.z=lookat.transform.position.z;
        pos.y = 15;
>>>>>>> parent of b38d41a (Text)
=======
        pos.z=lookat.transform.position.z;
        pos.y = 15;
>>>>>>> parent of ced1ad7 (vio)
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

        Vector3 cameraPos=new Vector3(lookat.transform.position.x,lookat.transform.position.y,15f);

=======
        Vector3 cameraPos=new Vector3(lookat.transform.position.x,lookat.transform.position.y,15f);
>>>>>>> parent of f80107e (Text1)
=======
        Vector3 cameraPos=new Vector3(lookat.transform.position.x,15,lookat.transform.position.z);
>>>>>>> parent of b38d41a (Text)
=======
        Vector3 cameraPos=new Vector3(lookat.transform.position.x,15,lookat.transform.position.z);
>>>>>>> parent of ced1ad7 (vio)
        cameraPos=cameraPos+offsetPos*0.001f;
        return cameraPos;
    } 
}
