using Assets.Scripts.Handlers;
using Assets.Scripts.InputSystem.Implementation;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using Zenject;

namespace Assets.Scripts.Installer
{
    public class Installer : MonoInstaller
    {
        public Bullet Bullet;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameWorldInitializer>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle();

            Container.BindInterfacesAndSelfTo<ShootSystem>().AsSingle();

            Container.BindMemoryPool<Bullet, Bullet.Pool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(Bullet)
                .UnderTransformGroup("Bullets");
        }
    }
}
