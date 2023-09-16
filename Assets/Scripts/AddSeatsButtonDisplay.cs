using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSeatsButtonDisplay : MonoBehaviour
{
    private Color defaultColor;
    public Color toggledColor;
    Button button;
    Image image;

    void Awake() {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        defaultColor = image.color;
    }

    void Update() {
        if (FundManager.Instance.funds <= 50) {
            button.interactable = false;
        } else {
            button.interactable = true;
        }

        if (GameManager.Instance.currentlyPlacingSeats) {
            image.color = toggledColor;
        } else {
            image.color = defaultColor;
        }
    }
}
