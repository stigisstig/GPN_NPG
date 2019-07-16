using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    void Update()
    {

    }
    public void bulletbullettime()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
    public void backtonormal()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.01f;
    }


}
