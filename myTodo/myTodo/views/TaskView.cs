using myTodo.viewModell;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace myTodo.views
{
    
    public class TaskView :ContentPage
    {
        Entry entryTitle = new Entry();
        Picker pickerPriority = new Picker
        {
            Items = {
                                "Sürgős" ,
                                "Normál",
                                "Ráér"
                            }
        };
        DatePicker dueDate = new DatePicker();
        TimePicker dueTime = new TimePicker();
        Switch switchSolved = new Switch { IsToggled = false };
        Button btnCancel = new Button { Text = "Mégsem" };
        Button btnOK = new Button { Text = "OK" };
        Button btnList = new Button { Text = "Lista" };

        taskViewModell vm;
        List<taskViewModell> list =new List<taskViewModell>();

        public TaskView()
        {
            btnCancel.Clicked += btnCancel_Clicked;
            btnOK.Clicked += btnOK_Clicked;
            btnList.Clicked += btnList_Clicked;
            ResetData();
            entryTitle.Placeholder = "A feladat leírása";

            pickerPriority.Title = "Fontosság";
            //var itemList = new List<string>();
            //itemList.Add("Sürgős");
            //itemList.Add("Normál");
            //itemList.Add("Ráér");
            //pickerPriority.ItemsSource = itemList;

            //ez iosen és andron megy winen nem
            //pickerPriority.Items.Add( "Ráér");

          


            Content = new StackLayout
            {
                //VerticalOptions = LayoutOptions.Center,
                Children = {
                        new Label {
                            //HorizontalTextAlignment=TextAlignment.Center,
                            Text ="Új feladat rögzítése"
                        },
                        entryTitle,
                        /*new Entry {
                            Placeholder ="A feladat leírása"
                        },*/
                        pickerPriority,
                        /*new Picker {
                            Title = "Fontosság",
                            Items = {
                                "Sürgős" ,
                                "Normál",
                                "Ráér"
                            }
                        },*/
                        new StackLayout {
                            Orientation=StackOrientation.Horizontal,
                            Children = {
                                new Label {
                                Text ="Határnap"
                                } ,
                                dueDate
                            //new DatePicker { }
                            }
                        },
                        new StackLayout {
                            Orientation=StackOrientation.Horizontal,
                            Children = {
                                new Label {
                                Text ="Határidő"
                                } ,
                                dueTime
                            //new TimePicker { }
                            }
                        },
                        new StackLayout {
                            Orientation=StackOrientation.Horizontal,
                            Children = {
                                new Label {
                                Text ="Elintézve"
                                } ,
                               switchSolved
                            
                            }
                        },
                        new StackLayout {
                            Orientation=StackOrientation.Horizontal,
                            Children = {
                                btnCancel,
                                btnOK,
                                btnList
                                //new Button {                                Text ="Mégsem"                                } ,
                                //new Button {                                Text ="Mentés"                                } ,

                            }
                        }

                    }
            };
        }

        private void btnList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TasskListView(list));
        }

        private void btnOK_Clicked(object sender, EventArgs e)
        {
            var date = dueDate.Date;
            var time = dueTime.Time;

            list.Add(new taskViewModell {
                Title = entryTitle.Text,
                Priority = pickerPriority.SelectedIndex,
                Due = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes,time.Seconds),
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
