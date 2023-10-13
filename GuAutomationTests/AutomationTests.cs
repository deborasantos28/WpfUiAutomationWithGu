using Gu.Wpf.UiAutomation;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using System.Diagnostics;

namespace GuAutomationTests
{
    public class AutomationTests
    {
        /*
         Please insert your fullpath to the exe file in the ExeFileName. 
         This app is only a prototype, therefore it does not apply the most
         performant way to display a path.
         */
        public string ExeFileName = @"C:\WpfUiAutomationWithGu.exe";

        private const string WindowName = "MainWindow";

        [Test]
        public void SayHelloButtonIsPressed()
        {
            using Application app = Application.Launch(ExeFileName, WindowName);
            
            Window window = app.MainWindow;

            TextBlock label = window.FindTextBlock("txtResult");

            Assert.That(label.Text, Is.EqualTo(string.Empty));

            TextBox textBox = window.FindTextBox("txtName");

            textBox.Text = "Deb";

            Button button = window.FindButton("sayHelloButton");

            button.Click();

            Assert.That("Hello Deb", Is.EqualTo(label.Text));
        }

        [Test]
        public void SelectItemFromComboBox()
        {
            using Application app = Application.Launch(ExeFileName, WindowName);

            Window window = app.MainWindow;

            ComboBox combo = window.FindComboBox("dropdownList");

            combo.Select(1);

            ComboBoxItem? selectedItem = combo.SelectedItem;

            Assert.That(selectedItem?.Text, Is.EqualTo("Cow"));
        }

        [Test]
        public void GetAnElementFromBoundListOfStrings()
        {
            using Application app = Application.Launch(ExeFileName, WindowName);

            Window window = app.MainWindow;

            ListBox flowers = window.FindListBox("FlowersList");

            ListBoxItem flower = flowers.Items[0];

            flower.Click();

            Assert.That(flower.Text, Is.EqualTo("Tulip"));
        }

        [Test]
        public void GetAnElementFromABoundListWithMultipleData()
        {
            using Application app = Application.Launch(ExeFileName, WindowName);

            Window window = app.MainWindow;

            ListBox trees = window.FindListBox("TreesList");
            
            ListBoxItem tree = trees.Items[0];
            
            tree.Click();

            Assert.That(tree.Text, Is.EqualTo("Fir"));
        }

        [Test]
        public void GetAllTheElementsFromABoundListWithMultipleData()
        {
            using Application app = Application.Launch(ExeFileName, WindowName);

            Window window = app.MainWindow;

            ListBox trees = window.FindListBox("TreesList");
            
            Assert.That(trees.Items.Count, Is.EqualTo(4));
        }

        [Test]
        public void SlideTheSlider()
        {
            using Application app =Application.Launch(ExeFileName, WindowName);
            Window window = app.MainWindow;
            
            Slider slider = window.FindSlider("slider");
            
            slider.Value = 5;
            
            Assert.That(slider.Value, Is.EqualTo(5));
        }
    }
}