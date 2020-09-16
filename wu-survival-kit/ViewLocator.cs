using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using wu_survival_kit.ViewModels;

namespace wu_survival_kit
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public IControl Build(object data)
        {
            string name = data.GetType().FullName.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
                return (Control) Activator.CreateInstance(type);
            return new TextBlock { Text = $"Not Found: {name}"};
        }

        public bool Match(object data) => data is ViewModelBase;
    }
}