using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public Camera gameCamera;
    public Camera upgradeCamera;

    public GameObject gameHUD;
    public GameObject upgradeHUD;

    public SeatPlacer seatPlacer;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    
        seatPlacer.enabled = false;
        SwitchToGameplay();
        // SwitchToUpgrade();
    }

    public void SwitchToGameplay() {
        gameCamera.enabled = true;
        upgradeCamera.enabled = false;

        gameHUD.SetActive(true);
        upgradeHUD.SetActive(false);
    }

    public void SwitchToUpgrade() {
        gameCamera.enabled = false;
        upgradeCamera.enabled = true;

        gameHUD.SetActive(false);
        upgradeHUD.SetActive(true);
    }

    public void ToggleSeatPlacer() {
        seatPlacer.enabled = !seatPlacer.enabled;
    }
}
