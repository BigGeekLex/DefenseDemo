using CustomDI;
using Units;
using UnityEngine;

namespace Level
{
    public class LooseRoundConditionChecker : MonoBehaviour
    {
        private Player _player;
        private RoundStatementController _roundStatementController;
        
        [Injectable]
        private void Init(Player player, RoundStatementController roundStatementController)
        {
            _player = player;
            _player.UnitDied += OnPlayerDeathCallback;
            _roundStatementController = roundStatementController;
        }

        private void OnPlayerDeathCallback()
        {
            _player.UnitDied -= OnPlayerDeathCallback;
            ChangeRoundStatementRequest();
        }
        
        private void ChangeRoundStatementRequest()
        {
            _roundStatementController.TryChangeStatement(RoundState.Loosed);
        }
    }
}