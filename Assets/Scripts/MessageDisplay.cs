using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class MessageDisplay : MonoBehaviour
{
   public TextMeshProUGUI messageText;
   public GameObject messagePanel;
   private Coroutine messageCoroutine;

   private Queue<(string, float)> messageQueue = new Queue<(string, float)>();
   private bool isDisplayingMesage = false;

   private void Start ()
   {
      // Ensure the message is hidden at the start
      HideMessage();
   }

   private void Update ()
   {
      if (messageText.gameObject.activeInHierarchy)
      {
         if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
         {
            HideMessage();
         }
      }
   }

   public void ShowMessage (string message, float duration)
   {
      messageQueue.Enqueue((message, duration));
      if (!isDisplayingMesage)
      {
         StartCoroutine(ProcessMessageQueue());
      }
   }

   private IEnumerator ProcessMessageQueue ()
   {
      isDisplayingMesage = true;
      while (messageQueue.Count > 0)
      {
         var (message, duration) = messageQueue.Dequeue();
         messageText.text = message;
         messageText.gameObject.SetActive(true);
         if (messagePanel != null)
         {
            messagePanel.SetActive(true);
         }
      
         yield return new WaitForSeconds(duration);
      }
      HideMessage();
      isDisplayingMesage = false;
   }

   void HideMessage ()
   {
      messageText.gameObject.SetActive(false);
      if (messagePanel != null)
      {
         messagePanel.SetActive(false);
      }
   }
}
