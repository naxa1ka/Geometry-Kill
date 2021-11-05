using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;

    public override void InstallBindings()
    {
        BindInstances();
        BindBallsHandler();
        BindDamageSystem();
        BindInput();
        BindGeneral();
        BindBallDetection();
        BindScore();
    }

    private void BindBallsHandler()
    {
        Container.BindInterfacesAndSelfTo<BallsHandler>().FromNew().AsSingle();
    }

    private void BindInstances()
    {
        Container.Bind<Spawner>().FromInstance(_spawner).AsSingle();
        Container.Bind<Player>().FromInstance(_player).AsSingle();
    }

    private void BindDamageSystem()
    {
        Container.BindInterfacesAndSelfTo<BallDamager>().FromNew().AsSingle();
    }

    private void BindInput()
    {
        Container.BindInterfacesAndSelfTo<MouseInput>().AsSingle();
    }

    private void BindGeneral()
    {
        Container.Bind<SceneManager>().FromNew().AsSingle();
        Container.Bind<TimeState>().FromNew().AsSingle();
        Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
    }

    private void BindBallDetection()
    {
        Container.BindInterfacesAndSelfTo<BallDetector>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<BallEdgeDetector>().FromNew().AsSingle();
    }

    private void BindScore()
    {
        Container.Bind<ScoreHandler>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<BestScoreHandler>().FromNew().AsSingle();
    }
}