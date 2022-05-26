using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conversation : MonoBehaviour
{
    #region Singleton

    public static Conversation instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Conversation Object");
        }
        instance = this;
    }
    #endregion

    
    [SerializeField] GameObject DialogueMenu = null;

    [Header("Dialogue")]
    [SerializeField] GameObject DialogueOptionsParent = null;
    [SerializeField] GameObject DialogueChoiceObject = null;
    public DialogObject dialogObject;
    [SerializeField] TextMeshProUGUI speakerText;
    [SerializeField] TextMeshProUGUI dialogText;
    List<GameObject> dialogButtons = new List<GameObject>();



    [Header("SpeakerImage")]
    [SerializeField] Image speakerImage = null;


    PlayerMovement pm = null;


    private void Start()
    {
        pm = PlayerMovement.instance;
    }

    /// <summary>
    /// Sets all of the dialogue options in a vertical group based on number of choices.
    /// </summary>
    private void PopulateDialogueOptions()
    {
        foreach(GameObject go in dialogButtons)
        {
            Destroy(go);
        }
        dialogButtons = new List<GameObject>();
        foreach(Choice choice in dialogObject.choices)
        {
            GameObject dialogueObject = Instantiate(DialogueChoiceObject);
            dialogueObject.transform.SetParent(DialogueOptionsParent.transform);
            dialogueObject.transform.localScale = new Vector3(1, 1, 1);
            ConversationButton cb = dialogueObject.GetComponent<ConversationButton>();
            dialogButtons.Add(dialogueObject);
            if (cb != null)
            {
                cb.SetChoice(choice);
            }
        }

        if (dialogButtons.Count > 0)
            dialogButtons[0].GetComponent<Button>().Select();

        if(pm == null) { Debug.Log($"No player movement connected."); return; }

        pm.enabled = false;


    }

    /// <summary>
    /// Updates the dialogue options and image based on current information.
    /// </summary>
    private void UpdateDialogueUI()
    {
        PopulateDialogueOptions();
        dialogText.text = dialogObject.dialogText;
        speakerText.text = dialogObject.Speaker.characterName;
        speakerImage.sprite = dialogObject.Speaker.characterImage;
    }

    public void OpenDialog(DialogObject dobj)
    {
        dialogObject = dobj;
        if (dialogObject != null)
        {
            UpdateDialogueUI();
            DialogueMenu.SetActive(true);
        }
        else
        {
            CloseDialog();
        }

    }
    public void CloseDialog()
    {
        DialogueMenu.SetActive(false);

        if (pm == null) { Debug.Log($"No player movement connected."); return; }

        pm.enabled = true;

    }

}
