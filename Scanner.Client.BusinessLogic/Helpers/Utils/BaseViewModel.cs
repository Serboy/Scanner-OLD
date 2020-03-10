using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Scanner.Client.BusinessLogic.Helpers.Utils {
    public abstract class BaseViewModel : INotifyPropertyChanged {
        public void NotifyOfPropertyChange(string propertyName) {
            var handler = PropertyChanged;

            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> property) {
            if (PropertyChanged == null) {
                return;
            }

            var lambda = (LambdaExpression)property;

            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression) {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            } else
                memberExpression = (MemberExpression)lambda.Body;

            NotifyOfPropertyChange(memberExpression.Member.Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
