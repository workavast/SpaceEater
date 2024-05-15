using UnityEngine;
using Zenject;

namespace SourceCode.Ui.UiSystem.Screens
{
    public abstract class UI_ScreenBase : MonoBehaviour
    {
        [Inject] protected readonly UI_Controller UIController;

        public void SetActive(bool isActive)
            => gameObject.SetActive(isActive);
    }
}