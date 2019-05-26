using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registro2.Entidades;
using Registro2.BLL;

namespace Registro2.UI.Registros
{
    public partial class rCargos : Form
    {
        public rCargos()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(CargosIdnumericUpDown.Text, out id);

            Limpiar();

            if (CargoBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(CargosIdnumericUpDown, "No se puede eliminar una persona que no existe");
        }

        private void Limpiar()
        {
            CargosIdnumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
          
            MyErrorProvider.Clear();
        }

        private Cargos LlenaClase()
        {
            Cargos cargos = new Cargos();
            cargos.CargoId = Convert.ToInt32(CargosIdnumericUpDown.Value);
            cargos.Descripcion = DescripcionTextBox.Text;
          

            return cargos;
        }

        private void LlenarCampo(Cargos cargos)
        {
            CargosIdnumericUpDown.Value = cargos.CargoId;
            DescripcionTextBox.Text = cargos.Descripcion;
   
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Cargos cargos;
            bool paso = false;

            if (!Validar())
                return;
            cargos = LlenaClase();


            if (CargosIdnumericUpDown.Value == 0)
            {
                paso = CargoBLL.Guardar(cargos);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = CargoBLL.Modificar(cargos);
            }
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Cargos cargos = CargoBLL.Buscar((int)CargosIdnumericUpDown.Value);
            return (cargos != null);
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (DescripcionTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(DescripcionTextBox, "El campo Descripcion no puede estar vacio");
                DescripcionTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CargosIdnumericUpDown.Text))
            {
                MyErrorProvider.SetError(CargosIdnumericUpDown, "El campo CargosId no puede estar vacio");
                CargosIdnumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Cargos cargos = new Cargos();
            int.TryParse(CargosIdnumericUpDown.Text, out id);

            Limpiar();

            cargos = CargoBLL.Buscar(id);

            if (cargos != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenarCampo(cargos);
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");
            }
        }
    }
}
