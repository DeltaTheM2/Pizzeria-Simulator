using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingManager : MonoBehaviour
{
    public List<Transform> seats = new List<Transform>();
    public Transform[] vacantSeatsDEBUG;
    public Transform[] takenSeatsDEBUG;
    private Stack<Transform> vacantSeats = new Stack<Transform>();
    private Stack<Transform> takenSeats = new Stack<Transform>();

    private static WaitingManager _instance;
    public static WaitingManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        foreach (Transform s in seats) {
            vacantSeats.Push(s);
        }
    }

    public void Update() {
        vacantSeatsDEBUG = vacantSeats.ToArray();
        takenSeatsDEBUG = takenSeats.ToArray();
    }

    public Transform TakeSeat() {
        //there are no more seats available (conversely also means takenSeats == seats)
        if (vacantSeats.Count == 0) {
            print("There are no vacant seats");
            return null;
        } else {
            takenSeats.Push(vacantSeats.Pop());
            return takenSeats.Peek();
        }
    }

    public void FreeSeat() {
        //there are no taken seats to be freed (conversely also means vacantSeats == seats)
        if (takenSeats.Count == 0) {
            print("There are no free seats");
            return;
        } else {
            vacantSeats.Push(takenSeats.Pop());
        }
    }

    public bool VacantSeatAvailable() {
        return vacantSeats.Count > 0;
    }

    public void AddNewVacantSeat(Transform s){ 
        vacantSeats.Push(s);
    }
}
