using CustomDI;
using Level;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(WindowSwitcherCore), typeof(InstallerBase))]
    public class RoundStatementWindowSwitcherHandler : MonoBehaviour
    {
        private WindowSwitcherCore _windowSwitcherCore;
        private RoundStatementController _roundStatementController;

        private const string _roundResultWindowName = "RoundResult";
        private void Awake()
        {
            _windowSwitcherCore = GetComponent<WindowSwitcherCore>();
        }

        [Injectable]
        private void Init(RoundStatementController roundStatementController)
        {
            _roundStatementController = roundStatementController;
            _roundStatementController.RoundStatementChanged += RoundStatementChangedCallback;
        }

        private void OnDestroy()
        {
            _roundStatementController.RoundStatementChanged -= RoundStatementChangedCallback;
        }

        private void RoundStatementChangedCallback(RoundState roundState)
        {
            switch (roundState)
            {
                case RoundState.Loosed:
                    OpenRoundResultWindow();
                    break;
                case RoundState.Win:
                    OpenRoundResultWindow();
                    break;
            }
        }

        private void OpenRoundResultWindow()
        {
            _windowSwitcherCore.TryOpenWindow(_roundResultWindowName);
        }
    }
}