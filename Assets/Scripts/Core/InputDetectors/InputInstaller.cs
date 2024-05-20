using Joystick_Pack.Scripts.Joysticks;
using Zenject;

namespace SourceCode.Core.InputDetectors
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var joystick = FindObjectOfType<Joystick>();
            Container.BindInterfacesAndSelfTo<DesktopInput>().FromNew().AsSingle().WithArguments(joystick);
        }
    }
}