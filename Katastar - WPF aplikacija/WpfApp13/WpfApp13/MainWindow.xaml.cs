using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KatastarDataContext Katastar = new KatastarDataContext();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void puniCombo() // Data entry in combobox (name of municipalities)
        {
            var opstine = from o in Katastar.KatastarskeOpstines
                          select o;
            cbKatOpstine.ItemsSource = opstine;
        }
        private void puniDatagrid() // Data entry in the datagrid for the name of the municipality selected in cobobox
        {
            var parcele = from p in Katastar.Parceles
                          where p.IDKatOpstine == int.Parse(((KatastarskeOpstine)cbKatOpstine.SelectedValue).IDKatOpstina.ToString())
                          select p;
            datagrid.ItemsSource = parcele;
            // in MainWindow.xaml was made what data to show
        }


        private void Datagrid_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
           
           // view of objects located on the land that we clicked, there can be only one object on that land
            try
            {
                Objekti objekti = (from o in Katastar.Objektis
                                   where o.IDKatOpstine == int.Parse(((Parcele)datagrid.SelectedValue).IDKatOpstine.ToString()) && o.IDParcele == int.Parse(((Parcele)datagrid.SelectedValue).IDParcele.ToString())
                                   select o).First();
                if (objekti != null)
                {

                    TextBox tb1 = e.DetailsElement.FindName("txtIDObjekta") as TextBox;
                    tb1.Text = objekti.IDObjekta.ToString();
                    TextBox tb2 = e.DetailsElement.FindName("txtVlasnik") as TextBox;
                    tb2.Text = objekti.Vlasnik;
                    TextBox tb3 = e.DetailsElement.FindName("txtKvadratura") as TextBox;
                    tb3.Text = objekti.Kvadratura.ToString();
                    CheckBox cb1 = e.DetailsElement.FindName("cbUknjizeno") as CheckBox;
                    if (objekti.Uknjizeno == true) cb1.IsChecked = true;

                }
            }
            catch(Exception)
            {
                TextBox tb1 = e.DetailsElement.FindName("txtIDObjekta") as TextBox;
                tb1.Text = "";
                TextBox tb2 = e.DetailsElement.FindName("txtVlasnik") as TextBox;
                tb2.Text = "";
                TextBox tb3 = e.DetailsElement.FindName("txtKvadratura") as TextBox;
                tb3.Text = "";
                CheckBox cb1 = e.DetailsElement.FindName("cbUknjizeno") as CheckBox;
                cb1.IsChecked = false;
                MessageBox.Show("Nema objekta na parceli");
            }
           
            
  
        }

        private void Brisanje(object sender, RoutedEventArgs e)
        {

            // deleting an object by right - clicking on a specific plot in the datagrid

            Objekti brisi = (from o in Katastar.Objektis
                               where o.IDKatOpstine == int.Parse(((Parcele)datagrid.SelectedValue).IDKatOpstine.ToString()) && o.IDParcele == int.Parse(((Parcele)datagrid.SelectedValue).IDParcele.ToString())
                               select o).First();
            MessageBoxResult rez = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);
            if (rez == MessageBoxResult.Yes)
            {
                Katastar.Objektis.DeleteOnSubmit(brisi);
                
                try
                {
                    Katastar.SubmitChanges();
                    // Resetting dataagrids and fields that shows us unbooked objects for the selected municipality
                    puniDatagrid();
                    neuknjizeni();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ne moze da se obrise !" + ex);
                }
            }
        }

        private void CbKatOpstine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            puniDatagrid();
            neuknjizeni();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            puniCombo();
        }
        private string vratiVlasnistvo()
        {
            string pom = "";
            foreach(RadioButton rb in gridVlasnistvo.Children)
            {
                if(rb.IsChecked==true)
                pom = rb.Content.ToString();
            }
            return pom;
        }
        private void TbSifraParcele_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbSifraParcele.Text))
            {
                gbVlasnistvo.IsEnabled = true;
            }
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            string vlasnistvo = vratiVlasnistvo();
            try
            {
                if (!String.IsNullOrEmpty(cbKatOpstine.Text) && !String.IsNullOrEmpty(tbSifraParcele.Text) && !String.IsNullOrEmpty(vlasnistvo))
                {
                    Parcele parcele = (from p in Katastar.Parceles
                                       where p.IDKatOpstine == int.Parse(((KatastarskeOpstine)cbKatOpstine.SelectedValue).IDKatOpstina.ToString()) && p.IDParcele == int.Parse(tbSifraParcele.Text)
                                       select p).Single();
                    parcele.Vlasnistvo = vlasnistvo;
                    try
                    {
                        Katastar.SubmitChanges();
                        MessageBox.Show("Vlasnistvo za parcelu " + tbSifraParcele.Text + " u katastarskoj opstini " + ((KatastarskeOpstine)cbKatOpstine.SelectedValue).Naziv + " je uspesno promenjena");
                        puniDatagrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Neuspesno " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Nesto nije popunjeno");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Nije dobro uneta sifra");
            }
        }
        private void neuknjizeni()
        {
            
            var objekti = (from o in Katastar.Objektis
                           where o.IDKatOpstine == int.Parse(((KatastarskeOpstine)cbKatOpstine.SelectedValue).IDKatOpstina.ToString())&& (o.Uknjizeno==null || o.Uknjizeno==false)
                           select o).Count();
            tbNeuknjizeni.Text = objekti.ToString();
        }

        private void Unos(object sender, RoutedEventArgs e)
        {
            UnosNovog nov = new UnosNovog();
            nov.ShowDialog();
            

        }
    }
}
