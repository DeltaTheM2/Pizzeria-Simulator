using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public Camera gameCamera;
    public Camera upgradeCamera;

    public GameObject[] gameThings;
    public GameObject[] upgradeThings;
    public GameObject losePanel;

    public SeatPlacer seatPlacer;
    public bool currentlyPlacingSeats;
    public int workers;

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
    
        currentlyPlacingSeats = false;
        seatPlacer.enabled = false;

        SwitchToGameplay();
        // SwitchToUpgrade();
    }

    public void SwitchToGameplay() {
        gameCamera.enabled = true;
        upgradeCamera.enabled = false;

        foreach (GameObject g in gameThings) {
            g.SetActive(true);
        }
        foreach (GameObject g in upgradeThings) {
            g.SetActive(false);
        }
    }

    public void SwitchToUpgrade() {
        gameCamera.enabled = false;
        upgradeCamera.enabled = true;

        foreach (GameObject g in gameThings) {
            g.SetActive(false);
        }
        foreach (GameObject g in upgradeThings) {
            g.SetActive(true);
        }
    }

    public void ToggleSeatPlacer() {
        seatPlacer.enabled = !seatPlacer.enabled;
        currentlyPlacingSeats = !currentlyPlacingSeats;
    }

    public void AddWorker() {
        if (FundManager.Instance.funds >= 100) {
            FundManager.Instance.funds -= 100;
            workers++;   
        }
    }

    public void ProgressDay() {
        SwitchToGameplay();
        DayManager.Instance.OnAfterFirstDay();
        DayManager.Instance.StartDay();
    }

    public void OnDayOver() {
        float utilities = 100;
        float workerCost = workers * 25;

        if (FundManager.Instance.funds - utilities - workerCost <= 0) {
            Bankrupt();
        } else {
            SwitchToUpgrade();
        }
    }

    public void Bankrupt()
    {
        losePanel.SetActive(true);
        SceneManager.LoadScene("Menu");
    }
}
