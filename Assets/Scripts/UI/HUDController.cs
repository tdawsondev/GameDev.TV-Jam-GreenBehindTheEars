using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public GameObject addedToParent;
    public TextMeshProUGUI addedToText;
    public Image addedIcon;


    // Start is called before the first frame update
    void Start()
    {
        addedToParent.SetActive(false);
        interactionText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemNotification(Item item)
    {
        addedToText.text = "Added " + item.name;
        addedIcon.sprite = item.icon;
        StopCoroutine(ShowAddItem());
        StartCoroutine(ShowAddItem());

    }

    IEnumerator ShowAddItem()
    {
        addedToParent.SetActive(true);
        yield return new WaitForSeconds(3f);
        addedToParent.SetActive(false);
    }

    /// <summary>
    /// Activates UI Interaction Message
    /// </summary>
    /// <param name="i"></param>
    public void ShowInteractionMessage(Interactable i)
    {
        interactionText.text = "(E) (RB Gamepad) " + i.message;
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
