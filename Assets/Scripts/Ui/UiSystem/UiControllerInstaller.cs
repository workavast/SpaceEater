using System;
using Zenject;

namespace SourceCode.Ui.UiSystem
{
    public class UiControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var uiController = FindObjectOfType<UI_Controller>();
            if (uiController == null)
                throw new NullReferenceException($"ui controller is null");

            Container.BindInstance(uiController).AsSingle();
        }
    }
}