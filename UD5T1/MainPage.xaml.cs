namespace UD5T1
{
    public partial class MainPage : ContentPage
    {
        float cuenta; // Se alamacena el importe de la cuenta
        int propina; // Se almacena el porcentaje de la propina
        int personas = 1; // Se almacena el número de personas a dividir

        public MainPage()
        {
            InitializeComponent();
        }

        // Metodo que calcula el total de la Cuenta
        private void CalcularTotal()
        {
            // Propina total
            var propinaTotal = cuenta * propina / 100;

            // Propina por persona
            var propinaPorPersona = propinaTotal / personas;
            lblPropinaPorPersona.Text = $"{propinaPorPersona:C}";

            // Subtotal
            var subtotal = cuenta / personas;
            lblSubtotal.Text = $"{subtotal:C}";

            // Total
            var totalPersonas = (cuenta + propinaTotal) / personas;
            lblTotal.Text = $"{totalPersonas:C}";
        }

        // Metodo que recoge el importe de la cuenta y calcula el total
        private void TxtCuenta_Completa(object sender, EventArgs e)
        {
            cuenta = float.Parse(txtCuenta.Text);
            CalcularTotal();
        }

        // Metodo que recoge el valor del slider y calcula el total
        private void SldPropina_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            propina = Convert.ToInt32(sldPropina.Value);
            lblPropina.Text = "Propina: " + propina.ToString() + "%";
            CalcularTotal();
        }

        // Metodo que recoge el valor del botón y lo actualiza en el slider
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn = (Button)sender;
                var porcentaje = int.Parse(btn.Text.Replace("%", string.Empty));
                sldPropina.Value = porcentaje;
            }
        }

        // Metodo para disminuir el número de persona
        private void BtnMenos_Clicked(object sender, EventArgs e)
        {
            if(personas > 1)
            {
                personas--;
                lblPersonas.Text = personas.ToString();
                CalcularTotal();
            }
        }

        // Metodo para disminuir el número de persona
        private void BtnMas_Clicked(object sender, EventArgs e)
        {
            personas++;
            lblPersonas.Text = personas.ToString();
            CalcularTotal();
        }
        
    }

}
