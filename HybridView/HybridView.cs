using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace HybridView
{
    public class HybridView : ContentPage
    {
        HybridWebView hybrid;
        private const string fileName = "Test.html";

        public HybridView()
        {
            var stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };

            var injectJsButton = new Button()
            {
                Text = "Inject JavaScript",
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            injectJsButton.Clicked += InjectJsButton_Clicked;

            var callCsFunctionButton = new Button()
            {
                Text = "CallJsFunction",
                BackgroundColor = Color.Purple,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            callCsFunctionButton.Clicked += CallCsFunctionButton_Clicked;
            
            hybrid = new HybridWebView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
           
            stack.Children.Add(injectJsButton);
            stack.Children.Add(callCsFunctionButton);
            stack.Children.Add(hybrid);

            Content = stack;
        }

        private void CallCsFunctionButton_Clicked(object sender, System.EventArgs e)
        {
            hybrid.CallJsFunction("demoAlert()");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var filePath = XLabs.Ioc.Resolver.Resolve<IFilePath>().GetFilePath();
            hybrid.LoadFromContent(filePath + "/" + fileName);
        }

        private void InjectJsButton_Clicked(object sender, System.EventArgs e)
        {
            hybrid.InjectJavaScript("alert(\"Hello world!\");");
        }
    }
}
