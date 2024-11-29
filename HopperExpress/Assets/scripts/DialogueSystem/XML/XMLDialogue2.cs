using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Data;
using System.Collections;

public class XMLDialogue2 : MonoBehaviour
{
    public Text RoleText;
    public Text DialogueText;
    public Image R1Image;
    public Image R2Image;
    XmlNodeList nodeList;
    DiaAnim2 dialogueAnimation;
    int n;
    private Coroutine typingCoroutine;
    private bool isTyping;

    public string dialogueFile;
    void Start()
    {
        dialogueAnimation = FindObjectOfType<DiaAnim2>();
        RoleText.text = "";
        DialogueText.text = "";
        R1Image.color = new Color(1f, 1f, 1f, 0f);
        R2Image.color = new Color(1f, 1f, 1f, 0f);

        string data = Resources.Load(dialogueFile).ToString();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(data);
        nodeList = xmlDoc.DocumentElement.ChildNodes;
        n = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&BattleDia2.FirstCoreHit)
        {
            if (isTyping)
            {
                SkipTypingAnimation();
            }
            else if (nodeList.Count > 0 && n < nodeList.Count)
            {
                string role = nodeList[n].FirstChild.InnerText;
                string dialogue = nodeList[n].LastChild.InnerText;

                RoleText.text = role;

                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }

                typingCoroutine = StartCoroutine(TypeDialogue(dialogue));
                UpdateCharacterImage(role);
                n++;
            }
            else
            {
                RoleText.text = "";
                DialogueText.text = "";
                EndConversation();
            }
        }
    }
    public IEnumerator StartFirstDialogue()
    {
        yield return new WaitForSecondsRealtime(1f);
        if (nodeList.Count > 0 && n < nodeList.Count)
        {
            string role = nodeList[n].FirstChild.InnerText;
            string dialogue = nodeList[n].LastChild.InnerText;

            RoleText.text = role;

            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            typingCoroutine = StartCoroutine(TypeDialogue(dialogue));
            UpdateCharacterImage(role);
            n++;
        }
    }


    IEnumerator TypeDialogue(string dialogue)
    {
        isTyping = true;
        DialogueText.text = "";

        foreach (char letter in dialogue)
        {
            DialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        isTyping = false;
    }

    void SkipTypingAnimation()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        DialogueText.text = nodeList[n - 1].LastChild.InnerText;
        isTyping = false;
    }

    void UpdateCharacterImage(string role)
    {
        if (role == "³Ç¥i")
        {
            R1Image.color = new Color(1f, 1f, 1f, 1f);
            R2Image.color = new Color(1f, 1f, 1f, 0.2f);
        }
        else if (role == "¦ã²ú¿Õ")
        {
            R1Image.color = new Color(1f, 1f, 1f, 0.2f);
            R2Image.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (role == "´£¥Ü")
        {
            R1Image.color = new Color(1f, 1f, 1f, 0.2f);
            R2Image.color = new Color(1f, 1f, 1f, 0.2f);
        }
    }

    void EndConversation()
    {
        R1Image.color = new Color(1f, 1f, 1f, 0f);
        R2Image.color = new Color(1f, 1f, 1f, 0f);
        dialogueAnimation.SlideOut();
    }
}
