﻿using System;
using System.ComponentModel;
using Okra.Core;
using System.Linq.Expressions;
using Xunit;

namespace Okra.Tests.Core
{
    public class NotifyPropertyChangedFixture
    {
        // *** Method Tests ***

        [Fact]
        public void GetPropertyName_ReturnsNameOfProperty()
        {
            string propertyName = TestableNotifyPropertyChanged.GetPropertyName(o => o.MyProperty);

            Assert.Equal("MyProperty", propertyName);
        }

        [Fact]
        public void GetPropertyName_Exception_LambdaExpressionIsNull()
        {
            var e = Assert.Throws<ArgumentNullException>(() => TestableNotifyPropertyChanged.GetPropertyName(null));

            Assert.Equal("Value cannot be null.\r\nParameter name: propertyExpression", e.Message);
            Assert.Equal("propertyExpression", e.ParamName);
        }

        [Fact]
        public void GetPropertyName_Exception_LambdaExpressionIsNotMemberAccess()
        {
            var e = Assert.Throws<ArgumentException>(() => TestableNotifyPropertyChanged.GetPropertyName(o => 42));

            Assert.Equal("The argument must be a member access lambda expression.\r\nParameter name: propertyExpression", e.Message);
            Assert.Equal("propertyExpression", e.ParamName);
        }

        [Fact]
        public void OnPropertyChanged_FiresPropertyChangedEvent_Void()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
                {
                    Assert.Equal(obj, sender);
                    Assert.Equal("MyProperty", e.PropertyName);
                    propertyChangedCount++;
                };

            obj.MyProperty = 42;

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void OnPropertyChanged_FiresPropertyChangedEvent_String()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MyProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.FirePropertyChangedWithString("MyProperty");

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void OnPropertyChanged_FiresPropertyChangedEvent_PropertyChangedEventArgs()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MyProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.FirePropertyChangedWithEventArgs(new PropertyChangedEventArgs("MyProperty"));

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void OnPropertyChanged_FiresPropertyChangedEvent_LambdaExpression()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MyProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.FirePropertyChangedWithLambda(() => obj.MyProperty);

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void OnPropertyChanged_Exception_LambdaExpression_ExpressionIsNull()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            var e = Assert.Throws<ArgumentNullException>(() => obj.FirePropertyChangedWithLambda<int>(null));

            Assert.Equal("Value cannot be null.\r\nParameter name: propertyExpression", e.Message);
            Assert.Equal("propertyExpression", e.ParamName);
        }

        [Fact]
        public void OnPropertyChanged_Exception_LambdaExpression_IsNotMemberAccess()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            var e = Assert.Throws<ArgumentException>(() => obj.FirePropertyChangedWithLambda<int>(() => 42));

