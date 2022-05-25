using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{

    [Header("Dialogue")]
    [SerializeField] GameObject DialogueOptionsParent = null;
    [SerializeField] GameObject DialogueChoiceObject = null;
    [SerializeField] int numberOfDialogueOptions = 3;

    [Header("SpeakerImage")]
    [SerializeField] Image speakerImage = null;
    [SerializeField] Image speakerSourceImage = null;  /*DELETE*/ //Will not need this once we are calling from outside of the class.

    /*DELETE*/
    //Will not need this once it is being called from outside of class.
    private void Start()
    {
        UpdateDialogueUI();
    }

    /// <summary>
    /// Sets all of the dialogue options in a vertical group based on number of choices.
    /// </summary>
    private void PopulateDialogueOptions()
    {
        for (int i = 0; i < numberOfDialogueOptions; i++)
        {
            GameObject dialogueObject = Instantiate(DialogueChoiceObject);
            dialogueObject.transform.parent = DialogueOptionsParent.transform;
        }
    }

    /// <summary>
    /// Updates the dialogue options and image based on current information.
    /// </summary>
    private void UpdateDialogueUI()
    {
        PopulateDialogueOptions();
        SetSpeakerImageSprite(speakerSourceImage.sprite);
        //PopulateSpeakerImage();
    }

    #region Setters
    /// <summary>
    /// How many dialogue options player has this screen.
    /// </summary>
    /// <param name="numOptions">Total number of available options.</param>
    public void SetNumberOfDialogueOptions(int numOptions)
    {
        numberOfDialogueOptions = numOptions;
    }

    /// <summary>
    /// Image of who is speaking with the player.
    /// </summary>
    /// <param name="newImage">Picture of conversation partner.</param>
    public void SetSpeakerImageSprite(Sprite newSprite)
    {
        speakerImage.sprite = newSprite;
    }

    #endregion

}
