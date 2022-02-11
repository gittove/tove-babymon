using System;
using TMPro;
using UnityEngine;

public class TutorialToy : MonoBehaviour
{
    [Header("Texts to display: ")]
    [SerializeField, TextArea(5, 10)] 
    private string keyText;
    [SerializeField, TextArea(5, 10)] 
    private string instructionText;

    [Header("References: ")]
    [SerializeField] 
    private Tutorial tutorial;
    [SerializeField] 
    private GameObject toyTextBox;

    private TextMeshProUGUI textBox;
    private bool isPickedUp;
    private string playerTag = "Player";
    private void Awake()
    {
        textBox = toyTextBox.GetComponent<TextMeshProUGUI>();
        isPickedUp = false;
    }

    private void Start()
    {
        toyTextBox.SetActive(false);
        isPickedUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tutorial.CurrentState == TutorialState.PickUp && other.CompareTag(playerTag))
        {
            if (!isPickedUp)
            {
                toyTextBox.SetActive(true);
                textBox.text = keyText;
                isPickedUp = true;
            }
        }
    }

    public void ChangeOnPickedUp()
    {
        textBox.text = instructionText;
    }
}
