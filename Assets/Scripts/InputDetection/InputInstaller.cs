using Joystick_Pack.Scripts.Joysticks;
using Zenject;

namespace SourceCode.InputDetection
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