using CustomDI;
using HP;
using TMPro;
using Units;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI), typeof(InstallerBase))]
    public class PlayerHealthDisplayer : MonoBehaviour
    {
        [SerializeField] 
        private string prefixText = "Здоровье: ";
        
        private TextMeshProUGUI _healthText;
        private IHP _playerHP;
        
        [Injectable]
        private void Init(Player player)
        {
            _playerHP = player.GetUnitHealth();
            _playerHP.HealthChanged += HealthPlayerHealthChangedCallback;
            HealthPlayerHealthChangedCallback();
        }

        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            _playerHP.HealthChanged -= HealthPlayerHealthChangedCallback;
        }

        private void HealthPlayerHealthChangedCallback()
        {
            _healthText.text = prefixText + _playerHP.GetCurrentHealth();
        }
    }
}