using Code.Gameplay.AutoCollect;
using Code.Services.FloatingText;
using Code.Services.UI;
using UnityEngine;
using Zenject;

namespace Code
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private UiService _uiService;
        [SerializeField] private FloatingTextService _floatingTextService;
        
        public override void InstallBindings()
        {
            Container.Bind<IUiService>().FromInstance(_uiService).AsSingle();
            Container.Bind<IFloatingTextService>().FromInstance(_floatingTextService).AsSingle();
            
            Container.Bind<IInitializable>().To<SoftCurrencyAutoCollect>().AsSingle();
        }
    }
}