using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    PhotonView view;
    public GameObject Explosion;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (view.isMine) {
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GameObject explosion = PhotonNetwork.Instantiate("SmallExplosion",transform.position,Quaternion.identity,0)as GameObject;
            Destroy(explosion,1.5f);
        }
    }
    // 
   
}