            Assert.Equal("The argument must be a member access lambda expression.\r\nParameter name: propertyExpression", e.Message);
            Assert.Equal("propertyExpression", e.ParamName);
        }

        [Fact]
        public void OnPropertyChanged_IgnoresIfNoEventHandlerAttached()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            obj.FirePropertyChangedWithEventArgs(new PropertyChangedEventArgs("MyProperty"));
        }

        [Fact]
        public void SetProperty_FiresPropertyChangedEvent_Void_Struct()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MySetProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.MySetProperty = 42;

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_FiresPropertyChangedEvent_Void_Object()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MyObjectProperty = new object() };

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MyObjectProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.MyObjectProperty = new object();

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_FiresPropertyChangedEvent_Void_Object_FromNull()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MyObjectProperty = null };

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MyObjectProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.MyObjectProperty = new object();

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_FiresPropertyChangedEvent_Void_Object_ToNull()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MyObjectProperty = new object() };

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MyObjectProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.MyObjectProperty = null;

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_FiresPropertyChangedEvent_String()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MySetProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.SetProperty_MySetProperty(42, "MySetProperty");

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_FiresPropertyChangedEvent_LambdaExpression()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MySetProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.SetProperty_MySetProperty(42, () => obj.MySetProperty);

            Assert.Equal(1, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_Exception_LambdaExpression_ExpressionIsNull()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            Expression<Func<int>> propertyExpression = null;
            var e = Assert.Throws<ArgumentNullException>(() => obj.SetProperty_MySetProperty(10, propertyExpression));

            Assert.Equal("Value cannot be null.\r\nParameter name: propertyExpression", e.Message);
            Assert.Equal("propertyExpression", e.ParamName);
        }

        [Fact]
        public void SetProperty_Exception_LambdaExpression_IsNotMemberAccess()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();

            var e = Assert.Throws<ArgumentException>(() => obj.SetProperty_MySetProperty(10, () => 42));

            Assert.Equal("The argument must be a member access lambda expression.\r\nParameter name: propertyExpression", e.Message);
            Assert.Equal("propertyExpression", e.ParamName);
        }

        [Fact]
        public void SetProperty_DoesNotFireEventIfNotChanged_Struct()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MySetProperty = 10 };

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MySetProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.MySetProperty = 10;

            Assert.Equal(0, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_DoesNotFireEventIfNotChanged_Object()
        {
            object value = new object();
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MyObjectProperty = value };

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MyObjectProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.MyObjectProperty = value;

            Assert.Equal(0, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_DoesNotFireEventIfNotChanged_ObjectNull()
        {
            object value = new object();
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MyObjectProperty = null };

            int propertyChangedCount = 0;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.Equal(obj, sender);
                Assert.Equal("MyObjectProperty", e.PropertyName);
                propertyChangedCount++;
            };

            obj.MyObjectProperty = null;

            Assert.Equal(0, propertyChangedCount);
        }

        [Fact]
        public void SetProperty_ReturnsTrue_IfValueHasChanged()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MySetProperty = 5 };

            bool changed = obj.SetProperty_MySetProperty(10, "MySetProperty");

            Assert.Equal(true, changed);
        }

        [Fact]
        public void SetProperty_ReturnsTrue_IfValueHasNotChanged()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MySetProperty = 10 };

            bool changed = obj.SetProperty_MySetProperty(10, "MySetProperty");

            Assert.Equal(false, changed);
        }

        [Fact]
        public void SetProperty_SetsProperty_Struct()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged() { MySetProperty = 5 };

            obj.SetProperty_MySetProperty(10, "MySetProperty");

            Assert.Equal(10, obj.MySetProperty);
        }

        [Fact]
        public void SetProperty_SetsProperty_Object()
        {
            TestableNotifyPropertyChanged obj = new TestableNotifyPropertyChanged();
            object value = new object();

            obj.SetProperty_MyObjectProperty(value, "MyObjectProperty");

            Assert.Equal(value, obj.MyObjectProperty);
        }

        // *** Private Sub-classes ***

        private class TestableNotifyPropertyChanged : NotifyPropertyChangedBase
        {
            // *** Fields ***

            private int _myProperty;
            private int _mySetProperty;
            private object _myObjectProperty;

            // *** Properties ***

            public object MyObjectProperty
            {
                get
                {
                    return _myObjectProperty;
                }
                set
                {
                    SetProperty(ref _myObjectProperty, value);
                }
            }

            public int MyProperty
            {
                get
                {
                    return _myProperty;
                }
                set
                {
                    _myProperty = value;
                    OnPropertyChanged();
                }
            }

            public int MySetProperty
            {
                get
                {
                    return _mySetProperty;
                }
                set
                {
                    SetProperty(ref _mySetProperty, value);
                }
            }

            // *** Methods ***

            public void FirePropertyChangedWithString(string propertyName)
            {
                base.OnPropertyChanged(propertyName);
            }

            public void FirePropertyChangedWithLambda<T>(Expression<Func<T>> propertyExpression)
            {
                base.OnPropertyChanged(propertyExpression);
            }

            public void FirePropertyChangedWithEventArgs(PropertyChangedEventArgs e)
            {
                base.OnPropertyChanged(e);
            }

            public bool SetProperty_MySetProperty(int value, string propertyName)
            {
                return SetProperty(ref _mySetProperty, value, propertyName);
            }

            public bool SetProperty_MySetProperty(int value, Expression<Func<int>> propertyExpression)
            {
                return SetProperty(ref _mySetProperty, value, propertyExpression);
            }

            public bool SetProperty_MyObjectProperty(object value, string propertyName)
            {
                return SetProperty(ref _myObjectProperty, value, propertyName);
            }

            // *** Static Methods ***

            public static string GetPropertyName(Expression<Func<TestableNotifyPropertyChanged, object>> propertyExpression)
            {
                return NotifyPropertyChangedBase.GetPropertyName(propertyExpression);
            }
        }
    }
}
