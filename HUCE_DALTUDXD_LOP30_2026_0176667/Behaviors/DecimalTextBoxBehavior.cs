using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Behaviors
{
    public static class DecimalTextBoxBehavior
    {
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
                "IsEnabled",
                typeof(bool),
                typeof(DecimalTextBoxBehavior),
                new PropertyMetadata(false, OnIsEnabledChanged));

        private static readonly Regex DecimalRegex = new(@"^[+-]?\d*([.,]\d*)?$");

        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not TextBox textBox)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                textBox.PreviewTextInput += OnPreviewTextInput;
                textBox.LostFocus += OnLostFocus;
                DataObject.AddPastingHandler(textBox, OnPaste);
            }
            else
            {
                textBox.PreviewTextInput -= OnPreviewTextInput;
                textBox.LostFocus -= OnLostFocus;
                DataObject.RemovePastingHandler(textBox, OnPaste);
            }
        }

        private static void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is not TextBox textBox || textBox.IsReadOnly)
            {
                return;
            }

            e.Handled = !IsValidCandidate(GetCandidateText(textBox, e.Text));
        }

        private static void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (sender is not TextBox textBox || textBox.IsReadOnly)
            {
                return;
            }

            if (!e.DataObject.GetDataPresent(DataFormats.Text))
            {
                e.CancelCommand();
                return;
            }

            var pastedText = e.DataObject.GetData(DataFormats.Text) as string ?? string.Empty;
            if (!IsValidCandidate(GetCandidateText(textBox, pastedText)))
            {
                e.CancelCommand();
            }
        }

        private static void OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is not TextBox textBox || textBox.IsReadOnly || string.IsNullOrWhiteSpace(textBox.Text))
            {
                return;
            }

            var text = textBox.Text.Trim().Replace(',', '.');
            if (text.StartsWith(".", StringComparison.Ordinal))
            {
                text = "0" + text;
            }
            else if (text.StartsWith("-.", StringComparison.Ordinal))
            {
                text = "-0" + text[1..];
            }
            else if (text.StartsWith("+.", StringComparison.Ordinal))
            {
                text = "+0" + text[1..];
            }

            if (text.EndsWith(".", StringComparison.Ordinal))
            {
                text += "0";
            }

            if (textBox.Text != text)
            {
                textBox.Text = text;
            }

            textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }

        private static string GetCandidateText(TextBox textBox, string input)
        {
            var text = textBox.Text ?? string.Empty;
            return text.Remove(textBox.SelectionStart, textBox.SelectionLength)
                       .Insert(textBox.SelectionStart, input);
        }

        private static bool IsValidCandidate(string text)
        {
            return string.IsNullOrWhiteSpace(text) || DecimalRegex.IsMatch(text);
        }
    }
}
