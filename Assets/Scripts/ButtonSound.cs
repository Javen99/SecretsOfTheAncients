using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private AudioSource buttonAudio;
    
    void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    void PlaySound ()
    {
        buttonAudio.Play();
    }
}
