using myTodo.viewModell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myTodo.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class taskListPage : ContentPage
	{
        
        public taskListPage(List<taskViewModell> vm)
		{
            
			InitializeComponent();
            lwTaskList.ItemsSource = vm;

        }

        
    }
}