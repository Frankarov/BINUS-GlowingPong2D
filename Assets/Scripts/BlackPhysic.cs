using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPhysic : MonoBehaviour
{

        private void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.collider.CompareTag("BlackBall"))
                {
                    Destroy(coll.gameObject);
                }
        }
    


}
