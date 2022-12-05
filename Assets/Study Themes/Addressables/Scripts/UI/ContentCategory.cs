using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using TMPro;

namespace StudyProject.Addressales.Content
{
    public class ContentCategory : MonoBehaviour
    {
        [SerializeField] protected CategorySwitcher _categorySwitcher = default;

        [SerializeField] private string _categoryName = default;
        [SerializeField] private TextMeshProUGUI _textMeshElement = default;

        [SerializeField] protected Button _previousAssetButton = default;
        [SerializeField] protected Button _nextAssetButton = default;
        [SerializeField] protected Button _resetAssetButton = default;

        protected int _currentCategory = default;

        private void OnEnable()
        {
            EnableContent(0);
            SetTextLabel();
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        public void SetActiveCategory(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        
        private void SetTextLabel()
        {
            _textMeshElement.text = _categoryName;
        }

        public void AddListeners()
        {
            _previousAssetButton.onClick.AddListener(EnablePreviousContent);
            _resetAssetButton.onClick.AddListener(ResetContent);
            _nextAssetButton.onClick.AddListener(EnableNextContent);
        }

        public void RemoveListeners()
        {
            _previousAssetButton.onClick.RemoveListener(EnablePreviousContent);
            _resetAssetButton.onClick.RemoveListener(ResetContent);
            _nextAssetButton.onClick.RemoveListener(EnableNextContent);
        }

        private void EnablePreviousContent()
        {
            EnableContent(_currentCategory - 1);
        }

        private void ResetContent()
        {
            EnableContent(0);
        }

        private void EnableNextContent()
        {
            EnableContent(_currentCategory + 1);
        }

        protected virtual void EnableContent(int contentIndex)
        {
            
        }
    }
}