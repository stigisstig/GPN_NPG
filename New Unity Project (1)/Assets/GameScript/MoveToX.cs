using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToX : MonoBehaviour
{
    public GameObject spawner;
    public Transform mTarget;
    public bool moveToTarget = true;
    float mSpeed = 3.5f;
    const float EPSILON = 0.1f;
    float timeb4respawn = 2;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveToTarget)
        {
            timeb4respawn = 2;
            transform.LookAt(mTarget.position);
            if ((transform.position + mTarget.position).magnitude > EPSILON)
                transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
        }
        else
        {
           
            transform.position = spawner.transform.position;
            if(timeb4respawn > 0)
            {
                Debug.Log("Time left: " + timeb4respawn);
                timeb4respawn -= Time.deltaTime;
            }
            else
            {
                moveToTarget = true;
            }
        }
        
        

    }
}
