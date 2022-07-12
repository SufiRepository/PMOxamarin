using PMOApp.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMOApp.Views.MainButtonPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainButton : ContentPage
    {
        public MainButton()
        {
            InitializeComponent();
            AppearingAnimation();
        }

        #region"Animation"
        public async void AppearingAnimation()
        {
            await Task.WhenAll
                   (

                   ViewAnimation.FadeOut(TxtLabel),
                   ViewAnimation.FadeOut(btn1),
                   ViewAnimation.FadeOut(btn2),
                   ViewAnimation.FadeOut(btn3),
                   ViewAnimation.FadeOut(btn4),
                   ViewAnimation.FadeOut(btn5),
                   ViewAnimation.FadeOut(btn6),
                   ViewAnimation.FadeOut(btnback)

                   );

            await Task.WhenAll
                (
                ViewAnimation.FadeInNew(TxtLabel),
                ViewAnimation.FadeInNew(btn1),
                ViewAnimation.FadeInNew(btn2),
                ViewAnimation.FadeInNew(btn3),
                ViewAnimation.FadeInNew(btn4),
                ViewAnimation.FadeInNew(btn5),
                ViewAnimation.FadeInNew(btn6),
                ViewAnimation.FadeInNew(btnback)
                );

            
          
        }
        #endregion"Animation"

        #region"Button"
        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }
        #endregion"Button"
    }
}