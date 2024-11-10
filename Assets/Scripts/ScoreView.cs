using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreModel _scoreModel;
        [SerializeField] private TMP_Text _score;

        private void OnEnable()
        {
            _scoreModel.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _scoreModel.Changed -= OnChanged;
        }

        private void OnChanged(int score)
        {
            _score.text = score.ToString();
        }
    }
}