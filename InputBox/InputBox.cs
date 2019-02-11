using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace InputBox
{
    public class InputBox:Form
    {
        public enum Tipo {
            TextBox,
            ComboBox
        }

        private String valor = "";
        private Control comboBox, textBox;
        private Tipo tipo;
        public String Valor {
            get => valor; 
        }

        public InputBox() {
            InicializaComponentes();
        }
        
        
        public DialogResult ShowDialog(string mensaje, string tituloVentana, MessageBoxButtons botones, MessageBoxIcon icono, Tipo tipo, String[] items) {
            Text = tituloVentana;
            Controls.Add(generaPanel(mensaje, icono, tipo, items));
            agregaBotones(botones);
            this.tipo = tipo;
            return ShowDialog();
        }
        
        /// <summary>
        /// Genera el panel donde se va a mostrar la información del MessageBox
        /// </summary>
        /// <param name="mensaje">El mensaje que se va a mostrar</param>
        /// <param name="icono">El icono que se desea mostrar</param>
        /// <param name="tipo">El tipo de input que se desea</param>
        /// <param name="items">Items a mostrar en caso de seleccionar comboBox </param>
        /// <returns></returns>
        private Panel generaPanel(string mensaje, MessageBoxIcon icono, Tipo tipo, string[] items) {
            Panel panel = new Panel();
            panel.Location = new Point(0, 0);
            panel.Size = new Size(340, 97);
            panel.BackColor = Color.White;
            panel.Name = "panel";
            panel.Controls.Add(getIcono(icono));

            //Label que contienen el mensaje a mostrar al usuario
            panel.Controls.Add(generaLabel(mensaje));

            //Tipo de control a agregar
            if (tipo == Tipo.ComboBox) {
                comboBox = getComboBox(items);
                panel.Controls.Add(comboBox);
            }
            else {
                textBox = getTextBox();
                panel.Controls.Add(textBox);
            }
            Controls.Add(panel);
            return panel;
        }

        /// <summary>
        /// Genera el label que se va a mostrar en el control
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar en el label</param>
        /// <returns></returns>
        private static Label generaLabel(string mensaje) {
            Label label = new Label();
            label.Text = mensaje;
            label.Size = new Size(245, 60);
            label.Location = new Point(90, 10);
            label.TextAlign = ContentAlignment.MiddleLeft;
            return label;
        }

        /// <summary>
        /// Obtiene el icono que se quiere mostrar
        /// </summary>
        /// <param name="icono">El icono seleccionado</param>
        /// <returns></returns>
        private PictureBox getIcono(MessageBoxIcon icono)
        {
            PictureBox imagen = new PictureBox();
            switch (icono)
            {
                case MessageBoxIcon.Information:
                    imagen.Image = (Image)global::InputBox.Properties.Resources.Information;
                    break;
                case MessageBoxIcon.Error:
                    imagen.Image = (Image)global::InputBox.Properties.Resources.Error;
                    break;
                case MessageBoxIcon.Exclamation:
                    imagen.Image = (Image)global::InputBox.Properties.Resources.Exclamation;
                    break;
                case MessageBoxIcon.Question:
                    imagen.Image = (Image)global::InputBox.Properties.Resources.Question;
                    break;
                case MessageBoxIcon.None:
                    return null;
            }
            imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            imagen.Size = new Size(30, 30);
            imagen.Location = new Point(50, 25);
            return imagen;
        }

        private TextBox getTextBox() {
            TextBox textBox = new TextBox();
            textBox.Size = new Size(180, 23);
            textBox.Location = new Point(90, 70);
            textBox.Name = "textBox";
            return textBox;
        }

        private ComboBox getComboBox(string[] items) {
            ComboBox comboBox = new ComboBox();
            comboBox.Size = new Size(180, 22);
            comboBox.Location = new Point(90, 70);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Name = "comboBox";
            if (items == null)
            {
                for (int i = 1; i <= 5; i++)
                {
                    comboBox.Items.Add(i);
                }
            }
            else {
                foreach (string item in items) {
                    comboBox.Items.Add(item);
                }

            }
            comboBox.SelectedIndex = 0;
            return comboBox;
        }

        /// <summary>
        /// Agrega los botones que se especifiquen al control
        /// </summary>
        /// <param name="messageBoxButtons">El tipo de botones que se quiere agregar</param>
        private void agregaBotones(MessageBoxButtons messageBoxButtons) {
            Size tamaño = new Size(75, 23);
            switch (messageBoxButtons) {
                case MessageBoxButtons.AbortRetryIgnore:
                    Controls.Add(creaBoton("Abortar", new Point(90, 101), tamaño, DialogResult.Abort));
                    Controls.Add(creaBoton("Reintentar", new Point(170, 101), tamaño, DialogResult.Retry));
                    Controls.Add(creaBoton("Ignorar", new Point(250, 101), tamaño, DialogResult.Ignore));
                    break;
                case MessageBoxButtons.OK:
                    Controls.Add(creaBoton("Aceptar", new Point(250, 101), tamaño, DialogResult.OK));
                    break;
                case MessageBoxButtons.OKCancel:
                    Controls.Add(creaBoton("Aceptar", new Point(170, 101), tamaño, DialogResult.OK));
                    Controls.Add(creaBoton("Cancelar", new Point(250, 101), tamaño, DialogResult.Cancel));
                    break;
                case MessageBoxButtons.RetryCancel:
                    Controls.Add(creaBoton("Reintentar", new Point(170, 101), tamaño, DialogResult.Retry));
                    Controls.Add(creaBoton("Cancelar", new Point(250, 101), tamaño, DialogResult.Cancel));
                    break;
                case MessageBoxButtons.YesNo:
                    Controls.Add(creaBoton("Sí", new Point(170, 101), tamaño, DialogResult.Yes));
                    Controls.Add(creaBoton("No", new Point(250, 101), tamaño, DialogResult.No));
                    break;
                case MessageBoxButtons.YesNoCancel:
                    Controls.Add(creaBoton("Sí", new Point(90, 101), tamaño, DialogResult.Yes));
                    Controls.Add(creaBoton("No", new Point(170, 101), tamaño, DialogResult.No));
                    Controls.Add(creaBoton("Cancelar", new Point(250, 101), tamaño, DialogResult.Cancel));
                    break;
            }
        }

        /// <summary>
        /// Devuelve un control tipo Button con los parámetros dados.
        /// </summary>
        /// <param name="texto">El texto y el nombre que llevará el control</param>
        /// <param name="punto">El punto en donde se localizara el control</param>
        /// <param name="tamaño">el tamaño x y y del control</param>
        /// <returns></returns>
        private Button creaBoton(string texto, Point punto, Size tamaño, DialogResult dialogResult) {
            Button boton = new Button();
            boton.Text = texto;
            boton.Name = "button" + texto;
            boton.Location = punto;
            boton.Size = tamaño;
            boton.DialogResult = dialogResult;
            boton.Click += new System.EventHandler(button_Click);
            return boton;
        }


        private void button_Click(object sender, EventArgs e)
        {
            if (tipo == Tipo.ComboBox)
            {
                valor = comboBox.Text;
            }
            else
            {
                valor = textBox.Text;
            }
            Close();
        }
        
        /// <summary>
        /// Inicializa las propiedades del control
        /// </summary>
        private void InicializaComponentes() {
            Size = new Size(350, 170);
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
        }

    }
}
