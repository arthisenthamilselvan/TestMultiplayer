using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class Movement : MonoBehaviour, IPunObservable
{
    PhotonView view;
    public Vector3 pos;
    public Quaternion rot;

    void Start() 
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        //if (PhotonNetwork.isMasterClient) {
        //    if (view.ownerId == 0) {
        //if (PhotonNetwork.isMasterClient) 
        //{
        //    if (view.ownerId == 0) 
        //    {
        //        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        //        transform.Rotate(0, x, 0);
        //        transform.Translate(0, 0, z);
        //    }

        //        pos = transform.position;
        //        rot = transform.rotation;
        //    }

        //        if (view.ownerId == 1) {
        //            transform.position = pos;
        //            transform.rotation = rot;
        //        }
        //    }
        //    else if (!PhotonNetwork.isMasterClient) {
        //        if (view.ownerId == 1) {
        //            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        //            transform.Rotate(0, x, 0);
        //            transform.Translate(0, 0, z);

        //            pos = transform.position;
        //            rot = transform.rotation;
        //        }

        //        if (view.ownerId == 0) {
        //            transform.position = pos;
        //            transform.rotation = rot;
        //        }
        //    }
        //}
    
}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            stream.SendNext(pos);
            stream.SendNext(rot);
        }
        else if (stream.isReading) {
            pos = (Vector3)stream.ReceiveNext();
            rot = (Quaternion)stream.ReceiveNext();
        }

    }


}
