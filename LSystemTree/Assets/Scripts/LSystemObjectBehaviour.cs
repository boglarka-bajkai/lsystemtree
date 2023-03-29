using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LSystemObjectBehaviour : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    private LSystem system;

    public void Start()
    {
        system = new LSystem();
        _text.SetText(system.Axiom);
    }

    public void ButtonClicked()
    {
        _text.SetText(system.IterateForward());
    }
}
