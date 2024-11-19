using UnityEngine;

public class TriggerMessage : MonoBehaviour
{
    [TextArea]
    public string messageText;
    public float displayDuration = 5f;
    public string messageID;

    private MessageDisplay messageDisplay;
    private bool messageShown = false;
    
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
            messageShown = true;
            
            // Destroy the trigger after activation
            Destroy(gameObject);
        }
    }
}
