using UnityEngine;
using TMPro;

public class MessageDisplay : MonoBehaviour
{
   public TextMeshProUGUI messageText;

   public void ShowMessage (string message, float duration)
   {
      messageText.text = message;
      messageText.gameObject.SetActive(true);
      Invoke("HideMessage", duration);
   }

   void HideMessage ()
   {
      messageText.gameObject.SetActive(false);
   }
}
