using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayertorso : MonoBehaviour
{
   public Transform body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = body.position.x ;
        float y = body.position.y ;
        float z = body.position.z ;
        transform.position = new Vector3(x+0.5f,y+1f,z);
    }
}
