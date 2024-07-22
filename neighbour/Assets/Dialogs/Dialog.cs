
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPhrase;
    [SerializeField] private Button _answerButton;
    [SerializeField] private GameObject _panel;

    private List<Button> _buttons = new List<Button>();
    private LoadJson _loadJson;
    private int _firstReplica = 0;
    private int _exitReplica = -1;

    public static Action EndDialog;
    public static Action BeginDialog;

    public void StartDialog(string fileName)
    {
        _loadJson = LoadJson.CreateFromJSON(File.ReadAllText($"{Application.streamingAssetsPath}/{fileName}.json"));
        BeginDialog?.Invoke();
        NextReplica(_firstReplica);
    }

    private void NextReplica(int indexReplica)
    {
        if (indexReplica == _exitReplica)
        {
            EndDialog?.Invoke();
            Destroy(gameObject);
            return;
        }

        RemoveAllButton();

        Replica replica = _loadJson.Data[indexReplica];

        _textPhrase.text = replica.Phrase;

        foreach (Answer answer in replica.Answers)
        {
            Button btn = Instantiate(_answerButton, _panel.transform);
            TextMeshProUGUI textButton = btn.GetComponentInChildren<TextMeshProUGUI>();
            textButton.text = answer.Text;

            btn.onClick.AddListener(() => NextReplica(answer.Connect));

            _buttons.Add(btn);
        }
    }

    private void RemoveAllButton()
    {
        foreach (Button btn in _buttons)
        {
            Destroy(btn.gameObject);
        }
        _buttons.Clear();
    }
}


[Serializable]
public class LoadJson
{
    public List<Replica> Data;

    public static LoadJson CreateFromJSON(string json)
    {
        return JsonUtility.FromJson<LoadJson>(json);
    }

}

[Serializable]
public class Replica
{
    public string Phrase;
    public List<Answer> Answers;
}

[Serializable]
public class Answer
{
    public string Text;
    public int Connect;
}
