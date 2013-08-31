﻿namespace TestStack.ConventionTests.Conventions
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using TestStack.ConventionTests.ConventionData;

    public class ViewModelShouldInheritFromINotifyPropertyChanged : IConvention<Types>
    {
        readonly string viewModelSuffix;

        public ViewModelShouldInheritFromINotifyPropertyChanged(string viewModelSuffix = "ViewModel")
        {
            this.viewModelSuffix = viewModelSuffix;
        }

        public void Execute(Types data, IConventionResultContext result)
        {
            var notifyPropertyChanged = typeof (INotifyPropertyChanged);
            var failingData = data.TypesToVerify.Where(t => t.Name.EndsWith(viewModelSuffix, StringComparison.InvariantCultureIgnoreCase))
                .Where(t => !notifyPropertyChanged.IsAssignableFrom(t));

            result.Is("ViewModels (types named *{0}) should inherit from INotifyPropertyChanged",
                failingData);
        }
    }
}