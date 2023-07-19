using CustomDI;
using Level;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(InstallerBase))]
    public class RoundResultDisplayer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI resultText;
        
        private RoundStatementController _roundStatementController;
        
        [Injectable]
        private void Init(RoundStatementController roundStatementController)
        {
            _roundStatementController = roundStatementController;
        }
        private void OnEnable()
        {
            if(_roundStatementController != null) OnRoundStatementRefresh(_roundStatementController.CurrentRoundState);
        }

        private void OnRoundStatementRefresh(RoundState roundState)
        {
            switch (roundState)
            {
                case RoundState.Win:
                    RoundWinResultHandler();
                    break;
                case RoundState.Loosed:
                    RoundLooseResultHandler();
                    break;
            }
        }

        private void RoundWinResultHandler()
        {
            resultText.text = "Ты выиграл!";
            resultText.color = Color.green;
        }

        private void RoundLooseResultHandler()
        {
            resultText.text = "Ты проиграл!";
            resultText.color = Color.red;
        }
    }
}