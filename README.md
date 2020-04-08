# How to expand the TreeView node using MR.Gesture in Xamarin.Forms (SfTreeView) ?

You can expand [TreeViewNode](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.TreeView.Engine.TreeViewNode.html?) using [Mr.Gesture](https://www.mrgestures.com/) events in Xamrin.Forms [SfTreeView](https://help.syncfusion.com/xamarin/treeview/overview?).

You can also refer the following article.

https://www.syncfusion.com/kb/11368/how-to-expand-the-treeview-node-using-mr-gesture-in-xamarin-forms-sftreeview

**Step 1:** Install the [Mr.Gesture](https://www.nuget.org/packages/MR.Gestures/) Nuget package in the shared code project.

**Step 2:** Create your Xaml page by inheriting Mr.Gesture.ContentPage

``` c#
namespace TreeViewXamarin
{
    public partial class MainPage : MR.Gestures.ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
```

**Step 3:** Add TreeView to the content of the page. Add Mr.Gesture.Grid to the [ItemTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemTemplate.html?) of TreeView and set the behavior of Mr.Gesture.Grid.

``` xml
<mr:ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:mr="clr-namespace:MR.Gestures;assembly=MR.Gestures"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:TreeViewXamarin"
             xmlns:syncfusion="clr-namespace:Syncfusion.XForms.TreeView;assembly=Syncfusion.SfTreeView.XForms"
             x:Class="TreeViewXamarin.MainPage">
 
    <mr:ContentPage.BindingContext>
        <local:FileManagerViewModel x:Name="viewModel"/>
    </mr:ContentPage.BindingContext>
 
    <syncfusion:SfTreeView x:Name="treeView"
                           ItemHeight="40"
                           Indentation="15"
                           ExpanderWidth="40"
                           ChildPropertyName="SubFiles"
                           ItemTemplateContextType="Node"
                           ItemsSource="{Binding ImageNodeInfo}"
                           VerticalOptions="Center">
        <syncfusion:SfTreeView.ItemTemplate>
            <DataTemplate>
                <mr:Grid x:Name="grid" RowSpacing="0" >
                    <mr:Grid.Behaviors>
                        <local:Behavior/>
                    </mr:Grid.Behaviors>
                    
                    <mr:Grid.ColumnDefinitions>
                        <ColumnDefinition Width="40" />
                        <ColumnDefinition Width="*" />
                    </mr:Grid.ColumnDefinitions>
                    <Image Source="{Binding Content.ImageIcon}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="35" WidthRequest="35"/>
                    <Grid Grid.Column="1" RowSpacing="1" VerticalOptions="Center">
                        <Label LineBreakMode="NoWrap" Margin="1,0,0,0" Text="{Binding Content.ItemName}" VerticalTextAlignment="Center"/>
                    </Grid>
                </mr:Grid>
            </DataTemplate>
        </syncfusion:SfTreeView.ItemTemplate>
    </syncfusion:SfTreeView>
</mr:ContentPage>
```

**Step 4:** [TappedEvent](https://www.mrgestures.com/#EventsXAML) for Mr.Gesture grid wired in Mr.Gesture.Grid [Behavior](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/event-to-command-behavior). In the tapped event, TreeViewNode expanded using the ExpandNode method of SfTreeView.

``` C#
namespace TreeViewXamarin
{
    public class Behavior : Behavior<MR.Gestures.Grid>
    {
        protected override void OnAttachedTo(MR.Gestures.Grid bindable)
        {
            bindable.Tapped += Bindable_Tapped;
            base.OnAttachedTo(bindable);
        }
 
        private void Bindable_Tapped(object sender, TapEventArgs e)
        {
            var treeViewNode = ((sender as MR.Gestures.Grid).BindingContext) as TreeViewNode;
            var treeView = (sender as MR.Gestures.Grid).Parent as SfTreeView;
            treeView.ExpandNode(treeViewNode);
        }
    }
}
```
