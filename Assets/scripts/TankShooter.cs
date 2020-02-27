using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour {
    PhotonView view;
    public GameObject Bullet;
    public int force = 30;

    // Start is called before the first frame update
    void Start() {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update() {
        //if (view.isMine && Input.GetKeyDown(KeyCode.Space)) {
        //    view.RPC("shootBullet", PhotonTargets.All, transform.Find("ShootPoint").transform.position, transform.Find("ShootPoint").transform.rotation);
        //}
    }
    [PunRPC]
    void shootBullet(Vector3 vect, Quaternion quat) {
        GameObject bult = Instantiate(Bullet, vect, quat) as GameObject;
        bult.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * force);
        Destroy(bult, 1f);
    }

    // 
    public void Bullet_Force() {
        if (view.isMine) {
            view.RPC("shootBullet", PhotonTargets.All, transform.Find("ShootPoint").transform.position, transform.Find("ShootPoint").transform.rotation);
        }
    }
}
