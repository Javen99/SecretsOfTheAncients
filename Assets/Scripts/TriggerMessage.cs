using System;
using UnityEngine;

public class TriggerMessage : MonoBehaviour
{
    public string messageText;
    public float displayDuration = 3f;

    private MessageDisplay messageDisplay;
    
    void Start()
    {
        // Find the MessageDisplay script in the scene
        messageDisplay = FindObjectOfType<MessageDisplay>();
        if (messageDisplay == null)
        {
            Debug.LogError("MessageDisplay script not found in the scene");
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the ShowMessage method
            messageDisplay.ShowMessage(messageText, displayDuration);
            
            // Optionally, destroy the trigger after activation
            Destroy(gameObject);
        }
    }
}
