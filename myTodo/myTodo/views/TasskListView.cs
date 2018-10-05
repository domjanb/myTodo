using myTodo.viewModell;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace myTodo.views
{
    class TasskListView : ContentPage
    {
        
        

        public TasskListView(List<taskViewModell> vm)
        {
            
            var dataTemplate = new DataTemplate(()=> {
                /*var lblTitle1 = new Label { Text = "titleduma1", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) };
                var lblTitle2 = new Label { Text = "titleduma2", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) };
                var lblTitle3 = new Label { Text = "titleduma3", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
                var lblTitle4 = new Label { Text = "titleduma4", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
                var lblTitle5 = new Label { Text = "titleduma5", FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)) };*/
                var lblTitle = new Label { FontSize= Device.GetNamedSize(NamedSize.Default, typeof(Label)), };
                //Device.g
                lblTitle.SetBinding(Label.TextProperty, "Title");
                var lblPriority = new Label { FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)) };
                lblPriority.SetBinding(Label.TextProperty, "PriorityText");
                var cel = new ViewCell {
                    View = new StackLayout {
                        Padding = 5,
                        Children = {
                            /*lblTitle1,
                            lblTitle2,
                            lblTitle3,
                            lblTitle4,
                            lblTitle5,*/
                            lblTitle,
                            new StackLayout{
                                Orientation=StackOrientation.Horizontal,
                                Children = {
                                    new Label {Text ="Prioritás",FontSize= Device.GetNamedSize(NamedSize.Default, typeof(Label)) , VerticalTextAlignment=TextAlignment.Center},
                                    lblPriority
                                }

                            }
                        }
                    }
                };
                
                return cel;
            });

            Content = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = vm,
                ItemTemplate = dataTemplate,
            };
                
        }
    }
}
