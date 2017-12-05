using System.Windows;
using System.Windows.Controls;
using TestAffichage.ViewModel;

namespace TestAffichage.Utils
{
    public class DataTemplateSelectorExample : DataTemplateSelector
    {
        private FrameworkElement element;

        public DataTemplateSelectorExample(FrameworkElement element)
        {
            this.element = element;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return null;

            //TODO !!!!!!
            if (item is ExceptionUVM)
                return element.FindResource("Exception") as DataTemplate;

            return element.FindResource("Indispo") as DataTemplate;
        }
    }
}
