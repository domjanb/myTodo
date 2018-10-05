using myTodo.views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace myTodo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            //MainPage = new MainPage();
            //MainPage = new NavigationPage(content);
            //MainPage = new NavigationPage(new TaskView());

            //MainPage = new NavigationPage(new TaskPage());
            MainPage = new NavigationPage(new TabbedTaskPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
