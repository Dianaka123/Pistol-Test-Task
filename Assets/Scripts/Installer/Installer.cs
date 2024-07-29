using Assets.Scripts.Handlers;
using Assets.Scripts.Managers;
using Zenject;

namespace Assets.Scripts.Installer
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameWorldInitializer>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle();
        }
    }
}
