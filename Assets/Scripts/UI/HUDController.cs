using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{

    #region Singleton

    public static HUDController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one HUDController Object");
        }
        instance = this;
    }
    #endregion

    public TextMeshProUGUI interactionText;


    // Start is called before the first frame update
    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Activates UI Interaction Message
    /// </summary>
    /// <param name="i"></param>
    public void ShowInteractionMessage(Interactable i)
    {
        interactionText.text = "(E) " + i.message;
        interactionText.gameObject.SetActive(true);
    }
    /// <summary>
    /// Deactives UI Interaction Message
    /// </summary>
    public void HideInteractionMessage()
    {
        interactionText.gameObject.SetActive(false );
    }
}
