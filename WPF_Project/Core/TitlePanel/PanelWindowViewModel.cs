using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers.Animation;

namespace Core.TitlePanel
{
    public class PanelWindowViewModel : TitlePanelViewModel
    {
        public PanelWindowViewModel()
        {
            ShadowBlur = 20;
            ShadowHeight = 0;
            PanelLoadAnimation = WindowAnimation.ShowScaleAndFadeIn;
            PanelUnloadAnimation = WindowAnimation.HideScaleAndFadeOut;
            AnimationSeconds = 0.2f;
        }

        public void SetScaleAnimation()
        {
            PanelLoadAnimation = WindowAnimation.ShowScaleAndFadeIn;
            PanelUnloadAnimation = WindowAnimation.HideScaleAndFadeOut;
            AnimationSeconds = 0.1f;
        }


        public void SetFadeAnimation()
        {
            PanelLoadAnimation = WindowAnimation.ShowFadeIn;
            PanelUnloadAnimation = WindowAnimation.HideFadeOut;
            AnimationSeconds = 0.1f;
        }
    }
}
