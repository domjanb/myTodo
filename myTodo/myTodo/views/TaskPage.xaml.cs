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
	public partial class TaskPage : ContentPage
	{
        private taskViewModell vm;
        List<taskViewModell> list = new List<taskViewModell>();

        public TaskPage ()
		{
            

            InitializeComponent ();
            ResetData();
        }
        private void btnList_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new TasskListView(list));
            Navigation.PushAsync(new taskListPage(list));
        }

        private void btnOK_Clicked(object sender, EventArgs e)
        {
            var date = dueDate.Date;
            var time = dueTime.Time;

            list.Add(new taskViewModell
            {
                Title = entryTitle.Text,
                Priority = pickerPriority.SelectedIndex,
                Due = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds),
                isSolved = switchSolved.IsToggled
            });
            ResetData();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            ResetData();
        }
        private void ResetData()
        {
            vm = new taskViewModell();
            vm.isSolved = false;
            vm.Due = DateTime.Now;


            entryTitle.Text = vm.Title;
            pickerPriority.SelectedIndex = vm.Priority;
            dueDate.Date = vm.Due.Date;
            dueTime.Time = vm.Due.TimeOfDay;
            switchSolved.IsToggled = vm.isSolved;


        }
    }
}