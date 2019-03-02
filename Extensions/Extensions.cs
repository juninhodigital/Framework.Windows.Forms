using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Framework.Windows.Forms
{
    /// <summary>
    /// Providers Extension Methods that are a special kind of static method, 
    /// but they are called as if they were instance methods on the extended type. 
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Executes the specified delegate on the thread that owns the control's underlying window handle.
        /// </summary>
        /// <param name="control">sender</param>
        /// <param name="action">Action</param>
        public static void Invoke(this Control @control, Action action)
        {
            control.Invoke((Delegate)action);
        }

        /// <summary>
        /// Displays a message box with specified text as a Warning
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="Message">Message</param>
        /// <param name="button">MessageBoxButtons</param>
        /// <param name="icon">MessageBoxIcon</param>
        public static void Alert(this Form sender, string Message, MessageBoxButtons button = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            MessageBox.Show(Message, "Warning", button, icon);
        }

        /// <summary>
        /// Displays a message box with specified text as a Information
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="Message">Message</param>
        /// <param name="button">MessageBoxButtons</param>
        /// <param name="icon">MessageBoxIcon</param>
        public static void Inform(this Form sender, string Message, MessageBoxButtons button = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            MessageBox.Show(Message, "Information", button, icon);
        }

        /// <summary>
        /// Displays a message box with specified text as a Error
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="Message">Message</param>
        /// <param name="button">MessageBoxButtons</param>
        /// <param name="icon">MessageBoxIcon</param>
        public static void Error(this Form sender, string Message, MessageBoxButtons button = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            MessageBox.Show(Message, "Error", button, icon);
        }

        /// <summary>
        /// Displays a message to confirm an action
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="Question">Question</param>
        /// <returns>true if the question is correct, otherwise false</returns>
        public static bool Confirm(this Form sender, string Question)
        {
            if (MessageBox.Show(Question, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Only allows numeric value in the text property
        /// </summary>
        /// <param name="sender"></param>
        public static void SetOnlyNumericOnKeyDown(this TextBox sender)
        {
            // Disable context menu from textbox control
            sender.ShortcutsEnabled = false;

            sender.KeyDown += new KeyEventHandler(OnlyNumericOnKeyDown);
        }

        /// <summary>
        /// Only allows currency value in the text property
        /// </summary>
        /// <param name="sender"></param>
        public static void SetOnlyCurrencyOnKeyDown(this TextBox sender)
        {
            // Disable context menu from textbox control
            sender.ShortcutsEnabled = false;

            sender.KeyDown += new KeyEventHandler(OnlyCurrencyOnKeyDown);
        }

        /// <summary>
        /// Set the current textbox control to be read-only
        /// </summary>
        /// <param name="sender"></param>
        public static void SetReadOnly(this TextBox sender)
        {
            // Disable context menu from textbox control
            sender.ShortcutsEnabled = false;

            sender.KeyDown += (a, b) => { b.SuppressKeyPress = true; };
            sender.KeyUp += (a, b) => { b.SuppressKeyPress = true; };
       
        }
        /// <summary>
        /// Get all child controls depending on its type
        /// </summary>
        /// <param name="control"></param>
        /// <param name="filteringTypes"></param>
        /// <returns></returns>
        public static IEnumerable<Control> GetAll(this Control control, Type filteringTypes)
        {
            var ctrls = control.Controls.Cast<Control>();

            return ctrls.SelectMany(ctrl => GetAll(ctrl, filteringTypes))
                        .Concat(ctrls)
                        .Where(ctl => ctl.GetType() == filteringTypes);
        }

        /// <summary>
        /// Restrict the keypad to accept only currency values with comma and full stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnlyNumericOnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                case Keys.Left:
                case Keys.Right:
                case Keys.Delete:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                    {
                        e.SuppressKeyPress = false;
                        break;
                    }
                default:
                    {
                        e.SuppressKeyPress = true;
                        break;
                    }
            }
        }

        /// <summary>
        /// Restrict the keypad to accept only numeric values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnlyCurrencyOnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                case Keys.Left:
                case Keys.Right:
                case Keys.Delete:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.Oemcomma:
                case Keys.OemPeriod:
                case Keys.Decimal:
                    {
                        e.SuppressKeyPress = false;
                        break;
                    }
                default:
                    {
                        e.SuppressKeyPress = true;
                        break;
                    }
            }
        }
    }
}
