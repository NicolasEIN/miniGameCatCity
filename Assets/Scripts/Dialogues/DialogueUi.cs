using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image npcImage;
    [SerializeField] private TextMeshProUGUI npcNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private bool isDialogueActive = false;

    public void ShowDialogue(string dialogue, string npcName, Sprite npcSprite)
    {
        // Atualiza o nome e a imagem do NPC
        npcNameText.text = npcName;
        npcImage.sprite = npcSprite;

        // Exibe a caixa de di�logo
        dialoguePanel.SetActive(true);

        // Atualiza o texto do di�logo
        UpdateDialogue(dialogue);
    }

    public void UpdateDialogue(string dialogue)
    {
        // Atualiza o texto do di�logo
        dialogueText.text = dialogue;
    }

    public void HideDialogue()
    {
        // Verifica se o objeto dialoguePanel n�o � nulo antes de tentar acess�-lo
        if (dialoguePanel != null)
        {
            // Esconde a caixa de di�logo
            dialoguePanel.SetActive(false);
        }
    }

    //[Header("UI Elements")]
    //[SerializeField] private GameObject dialoguePanel;
    //[SerializeField] private Image npcImage;
    //[SerializeField] private TextMeshProUGUI npcNameText;
    //[SerializeField] private TextMeshProUGUI dialogueText;


    //public void ShowDialogue(string dialogue, string npcName, Sprite npcSprite)
    //{
    //    // Atualiza o texto do NPC na UI
    //    npcNameText.text = npcName;

    //    // Atualiza a imagem do NPC na UI
    //    npcImage.sprite = npcSprite;

    //    // Exibe a UI de di�logo
    //    dialoguePanel.SetActive(true);

    //    // Exibe o texto do di�logo na UI
    //    dialogueText.text = dialogue;
    //}



    //public void HideDialogue()
    //{
    //    // Esconde a UI de di�logo
    //    dialoguePanel.SetActive(false);
    //}

}