using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    PhotonView view;

    private void Start() {
        view = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (PhotonNetwork.isMasterClient) {
            if (view.ownerId == 0) {
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
                var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
                transform.Rotate(0, x, 0);
                transform.Translate(0, 0, z);
            }
        }
       
    }
}
