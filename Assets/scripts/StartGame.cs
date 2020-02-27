using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
public class StartGame : MonoBehaviour
{
    public Button startgamebutton;
    public GameObject networkmanager;
    bool IsAccess;
  
    void Start()
    {
        startgamebutton.onClick.AddListener(startGameFunc);
    }

    void startGameFunc() {
        startgamebutton.gameObject.SetActive(false);
        networkmanager.SetActive(true);
    }

   

    public void OnEnableTank() {
        startGameFunc();
    }
    
}
