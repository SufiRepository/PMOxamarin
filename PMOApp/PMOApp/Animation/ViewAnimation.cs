using System.Threading.Tasks;
using Xamarin.Forms;

namespace PMOApp.Animation
{
    public static class ViewAnimation
    {
        public static async Task FadeAnimY(View view)
        {


            await Task.WhenAll
               (
                    view.FadeTo(1, 200),
                    view.TranslateTo(0, 0, 200)
               );
        }
        public static async Task FadeOut(View view)
        {
            await view.FadeTo(0, 100, Easing.SinInOut);
        }

        public static async Task FadeIn(View view)
        {
            await view.FadeTo(1, 1200, Easing.SinInOut);

        }
        public static async Task FadeInNew(View view)
        {
            await view.FadeTo(1, 1200, Easing.CubicInOut);

        }

        public static async Task FadeINewFast(View view)
        {
            await view.FadeTo(1, 700, Easing.CubicInOut);

        }

        public static async Task ScaleIn(View view)
        {
            //await view.ScaleTo(0, 1);
            await view.ScaleTo(1, 1200, Easing.SpringOut);
        }

        public static async Task ScaleOut(View view)
        {
            await view.ScaleTo(1, 750, Easing.SinInOut);
        }
    }
}
