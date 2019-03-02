using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Framework.Windows.Forms
{
    /// <summary>
    /// Provides Windows Forms Core Services
    /// </summary>
    public class BaseCoreForm: Form
    {
        #region| Fields |

        private int MouseX = 0;
        private int MouseY = 0;
        private bool Dragging = false; 

        #endregion

        #region| Methods |          

        private void SetDragDrop<T>(object sender) where T : Control
        {
            var oControl = GetSender<Control>(sender);

            oControl.AllowDrop = true;

            oControl.MouseEnter += new EventHandler(oControl_MouseEnter);
            oControl.MouseMove += new MouseEventHandler(MouseLeftMove<T>);
            oControl.MouseDown += new MouseEventHandler(MouseLeftDown<T>);
            oControl.MouseUp += new MouseEventHandler(MouseLeftUp<T>);
            oControl.MouseLeave += new EventHandler(oControl_MouseLeave);
        }

        void oControl_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            this.Refresh();
        }

        void oControl_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeAll;
            this.Refresh();
        }

        private void MouseLeftUp<T>(object sender, MouseEventArgs e) where T : Control
        {
            if (Dragging)
            {
                Dragging = false;

                //UpdateCoordinates<T>(sender);

                //Altera = true;
                //AlteraControl();
            }

            this.Refresh();
        }

        private void MouseLeftDown<T>(object sender, MouseEventArgs e) where T : Control
        {
            if (e.Button == MouseButtons.Left)
            {
                Dragging = true;
                //Altera = false;

                MouseX = -e.X;
                MouseY = -e.Y;

                var oControl = GetSender<T>(sender);

                //UpdateCoordinates<T>(sender, oControl);

                //AtualizaClasseItem(oControl);

            }
        }

        private Control GetControl(Control sender, string Name)
        {
            var oControls = sender.Controls.Find(Name, false);

            return oControls.First();

        }

        private void MouseLeftMove<T>(object sender, MouseEventArgs e) where T : Control
        {
            if (Dragging)
            {
                var oPoint = new Point();

                //if (this.TemplateCurrent.IsEtiqueta)
                //{
                //    var oControle = GetControl(AreaDesenho, "Etiqueta");

                //    oPoint = oControle.PointToClient(MousePosition);
                //}
                //else
                //{
                //    oPoint = AreaDesenho.PointToClient(MousePosition);
                //}

                oPoint.Offset(MouseX, MouseY);

                var oControl = GetSender<T>(sender);

                oControl.Location = oPoint;

                //txtTop.Text = oControl.Top.ToString();
               // txtLeft.Text = oControl.Left.ToString();
            }
        }

        private T GetSender<T>(object sender) where T : Control
        {
            return (T)sender;
        }

        #endregion
    }
}
