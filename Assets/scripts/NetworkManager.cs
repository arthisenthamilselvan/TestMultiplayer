using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NetworkManager : MonoBehaviour
{
    public Text TextInfo;
    public Transform Spawnpoint1;
    public Transform Spawnpoint2;
    public GameObject Target1;
    public GameObject Target2;
    public GameObject myplayer1, myplayer2;
    public TankShooter tank;
    void Start()
    {
        
        PhotonNetwork.ConnectUsingSettings("v01");
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.connectionStateDetailed.ToString() != "Joined") {
            TextInfo.text = PhotonNetwork.connectionStateDetailed.ToString();
        }
        else {
            TextInfo.text = "connected To" + PhotonNetwork.room.name + "player(s) online" + PhotonNetwork.room.playerCount; 
        }
    }
   public void OnConnectedToMaster() {
        print("connected with master--");
        PhotonNetwork.JoinLobby();
    }

   
    public void OnJoinedLobby() {
        print("connected with lobby--");
        RoomOptions myRoomOptions = new RoomOptions();
        myRoomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("Room1",myRoomOptions,TypedLobby.Default);
    }
    GameObject TankIns;
    void OnJoinedRoom() {
        // TankIns = PhotonNetwork.Instantiate("Tank", transform.position, transform.rotation, 0) as GameObject;

        // if (TankIns.GetComponent<PhotonView>().isMine) {
        if (PhotonNetwork.playerList.Length > 1) {
            print("1------->");
            StartCoroutine(SpawnPlayer1());
        }
        else {
            print("2------->");
            StartCoroutine(SpawnPlayer2());
        }

        //if (PhotonNetwork.isMasterClient) {
        //    //if (PhotonNetwork.playerList.Length > 1) {
        //        StartCoroutine(SpawnPlayer1());
        //    //}
        //}
        //else {
        //    StartCoroutine(SpawnPlayer2());
        //}
    }


    IEnumerator SpawnPlayer1() {
        yield return new WaitForSeconds(1f);
        myplayer1 = PhotonNetwork.Instantiate("Tank", Spawnpoint1.position, Spawnpoint1.rotation, 0) as GameObject;
        myplayer1.transform.parent = Target1.transform;
        myplayer1.transform.SetParent(Target1.transform, false);

        //myplayer1 = TankIns;
        //TankIns.transform.position = Spawnpoint1.position;
        //TankIns.transform.rotation = Spawnpoint1.rotation;
        //myplayer1.transform.parent = Target1.transform;
    }
    IEnumerator SpawnPlayer2() {
        yield return new WaitForSeconds(1f);
        myplayer1 = PhotonNetwork.Instantiate("Tank", Spawnpoint2.position, Spawnpoint2.rotation, 0) as GameObject;
        myplayer1.transform.parent = Target1.transform;
        myplayer1.transform.SetParent(Target1.transform,false);

        //myplayer2 = TankIns;
        //TankIns.transform.position = Spawnpoint2.position;
        //TankIns.transform.rotation = Spawnpoint2.rotation;
        //myplayer2.transform.parent = Target2.transform;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
              stream.SendNext(Target1);
            stream.SendNext(Target2);
        }
        else if (stream.isReading) {
            Target1=(GameObject)stream.ReceiveNext();
            Target2 = (GameObject)stream.ReceiveNext();
        }
    }

    //
    public void FireBtn_Click() {
        myplayer1.GetComponent<TankShooter>().Bullet_Force();

    }
}
