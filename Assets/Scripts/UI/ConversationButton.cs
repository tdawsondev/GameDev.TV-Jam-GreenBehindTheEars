using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationButton : MonoBehaviour
{
    [SerializeField] Choice dialogChoice;
    [SerializeField] TextMeshProUGUI buttonText = null;



    public void SetChoice(Choice choice)
    {
        dialogChoice = choice;
        buttonText.text = choice.text;
    }

    public void SelectChoice()
    {
        foreach(DialogTask task in dialogChoice.tasks)
        {
            task.CallTask();
        }
        foreach(CharacterPoint cp in dialogChoice.characterPoints)
        {
            //NEED TO ADD LOGIC FOR REPUTATION HERE
        }

        Conversation.instance.OpenDialog(dialogChoice.nextDialog);
    }
}
