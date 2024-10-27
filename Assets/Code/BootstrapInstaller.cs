using Zenject;

namespace Code
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.BindInterfacesTo<CurrencyService>().AsSingle();
            Container.BindInterfacesTo<EnergyService>().AsSingle();
            Container.BindInterfacesTo<CurrencyPerTapService>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IStaticDataService>().LoadAll();
        }
    }
}
