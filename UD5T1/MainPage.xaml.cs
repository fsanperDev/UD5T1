namespace UD5T1
{
    public partial class MainPage : ContentPage
    {
        float cuenta;
        int propina;
        int personas = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void CalcularTotal()
        {
            // Propina total
            var propinaTotal = cuenta * propina / 100;

            // Propina por persona
            var propinaPorPersona = propinaTotal / personas;

            // Subtotal
            var subtotal = cuenta / personas;
            lblSubtotal.Text = $"{subtotal:C}";

            // Total
            var totalPersonas = (cuenta + propinaTotal) / personas;
            lblTotal.Text = $"{totalPersonas:C}";
        }

        private void TxtCuenta_Completa(object sender, EventArgs e)
        {
            cuenta = float.Parse(txtCuenta.Text);
            CalcularTotal();
        }

        private void SldPropina_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            propina = Convert.ToInt32(sldPropina.Value);
            lblPropina.Text = "Propina: " + propina.ToString() + "%";
            CalcularTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn = (Button)sender;
                var porcentaje = int.Parse(btn.Text.Replace("%", string.Empty));
                sldPropina.Value = porcentaje;
            }
        }

        private void BtnMenos_Clicked(object sender, EventArgs e)
        {
            if(personas > 1)
            {
                personas--;
                lblPersonas.Text = personas.ToString();
                CalcularTotal();
            }
        }

        private void BtnMas_Clicked(object sender, EventArgs e)
        {
            personas++;
            lblPersonas.Text = personas.ToString();
            CalcularTotal();
        }
        
    }

}
