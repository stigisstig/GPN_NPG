using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStuff : MonoBehaviour
{
    public Collider[] attackHitBoxes;
    GameObject projectile;
    bool attacking = false;
    float attackTime;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(attacking == false)
            {
                attacking = true;
                attackTime = 1.5f;
            }

        }
        if (attacking)
        {
           //for (float timeleft = 3.0f; timeleft >= 0; timeleft -= Time.deltaTime)    
           if (attackTime >= 0)
            {
                LaunchAttack(attackHitBoxes[0]);
                Debug.Log("Method Over2");
                attackTime -= Time.deltaTime;
            }
           else
            {
                attacking = false;
            }

        }
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            LaunchAttack(attackHitBoxes[1]);
        }*/
    }

    private void LaunchAttack(Collider col)
    {

        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        foreach (Collider c in cols)
        {
            
            string log = "";
            Debug.Log(c.name);
            if (c.transform.tag == transform.tag)
            continue;
            projectile = GameObject.FindGameObjectWithTag("projectile");

            try
            {
                log += c.transform.parent.parent.name;
                log += " " + c.name;
                Debug.Log(log);
                if (c.name == projectile.name)
                {
                    Destroy(c.gameObject, 0.1f);
                    Debug.Log("Projectile Slashed");
                }
            }
            catch
            {
                log += " " + c.name;
                Debug.Log(log);
                if (c.name == projectile.name)
                {
                    MoveToX script = c.gameObject.GetComponent<MoveToX>();
                    script.moveToTarget = false;
                    Debug.Log("Projectile Slashed");
                }
            }



        }
            
        
    }
}
