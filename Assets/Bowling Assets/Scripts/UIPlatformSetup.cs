using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIPlatformSetup : MonoBehaviour
{
    [SerializeField] TMP_Text instructionText;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
instructionText.text = "Press LEFT AND RIGHT TO CONTROL YOUR BALL AND THROW TO THROW";
#elif UNITY_STANDALONE || UNITY_STANDALONE_WIN
        instructionText.text = "ARROW KEYS CONTROL YOUR BALL'S MOVEMENT\r\nSPACE THROWS YOUR BALL";
#endif
    }

    // Update is called once per frame
    void Update()
    {
        instructionText.text = "ARROW KEYS CONTROL YOUR BALL'S MOVEMENT\r\nSPACE THROWS YOUR BALL";
    }
}
