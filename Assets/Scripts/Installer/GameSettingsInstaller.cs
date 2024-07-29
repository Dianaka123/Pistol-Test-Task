using Assets.Scripts.Configurations;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public PlayerConfiguration PlayerConfiguration;
    public EnemiesConfiguration EnemiesConfiguration;
    public WeaponsConfiguration WeaponsConfiguration;
    public EnviromentConfiguration EnviromentConfiguration;

    public override void InstallBindings()
    {
        Container.BindInstances(PlayerConfiguration, EnemiesConfiguration, WeaponsConfiguration, EnviromentConfiguration);
    }
}
