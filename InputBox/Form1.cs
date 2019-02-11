
using System.Windows.Forms;

namespace InputBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            muestraTextBox();
        }
        public void muestraTextBox() {
            InputBox inputBox = new InputBox();
            textBoxDialogResult.Text =  inputBox.ShowDialog("Holadasdasdasdasdasd\nfdklngldnglnldf" , "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, InputBox.Tipo.TextBox, null).ToString();
            textBoxValor.Text = inputBox.Valor;
        }
        public void muestraInputBox() {
            InputBox inputBox = new InputBox();
            string[] items = { "Hola", "adios" };
            textBoxDialogResult.Text = inputBox.ShowDialog("Holadasdasdasdasdasd\nfdklngldnglnldf", "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, InputBox.Tipo.ComboBox, items).ToString();
            textBoxValor.Text = inputBox.Valor;
        }
    }
}
