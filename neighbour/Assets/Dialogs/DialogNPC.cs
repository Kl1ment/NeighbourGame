
using UnityEngine;

public class DialogNPC : InteractiveObject
{
    [SerializeField] private Canvas _dialogUI;
    [SerializeField] private string _fileName;


    public override void Interactive()
    {
        Canvas dialog = Instantiate(_dialogUI);
        dialog.GetComponent<Dialog>().StartDialog(_fileName);
    }
}
