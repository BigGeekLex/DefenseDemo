using System;
using UnityEngine;

namespace Level
{
    public class RoundStatementController : MonoBehaviour
    {
        private RoundState _currentState = RoundState.Running;

        public RoundState CurrentRoundState
        {
            get => _currentState;
        }
        
        public event Action<RoundState> RoundStatementChanged;
        public bool TryChangeStatement(RoundState state)
        {
            if (_currentState != RoundState.Running) return false;

            _currentState = state;
            RoundStatementChanged?.Invoke(_currentState);
            return true;
        }
    }
}