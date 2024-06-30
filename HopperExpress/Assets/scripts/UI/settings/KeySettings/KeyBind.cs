using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeyBind : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackButtonText;
    [SerializeField] private TextMeshProUGUI jumpButtonText;

    private string currentKeyAction;

    private void Start()
    {
        attackButtonText.text = PlayerPrefs.GetString("AttackKey", KeyCode.Mouse0.ToString());
        jumpButtonText.text = PlayerPrefs.GetString("JumpKey", KeyCode.Space.ToString());
    }

    private void Update()
    {
        //if (currentKeyAction != null)
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        CancelKeyBinding();
        //        return;
        //    }

            foreach (KeyCode inputKey in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(inputKey))
                {
                    SetKeyBinding(currentKeyAction, inputKey);
                    UpdateKeyBindings();
                    currentKeyAction = null; 
                    break; 
                }
            }
        //}
    }

    public void SetAttackKey()
    {
        currentKeyAction = "AttackKey";
        attackButtonText.text = "«ö¤U«öÁä¿é¤J";
    }

    public void SetJumpKey()
    {
        currentKeyAction = "JumpKey";
        jumpButtonText.text = "«ö¤U«öÁä¿é¤J";
    }

    private void SetKeyBinding(string action, KeyCode key)
    {
        string keyName = key.ToString();

        switch (action)
        {
            case "AttackKey":
                attackButtonText.text = keyName;
                PlayerPrefs.SetString("AttackKey", keyName);
                break;

            case "JumpKey":
                jumpButtonText.text = keyName;
                PlayerPrefs.SetString("JumpKey", keyName);
                break;

            default:
                break;
        }

        PlayerPrefs.Save();
        UpdateKeyBindings();  
    }

    private void UpdateKeyBindings()
    {
        if (CharacterMove.instance != null)
        {
            CharacterMove.instance.UpdateKeyBindings();
        }
    }
    //private void CancelKeyBinding()
    //{
    //    if (currentKeyAction == "AttackKey")
    //    {
    //        attackButtonText.text = PlayerPrefs.GetString("AttackKey", KeyCode.Mouse0.ToString());
    //    }
    //    else if (currentKeyAction == "JumpKey")
    //    {
    //        jumpButtonText.text = PlayerPrefs.GetString("JumpKey", KeyCode.Space.ToString());
    //    }

    //    currentKeyAction = null; 
    //}
}
