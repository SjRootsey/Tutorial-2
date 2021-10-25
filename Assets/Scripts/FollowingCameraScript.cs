using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCameraScript : MonoBehaviour
{
    public Transform followTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(followTransform.transform.position.x, followTransform.transform.position.y, this.transform.position.z);
    }
}
